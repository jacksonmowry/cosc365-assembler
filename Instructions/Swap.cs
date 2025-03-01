public class Swap : Instruction.IInstruction
{
    private readonly int _from = 4;
    private readonly int _to = 0;

    public Swap(int? from_, int? to)
    {
        if (from_ != null)
        {
            _from = (int)from_;
        }

        if (to != null)
        {
            _to = (int)to;
        }
    }

    public int Encode() {
        return (0b0001 << 24) | ((_from & 0xfff) << 12) | (_to & 0xfff);
    }
}
