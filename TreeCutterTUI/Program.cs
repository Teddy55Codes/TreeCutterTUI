using Spectre.Console;
using TreeCutterTUI;

public class Program
{
    public static void Main(string[] args)
    {
        var tree = new TreeCutterTUI.Tree(5);

        foreach (string segment in tree)
        {
            AnsiConsole.MarkupLine(segment);
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
            
            if ((bool)res) continue;
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[red]You Lost :([/]");
            break;
        }

        Console.ReadKey();
    }
}