using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void GenerateEntry()
    {
        DateTime currentTime = DateTime.Now;
        string today = currentTime.ToShortDateString();

        Prompt newPrompt = new Prompt();
        string prompt = newPrompt.GeneratePrompt();
        Console.WriteLine(prompt);

        string response = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._date = today;
        newEntry._prompt = prompt;
        newEntry._response = response;

        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry._date);
            Console.WriteLine(entry._prompt);
            Console.WriteLine(entry._response);
            Console.WriteLine();
        }
    }

    public void SavetoFile()
    {
       Console.Write("Please enter file name: ");
       string filename = Console.ReadLine().Replace(" ", "") + ".txt";

       using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}---Part---{entry._prompt}---Part---{entry._response}");
            }
        }
    }

    public void LoadFromFile()
    {
        Console.WriteLine("Loading new file will clear existing entries, are you sure: (y/n)");
        string response = Console.ReadLine().ToLower();

        if (response == "y")
        {
            _entries.Clear();

            Console.Write("Please enter file name: ");
            string filename = Console.ReadLine().Replace(" ", "") + ".txt";

            if (File.Exists(filename))
            {
                string[] lines = System.IO.File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split("---Part---");
                    Entry newEntry = new Entry();
                    newEntry._date = parts[0];
                    newEntry._prompt = parts[1];
                    newEntry._response = parts[2];
                    _entries.Add(newEntry);
                }

                Console.WriteLine("File loaded Successfully!");
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}