public class Ifgt : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifgt(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b011 << 25) | encodedOffset;
    }
}
