public class Ifez : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifez(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0xFFFFFF;

        }
    }
    public int Encode()
    {
        return (0b10010 << 28) | encodedOffset;
    }
}
