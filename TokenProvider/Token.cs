namespace TokenProvider
{
  public class Token
  {
    private int _position;
    const int MaxPosition = 100;

    public Token()
    {
      _position = 1;
    }

    internal void Move(int spaces)
    {
      _position += spaces;
    }

    internal bool IsMovePastMaxPosition(int spaces)
    {
      return (_position + spaces > MaxPosition);
    }

    internal int GetPosition()
    {
      return _position;
    }

    public bool IsWinner()
    {
      return _position == MaxPosition;
    }
  }
}
