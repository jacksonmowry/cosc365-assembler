public class Ifle : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifle(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b100 << 25) | encodedOffset;
    }
}
