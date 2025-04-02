public class Iflt : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Iflt(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) |  (0b010 << 25) | encodedOffset;
    }
}
