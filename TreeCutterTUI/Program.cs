using TreeCutterTUI;

public class Program
{
    public static void Main(string[] args)
    {
        var tree = new TreeCutterTUI.Tree(5);

        foreach (var segment in tree)
        {
            Console.WriteLine(segment);
            bool? res = null;
            while (res == null)
            {
                res = Console.ReadKey().Key switch
                {
                    ConsoleKey.A or ConsoleKey.LeftArrow => tree.CheckMove(Direction.Left),
                    ConsoleKey.D or ConsoleKey.RightArrow => tree.CheckMove(Direction.Right),
                    _ => null
                };
            }
            if (!(bool)res) break;
        }
    }
}