public class Ifne : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifne(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0xFFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) | (0b001 << 25) | encodedOffset;
    }
}
