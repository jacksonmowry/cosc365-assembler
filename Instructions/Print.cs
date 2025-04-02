public class Print : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Print(int? offset)
    {
        if (offset != null)
        {
            _offset = (int)offset;
        }
    }

    public int Encode()
    {
        return (0b1101 << 28) | (_offset & 0x0ffffffc);
    }
}
