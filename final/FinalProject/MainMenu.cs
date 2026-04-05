using System.IO;
using System.Text.Json;

class MainMenu
{
    private List<UserProfile> _profiles;
    private UserProfile _currentProfile;
    private DateTime _startTime;
    private DateTime _endTime;
    private TimeSpan _elapsedTime;

    public MainMenu()
    {
        _profiles = new List<UserProfile>();
        LoadPlayersFromFile("players.json");
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            if (_currentProfile != null)
            {
                Console.WriteLine($"Current Profile: {_currentProfile.GetName()}");
            }
            else
            {
                Console.WriteLine("No Profile Selected");
            }
            Console.WriteLine();
            Console.WriteLine("Welcome to the A'Maze'ing Game!");
            Console.WriteLine();
            Console.WriteLine("Please pick an option below: ");
            Console.WriteLine("1. Load Profile");
            Console.WriteLine("2. Create new Profile");
            Console.WriteLine("3. Play game");
            Console.WriteLine("4. View High Scores");
            Console.WriteLine("5. Quit");
            Console.Write("> ");
            string input = Console.ReadLine();
            
            int selection = SelectOption(input);
            ProcessOption(selection);
        }
    }

    private int SelectOption(string input)
    {
        if(int.TryParse(input, out int selection))
        {
            return selection;
        }
        else
        {
            return 0;
        }
    }

    private void ProcessOption(int selection)
    {
        if (selection == 1)
        {
            LoadPlayers();
        }
        else if (selection == 2)
        {
            CreateUserProfile();
        }
        else if (selection == 3)
        {
            StartGame();
        }
        else if (selection == 4)
        {
            ShowScores();
        }
        else if (selection == 5)
        {
            QuitProgram();
        }
        else
        {
            Console.WriteLine("Invalid option, please try again.");
            Thread.Sleep(3000);
        }
    }

    private void StartGame()
    {
        Console.Clear();
        if (_currentProfile != null)
        {
            _startTime = DateTime.Now;
            int mazeWidth = 21;
            int mazeHeight = 21;
            Maze maze = new Maze(mazeWidth, mazeHeight);

            CharacterTile character = new CharacterTile(0, 0, false, mazeWidth, mazeHeight);

            InputHandler input = new InputHandler();

            WindowManager mainWindow = new WindowManager(mazeWidth, mazeHeight);
            mainWindow.SetMaze(maze);
            mainWindow.SetCharacter(character);
            mainWindow.SetInput(input);
            mainWindow.StartWindow();
            _endTime = DateTime.Now;
            _elapsedTime = _endTime - _startTime;
            SaveScore(character);
        }
        else
        {
            Console.WriteLine("No profile selected, returning to menu.");
            Thread.Sleep(3000);
        }
    }

    private void SaveScore(CharacterTile character)
    {
        _currentProfile.UpdateScore(_elapsedTime.TotalSeconds, character.GetMoves());
    }

    private void ShowScores()
    {
        Console.Clear();
        foreach (UserProfile profile in _profiles)
        {
            Console.WriteLine($"{profile.GetName()}");
            Console.WriteLine($"{profile.GetScore()}");
            Console.WriteLine();
        }
        Console.WriteLine("Press enter to return to menu.");
        Console.ReadLine();
    }

    private void CreateUserProfile()
    {
        Console.Clear();
        Console.Write("Please enter username: ");
        string username = Console.ReadLine();
        UserProfile newProfile = new UserProfile(username);
        _profiles.Add(newProfile);
        return;
    }

    private void SavePlayersToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_profiles);
        File.WriteAllText(filename, json);
    }

    private void LoadPlayersFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            _profiles = JsonSerializer.Deserialize<List<UserProfile>>(json);
        }
    }

    private void LoadPlayers()
    {
        while (true)
        {
            Console.Clear();
            
            if (_profiles.Count == 0)
            {
                Console.WriteLine("No saves detected, returning to menu.");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("Please select player: ");
            for (int i = 0; i < _profiles.Count; i++)
            {
                Console.WriteLine($"    {i + 1}. {_profiles[i].GetName()}");
            }
            Console.WriteLine();
            Console.Write("> ");

            string input = Console.ReadLine();
            int selection = CheckSelection(input, _profiles.Count);

            if (selection != 0)
            {
                _currentProfile = _profiles[selection - 1];
                return;
            }
            else
            {
                Console.WriteLine("Save does not exist, please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    private int CheckSelection(string input, int maxNum)
    {
        int.TryParse(input, out int selection);
        if (selection > 0 && selection <= maxNum)
        {
            return selection;
        }
        else
        {
            return 0;
        }
    }

    private void QuitProgram()
    {
        SavePlayersToFile("players.json");
        Environment.Exit(0);
    }
}