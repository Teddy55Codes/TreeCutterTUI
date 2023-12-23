namespace TreeCutterTUI.ASCIIArt;

public class ASCIIArtSmallHandler : IASCIIArtHandler
{
    #region Constants
    private const string ASCIICharacter = $"{ASCIIArt.CharacterHead}\n{ASCIIArt.CharacterTorso}\n{ASCIIArt.CharacterLegs}";

    private const string ASCIITreeLayerBranchLeft = ASCIIArt.BranchSmall + ASCIIArt.TrunckSmall + ASCIIArt.NoBranchSmall;
    private const string ASCIITreeLayerBranchRight = ASCIIArt.NoBranchSmall + ASCIIArt.TrunckSmall + ASCIIArt.BranchSmall;
    private const string ASCIITreeLayerNoBranch = ASCIIArt.NoBranchSmall + ASCIIArt.TrunckSmall + ASCIIArt.NoBranchSmall;

    private const string ASCIITreeSegmentBranchLeft = $"""
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
                                                        {ASCIITreeLayerBranchRight}
                                                        {ASCIITreeLayerNoBranch}
                                                        """;
    private const string ASCIITreeSegmentNoBranch = $"""
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     {ASCIITreeLayerNoBranch}
                                                     """;
    
    private const string ASCIITreeSegmentCharacterRight = $"""
                                                           {ASCIITreeLayerNoBranch}
                                                           {ASCIITreeLayerNoBranch}
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterHead}
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterTorso}
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterLegs}
                                                           """;
    private const string ASCIITreeSegmentCharacterLeft = $"""
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIIArt.CharacterHead}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          {ASCIIArt.CharacterTorso}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          {ASCIIArt.CharacterLegs}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          """;
    private const string ASCIITreeSegmentCharacterRightWithBranch = $"""
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterHead}
                                                                     {ASCIIArt.BranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterTorso}
                                                                     {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterLegs}
                                                                     """;
    private const string ASCIITreeSegmentCharacterLeftWithBranch = $"""
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIIArt.CharacterHead}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                                    {ASCIIArt.CharacterTorso}  {ASCIIArt.TrunckSmall}{ASCIIArt.BranchSmall}
                                                                    {ASCIIArt.CharacterLegs}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                                    """;
    #endregion

    public static int TreeHeight => 5;
    public static int TreeHeightInLines => 25; // TreeHeight * 5
    public static int TreeWidthInCharacters => 17;
    public string Trunck => ASCIIArt.TrunckSmall;
    public string Branch => ASCIIArt.BranchSmall;
    public string NoBranch => ASCIIArt.NoBranchSmall;
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