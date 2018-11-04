using TokenProvider;

namespace BoardProvider
{
  public class BoardService : IBoardService
  {
    private readonly ITokenService _tokenService;
    private Token _token;

    public BoardService(ITokenService tokenService)
    {
      _tokenService = tokenService;
    }

    public void NewGame()
    {
      _token = null;
    }

    public void AddToken()
    {
      _token = _tokenService.CreateToken();
    }

    public void MoveToken(int diceNumber)
    {
      _tokenService.MoveToken(_token, diceNumber);
    }
  }
}
