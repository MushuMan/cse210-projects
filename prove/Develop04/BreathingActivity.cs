class BreathingActivity : Activity
{
    private int _breatheInTime;
    private int _breatheOutTime;
    private int _breathHoldTime;
    private int _cycleTime;

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breatheInTime = 5;
        _breatheOutTime = 5;
        _breathHoldTime = 2;
        _cycleTime = _breatheInTime + _breatheOutTime + (_breathHoldTime * 2);
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(3);

        int cycles = _duration / _cycleTime;
        if (cycles == 0)
        {
            cycles = 1;
        }

        for (int i = 0; i < cycles; i++)
        {
            Console.Clear();
            BreatheIn(_breatheInTime);
            BreathHold(_breathHoldTime);
            BreatheOut(_breatheOutTime);
            BreathHold(_breathHoldTime);
        }

        Console.Clear();
        DisplayEndingMessage();
        ShowSpinner(5);
    }

    private void BreatheIn(int seconds)
    {
        Console.Write("Breathe in...");
        ShowCountdown(seconds);
        Console.WriteLine();
    }

    private void BreatheOut(int seconds)
    {
        Console.Write("Breathe out...");
        ShowCountdown(seconds);
        Console.WriteLine();
    }

    private void BreathHold(int seconds)
    {
        Console.Write("Hold...");
        ShowCountdown(seconds);
        Console.WriteLine();
    }
}