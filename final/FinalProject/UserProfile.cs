class UserProfile
{
    private string _username;
    private float _bestTime;
    private int _bestMoves;

    public UserProfile(string username)
    {
        _username = username;
        _bestTime = 0;
        _bestMoves = 0;
    }

    public void updateScore(float time, int moves)
    {
        
    }

    public string getScore()
    {
        return "";
    }
}