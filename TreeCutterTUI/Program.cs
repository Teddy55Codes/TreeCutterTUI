using Spectre.Console;
using TreeCutterTUI.ASCIIArt;

namespace TreeCutterTUI;

public abstract class Program
{
    private static IASCIIArtHandler _asciiArtHandler; 
    private static int _treeWidthInCharacters;
    private static int _treeHeightInLines;
    private static int _score;
    private static int _currentHealth;
    private static object _cursorLock = new();
    private static CancellationTokenSource? _cancellationTokenSource;
    
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
            _currentHealth = 100;
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(HealthBar);
            await GameLoop();
            string choice;
            lock (_cursorLock)
            {
                AnsiConsole.Clear();
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string> { HighlightStyle = new Style(Color.Green) }
                        .Title($"[red]You Lost :([/]\n[yellow]Score: {_score}[/]")
                        .PageSize(3)
                        .AddChoices("Play Again", "Quit"));
            }
            if (choice == "Quit") break;
            AnsiConsole.Cursor.Hide();
        }
    }

    private static async Task GameLoop()
    {
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

            if (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                _score++;
                if (_currentHealth < 100) _currentHealth++;
                if (res is true) continue;
            }
            
            await _cancellationTokenSource.CancelAsync();
            break;
        }
    }

    private static async void HealthBar()
    {
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
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
                await _cancellationTokenSource.CancelAsync();
            }

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(.8), _cancellationTokenSource.Token);
            }
            catch (TaskCanceledException) { }
        }
    }
    
    private static async Task<ConsoleKeyInfo> WaitForKey(CancellationToken token)
    {
        while (!token.IsCancellationRequested) {
            if (Console.KeyAvailable) {
                return Console.ReadKey(true);
            }

            try
            {
                await Task.Delay(50, token);
            }
            catch (TaskCanceledException) { }
        }
        return new ConsoleKeyInfo((char)0, 0, false, false, false);
    }
}