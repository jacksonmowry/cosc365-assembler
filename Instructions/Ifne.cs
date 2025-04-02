public class Ifne : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifne(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b001 << 25) | encodedOffset;
    }
}
