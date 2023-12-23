namespace TreeCutterTUI.ASCIIArt;

public interface IASCIIArtHandler
{
    public static abstract int TreeHeight { get; }
    public static abstract int TreeHeightInLines { get; }
    public static abstract int TreeWidthInCharacters { get; }
    
    public string Trunck { get; }
    public string Branch { get; }
    public string NoBranch { get; }
    public string CharacterHead { get; }
    public string CharacterTorso { get; }
    public string CharacterLegs { get; }
    public string Character { get; }

    public string TreeLayerBranchLeft { get; }
    public string TreeLayerBranchRight { get; }
    public string TreeLayerNoBranch { get; }

    public string TreeSegmentBranchLeft { get; }
    public string TreeSegmentBranchRight { get; }
    public string TreeSegmentNoBranch { get; }

    public string TreeSegmentCharacterRight { get; }
    public string TreeSegmentCharacterLeft { get; }
    public string TreeSegmentCharacterRightWithBranch { get; }
    public string TreeSegmentCharacterLeftWithBranch { get; }
}