using System.Text.Json.Serialization;

class UserProfile
{
    [JsonInclude]
    private string _username;
    [JsonInclude]
    private double _bestTime;
    [JsonInclude]
    private int _bestMoves;

    public UserProfile() {}

    public UserProfile(string username)
    {
        _username = username;
        _bestTime = 0;
        _bestMoves = 0;
    }

    public void UpdateScore(double time, int moves)
    {
        if (time < _bestTime || _bestTime == 0)
        {
            _bestTime = time;
        }

        if (moves < _bestMoves || _bestMoves == 0)
        {
            _bestMoves = moves;
        }
    }

    public string GetScore()
    {
        return $"Best Time: {_bestTime} seconds  |  Best Moves: {_bestMoves}";
    }

    public string GetName()
    {
        return _username;
    }
}