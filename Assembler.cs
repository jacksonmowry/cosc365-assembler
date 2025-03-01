class Assembler
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            System.Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} <file.asm> <file.v>");
            Environment.Exit(1);
        }

        string inputFile = args[0];
        string outputFile = args[1];

        Dictionary<string, int> labelMap = new Dictionary<string, int>();
        List<AssemblerLine> source = new List<AssemblerLine>();
        int dummyPC = 0;

        using (StreamReader sr = new StreamReader(inputFile, System.Text.Encoding.ASCII))
        {
            string? line;

            while ((line = sr.ReadLine()) != null)
            {
                (AssemblerLine[]? instructions, bool label) = FirstPass.ProcessOneLine(line.Trim());
                if (instructions == null || instructions.Length == 0)
                {
                    // The line is likely a comment or just blank
                    continue;
                }

                if (label)
                {
                    // A label, just use the existing PC
                    labelMap.Add(instructions[0].OriginalLine, dummyPC);
                    continue;
                }

                // If we get here we have 1 or more valid instructions to add
                dummyPC += instructions.Length * 4;
                source.AddRange(instructions);
            }
        }

        // First pass should be done now
        // Now we can go through the lines and make them into instructions
        List<Instruction.IInstruction> instructionsList = new List<Instruction.IInstruction>();
        // Regular for-loop because we need `i` to keep track of the program counter
        // You'll need to for branch/goto instructions
        for (int i = 0; i < source.Count(); i++)
        {
            int? argOne = Utils.ParseInt(source[i].Tokens.ElementAtOrDefault(1));
            int? argTwo = Utils.ParseInt(source[i].Tokens.ElementAtOrDefault(2));
            Instruction.IInstruction ins = source[i].Tokens[0].ToLower() switch
            {
                "exit" => new Exit(argOne),
                "swap" => new Swap(argOne, argTwo),
                "nop" => new Nop(),
                "input" => new Input(),
                "stinput" => new StInput(argOne),
                "debug" => new Debug(argOne),
                "pop" => new Pop(argOne),
                "add" => new Add(),
                "sub" => new Sub(),
                "mul" => new Mul(),
                "div" => new Div(),
                "rem" => new Rem(),
                "and" => new And(),
                _ => throw new Exception($"Unimplemented instruction {source[i].Tokens[0]}")
            };

            instructionsList.Add(ins);
        }

        using (var outStream = File.Open(outputFile, FileMode.Create))
        {
            using (BinaryWriter br = new BinaryWriter(outStream))
            {
                // Magic Header (Backwards b/c little endian)
                UInt32 deadBeef = 0xEFBE_ADDE;
                br.Write(deadBeef);

                // All remaining instructions
                foreach (var v in instructionsList)
                {
                    br.Write(v.Encode());
                }

                // Pad out to a multiple of 4 instructions
                if (instructionsList.Count() % 4 != 0)
                {
                    int n = new Nop().Encode();
                    for (int i = 0; i < 4 - (instructionsList.Count() % 4); i++)
                    {
                        br.Write(n);
                    }
                }
            }
        }
    }
}
