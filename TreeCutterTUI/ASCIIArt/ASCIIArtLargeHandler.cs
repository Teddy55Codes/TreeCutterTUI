namespace TreeCutterTUI.ASCIIArt;

public class ASCIIArtLargeHandler : IASCIIArtHandler
{
     #region Constants
    private const string ASCIICharacter = $"{ASCIIArt.CharacterHeadLarge}\n{ASCIIArt.CharacterTorsoLarge}\n{ASCIIArt.CharacterLegsLarge}";

    private const string ASCIITreeLayerBranchLeft = ASCIIArt.BranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.NoBranchLarge;
    private const string ASCIITreeLayerBranchRight = ASCIIArt.NoBranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.BranchLarge;
    private const string ASCIITreeLayerNoBranch = ASCIIArt.NoBranchLarge + ASCIIArt.TrunckLarge + ASCIIArt.NoBranchLarge;

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
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterHeadLarge}
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterTorsoLarge}
                                                           {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterLegsLarge}
                                                           """;
    private const string ASCIITreeSegmentCharacterLeft = $"""
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIITreeLayerNoBranch}
                                                          {ASCIIArt.CharacterHeadLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                          {ASCIIArt.CharacterTorsoLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                          {ASCIIArt.CharacterLegsLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                          """;
    private const string ASCIITreeSegmentCharacterRightWithBranch = $"""
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIITreeLayerNoBranch}
                                                                     {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterHeadLarge}
                                                                     {ASCIIArt.BranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterTorsoLarge}
                                                                     {ASCIIArt.NoBranchLarge}{ASCIIArt.TrunckLarge}  {ASCIIArt.CharacterLegsLarge}
                                                                     """;
    private const string ASCIITreeSegmentCharacterLeftWithBranch = $"""
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIITreeLayerNoBranch}
                                                                    {ASCIIArt.CharacterHeadLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                                    {ASCIIArt.CharacterTorsoLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.BranchLarge}
                                                                    {ASCIIArt.CharacterLegsLarge}  {ASCIIArt.TrunckLarge}{ASCIIArt.NoBranchLarge}
                                                                    """;
    #endregion
    
    public string Trunck => ASCIIArt.TrunckLarge;
    public string Branch => ASCIIArt.BranchLarge;
    public string NoBranch => ASCIIArt.NoBranchLarge;
    public string CharacterHead => ASCIIArt.CharacterHeadLarge;
    public string CharacterTorso => ASCIIArt.CharacterTorsoLarge;
    public string CharacterLegs => ASCIIArt.CharacterLegsLarge;
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