public class Ifnz : Instruction.IInstruction
{
    private readonly int _offset = 0;

    public Ifnz (int? offset)
    {
        if (offset != null)
        {
            int encodedOffset = offset & 0x01FFFFFF;

        }
    }
    public int Encode()
    {
        return (0b10010 << 27) |  (0b01 << 25) | encodedOffset;
    }
}
