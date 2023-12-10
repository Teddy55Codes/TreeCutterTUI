using System.Collections;
using System.Text;

namespace TreeCutterTUI;

public class Tree : IEnumerable<string>
{
    private int _treeSegmentCount;
    private Queue<string> _treeSegments = new Queue<string>();
    private Random _random = new Random();

    public Tree(int height)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        _treeSegmentCount = height;
        InitTree();
    }
    
    public void InitTree()
    {
        _treeSegments.Clear();
        for (int i = 0; i < _treeSegmentCount; i++)
        {
            AddTreeSegment();
        }
    }
    
    public string MoveTree()
    {
        AddTreeSegment();
        return _treeSegments.Dequeue();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var segment in _treeSegments.Reverse())
        {
            stringBuilder.Append($"{segment}\n");
        }
        stringBuilder.Append($"""
                              {ASCIIArt.TreeSegmentNoBranch}
                              {ASCIIArt.TreeSegmentNoBranch}
                              {ASCIIArt.NoBranch}{ASCIIArt.Trunck}{ASCIIArt.CharacterHead}
                              {ASCIIArt.NoBranch}{ASCIIArt.Trunck}{ASCIIArt.CharacterTorso}
                              {ASCIIArt.NoBranch}{ASCIIArt.Trunck}{ASCIIArt.CharacterLegs}
                              """);
        
        return stringBuilder.ToString();
    }

    private void AddTreeSegment()
    {
        if (_random.Next(2) == 0)
        {
            _treeSegments.Enqueue($"""
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentBranchLeft}
                                       """);
        }
        else
        {
            _treeSegments.Enqueue($"""
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentNoBranch}
                                       {ASCIIArt.TreeSegmentBranchRight}
                                       """);
        }
    }

    private void AddNoBranchTreeSegment()
    {
        _treeSegments.Enqueue($"""
                               {ASCIIArt.TreeSegmentNoBranch}
                               {ASCIIArt.TreeSegmentNoBranch}
                               {ASCIIArt.TreeSegmentNoBranch}
                               {ASCIIArt.TreeSegmentNoBranch}
                               {ASCIIArt.TreeSegmentNoBranch}
                               """);
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