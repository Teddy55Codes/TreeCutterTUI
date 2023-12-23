using Spectre.Console;
using TreeCutterTUI.ASCIIArt;

namespace TreeCutterTUI;

public abstract class Program
{
    private static IASCIIArtHandler _asciiArtHandler; 
    private static int _treeWidthInCharacters;
    private static int _treeHeightInLines;
    private static int _score;
    private static bool _progressStopped;
    private static int _currentHealth;
    private static object _cursorLock = new();
    private static CancellationTokenSource _cancellationTokenSource;
    
    public static async Task Main()
    {
        if (Console.WindowWidth >= ASCIIArtLargeHandler.TreeWidthInCharacters && Console.WindowHeight >= ASCIIArtLargeHandler.TreeHeightInLines + 2)
        {
            _asciiArtHandler = new ASCIIArtLargeHandler();
            _treeWidthInCharacters = ASCIIArtLargeHandler.TreeWidthInCharacters;
            _treeHeightInLines = ASCIIArtLargeHandler.TreeHeightInLines;
        }
        else
        {
            _asciiArtHandler = new ASCIIArtSmallHandler();
            _treeWidthInCharacters = ASCIIArtSmallHandler.TreeWidthInCharacters;
            _treeHeightInLines = ASCIIArtSmallHandler.TreeHeightInLines;
        }
        
        AnsiConsole.Cursor.Hide();
        AnsiConsole.Write(
            new FigletText("Wood Cutter TUI")
                .Centered()
                .Color(Color.Gold3_1));
        Console.ReadKey();
        AnsiConsole.Clear();
        
        while (true)
        {
            _score = 0;
            _progressStopped = false;
            _currentHealth = 100;
            Task.Run(HealthBar);
            await GameLoop();
            string choice;
            lock (_cursorLock)
            {
                AnsiConsole.Clear();
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string> { HighlightStyle = new Style(Color.Green) }
                        .Title("[red]You Lost :([/]")
                        .PageSize(3)
                        .AddChoices("Play Again", "Quit"));
            }
            if (choice == "Quit") break;
            AnsiConsole.Cursor.Hide();
        }
    }

    private static async Task GameLoop()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        var tree = new Tree(_asciiArtHandler);
        foreach (string segment in tree)
        {
            lock (_cursorLock)
            {
                AnsiConsole.Cursor.SetPosition(0, 0);
                AnsiConsole.Markup(segment);
                AnsiConsole.Write("\n" + _score);
            }

            bool? res = null;
            while (res == null && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                res = (await WaitForKey(_cancellationTokenSource.Token)).Key switch
                {
                    ConsoleKey.A or ConsoleKey.LeftArrow => tree.CheckMove(Direction.Left),
                    ConsoleKey.D or ConsoleKey.RightArrow => tree.CheckMove(Direction.Right),
                    _ => null
                };
            }

            _score++;
            if (_currentHealth < 100) _currentHealth++;
            if ((bool)res && !_cancellationTokenSource.Token.IsCancellationRequested) continue;
            _progressStopped = true;
            break;
        }
    }

    private static async void HealthBar()
    {
        while (!_progressStopped)
        {
            lock (_cursorLock)
            {
                AnsiConsole.Cursor.SetPosition(0, _treeHeightInLines + 2);
                AnsiConsole.Write(new BreakdownChart()
                    .HideTagValues()
                    .HideTags()
                    .Width(_treeWidthInCharacters)
                    .AddItem(string.Empty, _currentHealth, Color.Red)
                    .AddItem(string.Empty, 100 - _currentHealth, Color.Grey));
            }
            _currentHealth -= 5;
            if (_currentHealth <= 0)
            {
                _progressStopped = true;
                await _cancellationTokenSource.CancelAsync();
            }
            await Task.Delay(TimeSpan.FromSeconds(.8), _cancellationTokenSource.Token);
        }
    }
    
    private static async Task<ConsoleKeyInfo> WaitForKey(CancellationToken token)
    {
        while (!token.IsCancellationRequested) {
            if (Console.KeyAvailable) {
                return Console.ReadKey();
            }
            await Task.Delay(50, token);
        }
        return new ConsoleKeyInfo((char)0, 0, false, false, false);
    }
}