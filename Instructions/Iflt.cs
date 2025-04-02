public class Iflt : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Iflt(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b010 << 25) | encodedOffset;
    }
}
