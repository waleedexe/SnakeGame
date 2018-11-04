using BoardProvider;
using DiceProvider;

namespace SnakeGame
{
  public class Game
  {
    private readonly IBoardService _boardService;
    private readonly IDiceService _diceService;

    public Game(IBoardService boardService, IDiceService diceService)
    {
      _boardService = boardService;
      _diceService = diceService;
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
  }
}
