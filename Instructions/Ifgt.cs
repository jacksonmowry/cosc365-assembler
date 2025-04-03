public class Ifgt : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifgt(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0xFFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b011 << 25) | encodedOffset;
    }
}
