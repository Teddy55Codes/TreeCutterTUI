namespace TreeCutterTUI.ASCIIArt;

public class ASCIIArtLargeHandler : IASCIIArtHandler
{
    #region Constants
    private const string ASCIICharacter = $"{ASCIIArt.CharacterHead}\n{ASCIIArt.CharacterTorso}\n{ASCIIArt.CharacterLegs}";

    private const string ASCIITreeLayerBranchLeft = ASCIIArt.BranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.NoBranchLarge;
    private const string ASCIITreeLayerBranchRight = ASCIIArt.NoBranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.BranchLarge;
    private const string ASCIITreeLayerNoBranch = ASCIIArt.NoBranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.NoBranchLarge;

    private const string ASCIITreeSegmentBranchLeft = $"""
                                                       {ASCIITreeLayerNoBranch}
                                                       {ASCIITreeLayerNoBranch}
                                                       {ASCIITreeLayerNoBranch}
                                                       {ASCIITreeLayerNoBranch}
                                                       {ASCIITreeLayerBranchLeft}
                                                       {ASCIITreeLayerNoBranch}
                                                       """;
    private const string ASCIITreeSegmentBranchRight = $"""
                                                        {ASCIITreeLayerNoBranch}
                                                        {ASCIITreeLayerNoBranch}
                                                        {ASCIITreeLayerNoBranch}
                                                        {ASCIITreeLayerNoBranch}
                                                        {ASCIITreeLayerBranchRight}
                                                        {ASCIITreeLayerNoBranch}
                                                        """;
    private const string ASCIITreeSegmentNoBranch = $"""
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     """;
    
    private const string ASCIITreeSegmentCharacterRight = $"""
                                                           {ASCIITreeLayerNoBranch}
                                                           {ASCIITreeLayerNoBranch}
                                                           {ASCIITreeLayerNoBranch}
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterHead}   
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterTorso}   
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterLegs}   
                                                           """;
    private const string ASCIITreeSegmentCharacterLeft = $"""
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIITreeLayerNoBranch}
                                                             {ASCIIArt.CharacterHead}   {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                             {ASCIIArt.CharacterTorso}   {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                             {ASCIIArt.CharacterLegs}   {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                          """;
    private const string ASCIITreeSegmentCharacterRightWithBranch = $"""
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterHead}   
                                                                     {ASCIIArt.BranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterTorso}   
                                                                     {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterLegs}   
                                                                     """;
    private const string ASCIITreeSegmentCharacterLeftWithBranch = $"""
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIITreeLayerNoBranch}
                                                                       {ASCIIArt.CharacterHead}   {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                                       {ASCIIArt.CharacterTorso}   {ASCIIArt.TrunckLarge}{ASCIIArt.BranchLarge}
                                                                       {ASCIIArt.CharacterLegs}   {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                                    """;
    #endregion

    public static int TreeHeight => 6;
    public static int TreeHeightInLines => 30; // TreeHeight * 5
    public static int TreeWidthInCharacters => 30;
    public string Trunck => ASCIIArt.TrunckLarge;
    public string Branch => ASCIIArt.BranchLarge;
    public string NoBranch => ASCIIArt.NoBranchLarge;
    public string CharacterHead => ASCIIArt.CharacterHead;
    public string CharacterTorso => ASCIIArt.CharacterTorso;
    public string CharacterLegs => ASCIIArt.CharacterLegs;
    public string Character => ASCIICharacter;
    public string TreeLayerBranchLeft => ASCIITreeLayerBranchLeft;
    public string TreeLayerBranchRight => ASCIITreeLayerBranchRight;
    public string TreeLayerNoBranch => ASCIITreeLayerNoBranch;
    public string TreeSegmentBranchLeft => ASCIITreeSegmentBranchLeft;
    public string TreeSegmentBranchRight => ASCIITreeSegmentBranchRight;
    public string TreeSegmentNoBranch => ASCIITreeSegmentNoBranch;
    public string TreeSegmentCharacterRight => ASCIITreeSegmentCharacterRight;
    public string TreeSegmentCharacterLeft => ASCIITreeSegmentCharacterLeft;
    public string TreeSegmentCharacterRightWithBranch => ASCIITreeSegmentCharacterRightWithBranch;
    public string TreeSegmentCharacterLeftWithBranch => ASCIITreeSegmentCharacterLeftWithBranch;
}