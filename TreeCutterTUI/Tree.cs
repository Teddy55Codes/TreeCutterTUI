using System.Collections;
using System.Text;

namespace TreeCutterTUI;

public class Tree : IEnumerable<string>
{
    private int _treeSegmentCount;
    private Queue<(Direction, string)> _treeSegments = new();
    private Random _random = new();

    public Tree(int height)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        _treeSegmentCount = height;
        InitTree();
    }

    public bool CheckMove(Direction direction) =>
        _treeSegments.First().Item1 switch
        {
            Direction.Right => direction == Direction.Left,
            Direction.Left => direction == Direction.Right,
            Direction.None => true,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    public void InitTree()
    {
        _treeSegments.Clear();
        for (int i = 0; i < _treeSegmentCount; i++)
        {
            AddTreeSegment();
        }
    }
    
    public (Direction, string) MoveTree()
    {
        AddTreeSegment();
        return _treeSegments.Dequeue();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var segment in _treeSegments.Reverse())
        {
            stringBuilder.Append($"{segment.Item2}\n");
        }
        stringBuilder.Append(ASCIIArt.TreeSegmentCharacter);
        
        return stringBuilder.ToString();
    }

    private void AddTreeSegment() => _treeSegments.Enqueue(_random.Next(2) == 0 ? (Direction.Left, ASCIIArt.TreeSegmentBranchLeft) : (Direction.Right, ASCIIArt.TreeSegmentBranchRight));

    private void AddNoBranchTreeSegment() => _treeSegments.Enqueue((Direction.None, ASCIIArt.TreeSegmentNoBranch));

    public IEnumerator<string> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    public struct Enumerator : IEnumerator<string>, IEnumerator
    {
        private Tree _tree;
        private string _current;

        internal Enumerator(Tree tree)
        {
            _tree = tree;
            _current = string.Empty;
        }
        
        public bool MoveNext()
        {
            _tree.MoveTree();
            _current = _tree.ToString();
            return true;
        }

        public void Reset() => _tree.InitTree();

        public string Current => _current;

        object IEnumerator.Current => _current;

        public void Dispose() { }
    }
}