public class Prompt
{
    public List<string> _promptList;

    public Prompt()
    {
        _promptList = new List<string>
        {
          "Who was the most interesting person I interacted with today?",
          "What was the best part of my day?",
          "How did I see the hand of the Lord in my life today?",
          "What was the strongest emotion I felt today?",
          "If I had one thing I could do over today, what would it be?",
          "What am I looking forward to the most tomorrow?",
          "How have I helped someone else today?",
          "What new and interesting thing did I learn today?",
          "How can I improve myself for tomorrow?"  
        };
    }

    public string GeneratePrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_promptList.Count);
        return _promptList[index];
    }
}