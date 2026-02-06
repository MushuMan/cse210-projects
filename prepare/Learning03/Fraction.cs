class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetFractionTop()
    {
        return _top;
    }

    public int GetFractionBottom()
    {
        return _bottom;
    }

    public void SetFraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public void SetFractionTop(int top)
    {
        _top = top;
    }

    public void SetFractionBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetFractionDecimal()
    {
        return (double)_top / (double)_bottom;
    }
}