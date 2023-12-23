namespace TreeCutterTUI.ASCIIArt;

public static class ASCIIArt
{
    public const string CharacterHead = "[tan] o [/]";
    public const string CharacterTorso = @"[darkred_1]/|\[/]";
    public const string CharacterLegs = @"[deepskyblue4_1]/ \[/]";
    
    #region SizeSmall
    public const string TrunckSmall = "[rosybrown]|     |[/]";
    public const string BranchSmall = "[rosybrown]-----[/]";
    public const string NoBranchSmall = "     ";
    #endregion

    #region SizeLarge
    public const string TrunckLarge = "[rosybrown]|          |[/]";
    public const string BranchLarge = "[rosybrown]---------[/]";
    public const string NoBranchLarge = "         ";
    #endregion
}