using System.Text.Json;
using System.IO;
class Menu
{
    // Added the ability to have multiple users as players.
    private List<Player> _players;
    // User is able to select a current user and switch between them.
    private Player _currentPlayer;
    public Menu()
    {
        _players = new List<Player>();
    }

    // Lets the user create a new account or load an already existing one. Quitting at any point in the program will automatically save each player.
    // On startup the program will automatically load all saved players with each player's respective goals and score.
    public void StartProgram()
    {
        LoadPlayersFromFile("players.json");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Eternal Quest!");
            Console.WriteLine();
            Console.WriteLine("Program Options: ");
            Console.WriteLine("   1. Create new save");
            Console.WriteLine("   2. Load save");
            Console.WriteLine("   3. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            int selection = CheckSelection(input, 3);

            if (selection != 0)
            {
                if (selection == 1)
                {
                    CreatePlayer();
                }
                else if (selection == 2)
                {
                    LoadPlayers();
                }
                else
                {
                    QuitProgram();
                }
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Not valid option, please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    // Here and in the Player class I check the inputs to make sure that they are within correct parameters.
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

    private void CreatePlayer()
    {
        Console.Write("Please enter name: ");
        string name = Console.ReadLine();
        Player newPlayer = new Player(name);
        _players.Add(newPlayer);
        _currentPlayer = newPlayer;
    }

    private void SavePlayersToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_players);
        File.WriteAllText(filename, json);
    }

    private void LoadPlayersFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            _players = JsonSerializer.Deserialize<List<Player>>(json);
        }
    }

    private void LoadPlayers()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please select player: ");
            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"    {i + 1}. {_players[i].GetName()}");
            }
            Console.WriteLine();
            Console.Write("> ");

            string input = Console.ReadLine();
            int selection = CheckSelection(input, _players.Count);

            if (selection != 0)
            {
                _currentPlayer = _players[selection - 1];
                return;
            }
            else
            {
                Console.WriteLine("Save does not exist, please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    // Saving and loading are not options since the program handles that automatically.
    private void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Hello {_currentPlayer.GetName()}!");
            Console.WriteLine($"You have {_currentPlayer.GetScore()} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Record Event");
            Console.WriteLine("   4. Main Menu");
            Console.WriteLine("   5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string input = Console.ReadLine();
            int selection = CheckSelection(input, 5);
            if (selection != 0)
            {
                if (selection == 1)
                {
                    _currentPlayer.CreateGoal();
                }
                else if (selection == 2)
                {
                    _currentPlayer.DisplayGoals();
                }
                else if (selection == 3)
                {
                    _currentPlayer.RecordEvent();
                }
                else if (selection == 4)
                {
                    return;
                }
                else
                {
                    QuitProgram();
                }
            }
            else
            {
                Console.WriteLine("Not valid option, please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    // Automatically saves the current list of players (which has a list of goals for each respective player) to a json file when quitting.
    private void QuitProgram()
    {
        SavePlayersToFile("players.json");
        Environment.Exit(0);
    }
}