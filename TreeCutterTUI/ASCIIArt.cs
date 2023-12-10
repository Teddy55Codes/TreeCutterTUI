namespace TreeCutterTUI;

public static class ASCIIArt
{
    public const string Trunck = "[rosybrown]|     |[/]";
    public const string Branch = "[rosybrown]-----[/]";
    public const string NoBranch = "     ";
    public const string CharacterHead = "[tan] o [/]";
    public const string CharacterTorso = @"[darkred_1]/|\[/]";
    public const string CharacterLegs = @"[deepskyblue4_1]/ \[/]";
    public const string Character = $"{CharacterHead}\n{CharacterTorso}\n{CharacterLegs}";

    public const string TreeLayerBranchLeft = Branch + Trunck + NoBranch;
    public const string TreeLayerBranchRight = NoBranch + Trunck + Branch;
    public const string TreeLayerNoBranch = NoBranch + Trunck + NoBranch;

    public const string TreeSegmentBranchLeft = $"""
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerBranchLeft}
                                                 {TreeLayerNoBranch}
                                                 """;
    public const string TreeSegmentBranchRight = $"""
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerNoBranch}
                                                 {TreeLayerBranchRight}
                                                 {TreeLayerNoBranch}
                                                 """;
    public const string TreeSegmentNoBranch = $"""
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               {TreeLayerNoBranch}
                                               """;
    
    public const string TreeSegmentCharacterRight = $"""
                                                     {TreeLayerNoBranch}
                                                     {TreeLayerNoBranch}
                                                     {NoBranch}{Trunck}  {CharacterHead}
                                                     {NoBranch}{Trunck}  {CharacterTorso}
                                                     {NoBranch}{Trunck}  {CharacterLegs}
                                                     """;
    public const string TreeSegmentCharacterLeft = $"""
                                                    {TreeLayerNoBranch}
                                                    {TreeLayerNoBranch}
                                                    {CharacterHead}  {Trunck}{NoBranch}
                                                    {CharacterTorso}  {Trunck}{NoBranch}
                                                    {CharacterLegs}  {Trunck}{NoBranch}
                                                    """;
    public const string TreeSegmentCharacterRightWithBranch = $"""
                                                               {TreeLayerNoBranch}
                                                               {TreeLayerNoBranch}
                                                               {NoBranch}{Trunck}  {CharacterHead}
                                                               {Branch}{Trunck}  {CharacterTorso}
                                                               {NoBranch}{Trunck}  {CharacterLegs}
                                                               """;
    public const string TreeSegmentCharacterLeftWithBranch = $"""
                                                              {TreeLayerNoBranch}
                                                              {TreeLayerNoBranch}
                                                              {CharacterHead}  {Trunck}{NoBranch}
                                                              {CharacterTorso}  {Trunck}{Branch}
                                                              {CharacterLegs}  {Trunck}{NoBranch}
                                                              """;
}