public class Goto : Instruction.IInstruction
{
    private readonly int _offset;

    public Goto(int offset)
    {
        _offset = offset;
    }

    public int Encode()
    {
        return (0b0111 << 28) | (_offset & 0x0fffffff);
    }
}
