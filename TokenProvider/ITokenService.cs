namespace TokenProvider
{
  public interface ITokenService
  {
    Token CreateToken();
    void MoveToken(Token token, int spaces);
    int GetPosition(Token token);
  }
}