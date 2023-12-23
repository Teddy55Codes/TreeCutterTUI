namespace TreeCutterTUI.ASCIIArt;

public class ACIIArtSmallHandler : IASCIIArtHandler
{
    #region Constants
    private const string ASCIICharacter = $"{ASCIIArt.CharacterHeadSmall}\n{ASCIIArt.CharacterTorsoSmall}\n{ASCIIArt.CharacterLegsSmall}";

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
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterHeadSmall}
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterTorsoSmall}
                                                           {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterLegsSmall}
                                                           """;
    private const string ASCIITreeSegmentCharacterLeft = $"""
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIIArt.CharacterHeadSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          {ASCIIArt.CharacterTorsoSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          {ASCIIArt.CharacterLegsSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                          """;
    private const string ASCIITreeSegmentCharacterRightWithBranch = $"""
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterHeadSmall}
                                                                     {ASCIIArt.BranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterTorsoSmall}
                                                                     {ASCIIArt.NoBranchSmall}{ASCIIArt.TrunckSmall}  {ASCIIArt.CharacterLegsSmall}
                                                                     """;
    private const string ASCIITreeSegmentCharacterLeftWithBranch = $"""
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIIArt.CharacterHeadSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                                    {ASCIIArt.CharacterTorsoSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.BranchSmall}
                                                                    {ASCIIArt.CharacterLegsSmall}  {ASCIIArt.TrunckSmall}{ASCIIArt.NoBranchSmall}
                                                                    """;
    #endregion
    
    public string Trunck => ASCIIArt.TrunckSmall;
    public string Branch => ASCIIArt.BranchSmall;
    public string NoBranch => ASCIIArt.NoBranchSmall;
    public string CharacterHead => ASCIIArt.CharacterHeadSmall;
    public string CharacterTorso => ASCIIArt.CharacterTorsoSmall;
    public string CharacterLegs => ASCIIArt.CharacterLegsSmall;
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