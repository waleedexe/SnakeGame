using BoardProvider;

namespace SnakeGame
{
  public class Game
  {
    private readonly IBoardService _boardService;

    public Game(IBoardService boardService)
    {
      _boardService = boardService;
    }

    public void NewGame()
    {
      _boardService.NewGame();
    }

    public void AddNewToken()
    {
      _boardService.AddToken();
    }
  }
}
