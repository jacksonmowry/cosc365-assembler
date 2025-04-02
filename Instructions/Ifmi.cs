public class Ifmi : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifmi (int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b10010 << 27) |  (0b10 << 25) | encodedOffset;
    }
}