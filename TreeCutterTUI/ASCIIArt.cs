namespace TreeCutterTUI;

public static class ASCIIArt
{
    public const string Trunck = "|     |";
    public const string Branch = "-----";
    public const string NoBranch = "     ";
    public const string CharacterHead = " o ";
    public const string CharacterTorso = @"/|\";
    public const string CharacterLegs = @"/ \";
    public const string Character = $"{CharacterHead}\n{CharacterTorso}\n{CharacterLegs}";

    public const string TreeSegmentBranchLeft = Branch + Trunck + NoBranch;
    public const string TreeSegmentBranchRight = NoBranch + Trunck + Branch;
    public const string TreeSegmentNoBranch = NoBranch + Trunck + NoBranch;
}