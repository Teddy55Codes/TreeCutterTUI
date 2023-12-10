using System.Collections;
using System.Text;

namespace TreeCutterTUI;

public class Tree : IEnumerable<string>
{
    private int _treeSegmentCount;
    private Direction _characterDirection = Direction.Right;
    private Queue<(Direction, string)> _treeSegments = new();
    private Random _random = new();

    public Tree(int height)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        _treeSegmentCount = height;
        InitTree();
    }

    public bool CheckMove(Direction direction)
    {
        _characterDirection = direction;
        var enumerator = _treeSegments.GetEnumerator();
        enumerator.MoveNext();
        var currentSegment = enumerator.Current.Item1;
        enumerator.MoveNext();
        var nextSegment = enumerator.Current.Item1;
        enumerator.Dispose();
        
        return direction switch
        {
            Direction.Right => currentSegment is Direction.Left or Direction.None && nextSegment is Direction.Left or Direction.None,
            Direction.Left => currentSegment is Direction.Right or Direction.None && nextSegment is Direction.Right or Direction.None,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
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
        var i = 0;
        foreach (var segment in _treeSegments.Reverse())
        {
            if (i == _treeSegmentCount-1) break;
            stringBuilder.Append($"{segment.Item2}\n");
            i++;
        }
        var lowestSegmentDirection = _treeSegments.First().Item1;
        
        switch (lowestSegmentDirection)
        {
            case Direction.Left:
                stringBuilder.Append(ASCIIArt.TreeSegmentCharacterRightWithBranch);
                break;
            case Direction.Right:
                stringBuilder.Append(ASCIIArt.TreeSegmentCharacterLeftWithBranch);
                break;
            case Direction.None:
                stringBuilder.Append(_characterDirection == Direction.Right ? ASCIIArt.TreeSegmentCharacterRight : ASCIIArt.TreeSegmentCharacterLeft);
                break;
        }
        
        return stringBuilder.ToString();
    }

    private void AddTreeSegment()
    {
        if (_treeSegments.Count == 0)
        {
            _treeSegments.Enqueue((Direction.None, ASCIIArt.TreeSegmentNoBranch));
            return;
        }
        var lastSegmentDirection = _treeSegments.Last().Item1;
        switch (lastSegmentDirection)
        {
            case Direction.None:
                switch (_random.Next(5))
                {
                    case 0 or 1:
                        _treeSegments.Enqueue((Direction.Left, ASCIIArt.TreeSegmentBranchLeft));
                        break;
                    case 2 or 3:
                        _treeSegments.Enqueue((Direction.Right, ASCIIArt.TreeSegmentBranchRight));
                        break;
                    case 4:
                        _treeSegments.Enqueue((Direction.None, ASCIIArt.TreeSegmentNoBranch));
                        break;
                }
                break;
            case Direction.Right:
                _treeSegments.Enqueue(_random.Next(2) == 0 ? (Direction.None, ASCIIArt.TreeSegmentNoBranch) : (Direction.Right, ASCIIArt.TreeSegmentBranchRight));
                break;
            case Direction.Left:
                _treeSegments.Enqueue(_random.Next(2) == 0 ? (Direction.None, ASCIIArt.TreeSegmentNoBranch) : (Direction.Left, ASCIIArt.TreeSegmentBranchLeft));
                break;
        }
    }

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