using Spectre.Console;

namespace TreeCutterTUI;

public abstract class Program
{
    public static void Main()
    {
        while (true)
        {
            GameLoop();
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>() { HighlightStyle = new Style(Color.Green) }
                    .Title("[red]You Lost :([/]")
                    .PageSize(3)
                    .AddChoices("Play Again", "Quit"));
            if (choice == "Quit") break;
        }
    }

    private static void GameLoop()
    {
        var tree = new Tree(5);
        foreach (string segment in tree)
        {
            AnsiConsole.Cursor.SetPosition(0, 0);
            AnsiConsole.Markup(segment);
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