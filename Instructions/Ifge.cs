public class Ifge : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifge(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b101 << 25) | encodedOffset;
    }
}
