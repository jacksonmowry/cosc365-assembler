public class Goto : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Goto(int? label)
    {

    }

    public int Encode()
    {
        return (0b0111 << 28) | _offset;
    }
}
