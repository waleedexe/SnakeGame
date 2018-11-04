namespace TokenProvider
{
  public class TokenService : ITokenService
  {
    public Token CreateToken()
    {
      return new Token();
    }

    public void MoveToken(Token token, int spaces)
    {
      if (token == null)
      {
        throw new System.ArgumentNullException(nameof(token));
      }

      if (token.IsMovePastMaxPosition(spaces))
      {
        return;
      }

      token.Move(spaces);
    }

    public int GetPosition(Token token)
    {
      if (token == null)
      {
        throw new System.ArgumentNullException(nameof(token));
      }

      return token.GetPosition();
    }
  }
}
