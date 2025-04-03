public class Ifpl : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifpl (int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0xFFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1001 << 28) | (0b11 << 25) | encodedOffset;
    }
}
