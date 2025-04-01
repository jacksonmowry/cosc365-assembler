public class Call : Instruction.IInstruction
{
    readonly int _offset;
    public Call(int offset)
    {
        _offset = offset & ~3;
    }

    public int Encode()
    {
        return (0b0101 << 28) | _offset;
    }
}
