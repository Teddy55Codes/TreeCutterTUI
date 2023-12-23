using System.Collections;
using System.Text;
using TreeCutterTUI.ASCIIArt;

namespace TreeCutterTUI;

public class Tree : IEnumerable<string>
{
    private readonly IASCIIArtHandler _asciiArtHandler;
    private readonly int _treeSegmentCount;
    private Direction _characterDirection = Direction.Right;
    private Direction _lastDirectionalBranch = Direction.None;
    private Queue<(Direction, string)> _treeSegments = new();
    private Random _random = new();

    public Tree(int height, IASCIIArtHandler asciiArtHandler)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        _treeSegmentCount = height;
        _asciiArtHandler = asciiArtHandler;
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
                stringBuilder.Append(_asciiArtHandler.TreeSegmentCharacterRightWithBranch);
                break;
            case Direction.Right:
                stringBuilder.Append(_asciiArtHandler.TreeSegmentCharacterLeftWithBranch);
                break;
            case Direction.None:
                stringBuilder.Append(_characterDirection == Direction.Right ? _asciiArtHandler.TreeSegmentCharacterRight : _asciiArtHandler.TreeSegmentCharacterLeft);
                break;
        }
        
        return stringBuilder.ToString();
    }

    private void AddTreeSegment()
    {
        if (_treeSegments.Count == 0)
        {
            _treeSegments.Enqueue((Direction.None, _asciiArtHandler.TreeSegmentNoBranch));
            return;
        }
        
        var lastSegmentDirection = _treeSegments.Last().Item1;
        switch (lastSegmentDirection)
        {
            case Direction.None:
                var direction = PickRandomItemWeighted(
                [
                    (Direction.None, 25),
                    (Direction.Left, _lastDirectionalBranch == Direction.Left ? 50 : 25),
                    (Direction.Right, _lastDirectionalBranch == Direction.Right ? 50 : 25)
                ]);
                switch (direction)
                {
                    case Direction.Left:
                        _treeSegments.Enqueue((Direction.Left, _asciiArtHandler.TreeSegmentBranchLeft));
                        _lastDirectionalBranch = Direction.Left;
                        break;
                    case Direction.Right:
                        _treeSegments.Enqueue((Direction.Right, _asciiArtHandler.TreeSegmentBranchRight));
                        _lastDirectionalBranch = Direction.Right;
                        break;
                    case Direction.None:
                        _treeSegments.Enqueue((Direction.None, _asciiArtHandler.TreeSegmentNoBranch));
                        break;
                }
                break;
            case Direction.Right:
                if (_random.Next(2) == 0)
                {
                    _treeSegments.Enqueue((Direction.None, _asciiArtHandler.TreeSegmentNoBranch));
                }
                else
                {
                    _treeSegments.Enqueue((Direction.Right, _asciiArtHandler.TreeSegmentBranchRight));
                    _lastDirectionalBranch = Direction.Right;
                }
                
                break;
            case Direction.Left:
                if (_random.Next(2) == 0)
                {
                    _treeSegments.Enqueue((Direction.None, _asciiArtHandler.TreeSegmentNoBranch));
                }
                else
                {
                    _treeSegments.Enqueue((Direction.Left, _asciiArtHandler.TreeSegmentBranchLeft));
                    _lastDirectionalBranch = Direction.Left;
                }
                break;
        }
    }

    private void AddNoBranchTreeSegment() => _treeSegments.Enqueue((Direction.None, _asciiArtHandler.TreeSegmentNoBranch));

    public static T PickRandomItemWeighted<T>(IList<(T Item, int Weight)> items)
    {
        if ((items?.Count ?? 0) == 0)
        {
            return default;
        }

        int offset = 0;
        (T Item, int RangeTo)[] rangedItems = items
            .OrderBy(item => item.Weight)
            .Select(entry => (entry.Item, RangeTo: offset += entry.Weight))
            .ToArray();

        int randomNumber = new Random().Next(items.Sum(item => item.Weight)) + 1;
        return rangedItems.First(item => randomNumber <= item.RangeTo).Item;
    }
    
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