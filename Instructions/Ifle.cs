public class Ifle : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifle(int? offset)
    {
        if (offset != null)
        {
            encodedOffset = (int)offset;
        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b100 << 25) | (encodedOffset  & 0xFFFFFF);
    }
}
