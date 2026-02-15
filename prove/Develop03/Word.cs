using System.Text.RegularExpressions;

class Word
{
    private string _text;
    private bool _hidden;
    private string _hiddenText;
    private bool _punctuation;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
        _punctuation = !Regex.IsMatch(text, @"\w");
        CreateHiddenText();
    }

    private void CreateHiddenText()
    {
        if (!_punctuation)
        {
            int wordLength = _text.Length;
            _hiddenText = new string('_', wordLength);
        }
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

// Used to check if the string is punctuation so that it doesn't get hidden.
    public bool IsPunctuation()
    {
        return _punctuation;
    }

    public string GetDisplayText()
    {
        if (_hidden)
        {
            return _hiddenText;
        }
        else
        {
            return _text;
        }
    }
}