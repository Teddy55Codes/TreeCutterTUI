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

    public const string TreeLayerBranchLeft = Branch + Trunck + NoBranch;
    public const string TreeLayerBranchRight = NoBranch + Trunck + Branch;
    public const string TreeLayerNoBranch = NoBranch + Trunck + NoBranch;

    public const string TreeSegmentBranchLeft = $"""
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerBranchLeft}
                                                 """;
    public const string TreeSegmentBranchRight = $"""
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerBranchRight}
                                                 """;
    public const string TreeSegmentNoBranch = $"""
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               """;

    public const string TreeSegmentCharacter = $"""
                                                {TreeLayerNoBranch}
                                                {TreeLayerNoBranch}
                                                {NoBranch}{Trunck}{CharacterHead}
                                                {NoBranch}{Trunck}{CharacterTorso}
                                                {NoBranch}{Trunck}{CharacterLegs}
                                                """;
}