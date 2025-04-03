public class Ifeq : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifeq(int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0xFFFFFF;

        }
    }
    public int Encode()
    {
        return (0b1000 << 28) | encodedOffset;
    }
}
