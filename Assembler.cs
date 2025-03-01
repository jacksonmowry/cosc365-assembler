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
                if (instructions == null || instructions.Length == 0) {
                    // The line is likely a comment or just blank
                    continue;
                }

                if (label) {
                    // A label, just use the existing PC
                    labelMap.Add(instructions[0].OriginalLine, dummyPC);
                    continue;
                }

                // If we get here we have 1 or more valid instructions to add
                dummyPC += instructions.Length * 4;
                source.AddRange(instructions);
            }
        }

        foreach (var a in labelMap)
        {
            System.Console.WriteLine($"Label {a.Key} is found at {a.Value}");
        }


        // First pass should be done now
        // Now we can go through the lines and make them into instructions
    }
}
