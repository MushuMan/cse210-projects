using System;
using System.Text.RegularExpressions;


class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<Word> _hidableWords;

    public Scripture(string reference, string text)
    {
        _words = new List<Word>();
        _hidableWords = new List<Word>();
        SetReference(reference);
        SetWords(text);    
    }

    private void SetReference(string reference)
    {
        string book;
        string chapterVerse;
        string[] splitReference = reference.Split(" ");
        if (splitReference.Length > 2)
        {
            book = $"{splitReference[0]} {splitReference[1]}";
            chapterVerse = splitReference[2];
        }
        else
        {
            book = splitReference[0];
            chapterVerse = splitReference[1];
        }
        string[] splitChapterVerse = chapterVerse.Split(":");
        int chapter = int.Parse(splitChapterVerse[0]);
        string verses = splitChapterVerse[1];
        string[] splitVerses = verses.Split("-");
        int startVerse = int.Parse(splitVerses[0]);
        if (splitVerses.Length > 1)
        {
            int endVerse = int.Parse(splitVerses[1]);
            _reference = new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            _reference = new Reference(book, chapter, startVerse);
        }
    }

    private void SetWords(string text)
    {
        var words = Regex.Matches(text, @"\w+['’]?\w*|[^\w\s]");
        foreach (Match word in words)
        {
            Word newWord = new Word(word.Value);
            _words.Add(newWord);
            if (!newWord.IsPunctuation())
            {
                _hidableWords.Add(newWord);
            }
        }
    }

// I made it so that it only picks words from a list of not hidden words that aren't punctuation.
    public void HideRandomWords()
    {
        Random random = new Random();
        int maxHidableWords;
        if (_hidableWords.Count >= 3)
        {
            maxHidableWords = 3;
        }
        else
        {
            maxHidableWords = _hidableWords.Count;
        }

        if (maxHidableWords == 0)
        {
            return;
        }
        int wordAmount = random.Next(1, maxHidableWords);
        for (int i = 1; i <= wordAmount; i++)
        {
            int randomIndex = random.Next(0, _hidableWords.Count);
            Word chosenWord = _hidableWords[randomIndex];
            chosenWord.Hide();
            _hidableWords.Remove(chosenWord);
        }
    }

    public bool IsAllTextHidden()
    {
        if (_hidableWords.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetDisplayText()
    {
        string verses = "";
        int index = 0;
        bool punctuation;
        foreach (Word word in _words)
        {
            if (index + 1 >= _words.Count)
            {
                punctuation = false;
            }
            else
            {
                Word nextWord = _words[index + 1];
                punctuation = nextWord.IsPunctuation();
            }
            if (punctuation)
            {
                verses += $"{word.GetDisplayText()}";
            }
            else
            {
                verses += $"{word.GetDisplayText()} ";
            }
            index ++;
        }
        return verses;
    }

    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }
}