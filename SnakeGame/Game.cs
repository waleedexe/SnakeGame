using BoardProvider;
using DiceProvider;
using System;

namespace SnakeGame
{
  public class Game : IDisposable
  {
    private readonly IBoardService _boardService;
    private readonly IDiceService _diceService;
    private bool _hasWon;

    public Game(IBoardService boardService, IDiceService diceService)
    {
      _boardService = boardService;
      _diceService = diceService;
      _boardService.OnWinEvent += _boardService_OnWinEvent;
    }

    public void NewGame()
    {
      _boardService.NewGame();
    }

    public void AddNewToken()
    {
      _boardService.AddToken();
    }

    public void RollDice()
    {
      var diceNumber = _diceService.RollDice();

      _boardService.MoveToken(diceNumber);
    }

    public int GetTokenPosition()
    {
      return _boardService.GetTokenPosition();
    }

    public bool IsGameWon()
    {
      return _hasWon;
    }

    private void _boardService_OnWinEvent(object sender, System.EventArgs e)
    {
      _hasWon = true;
    }

    public void Dispose()
    {
      if (_boardService != null)
      {
        _boardService.OnWinEvent -= _boardService_OnWinEvent;
      }
      //perhaps dispose other services..
    }
  }
}
