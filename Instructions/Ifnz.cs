public class Ifnz : Instruction.IInstruction
{
    private readonly int encodedOffset = 0;

    public Ifnz (int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = (int)offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b10010 << 27) |  (0b01 << 25) | encodedOffset;
    }
}
