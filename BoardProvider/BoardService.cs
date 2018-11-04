using System;
using TokenProvider;

namespace BoardProvider
{
  public class BoardService : IBoardService
  {
    private readonly ITokenService _tokenService;
    private Token _token;
    public event EventHandler OnWinEvent;

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

      if (_token.IsWinner())
      {
        // This is normally an message event raised into Game class.
        OnWinEvent?.Invoke(this, null);
      }
    }

    public int GetTokenPosition()
    {
      return _tokenService.GetPosition(_token);
    }
  }
}
