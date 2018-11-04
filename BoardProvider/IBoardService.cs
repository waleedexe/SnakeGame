using System;

namespace BoardProvider
{
  public interface IBoardService
  {
    void AddToken();
    void MoveToken(int diceNumber);
    void NewGame();
    int GetTokenPosition();
    event EventHandler OnWinEvent;
  }
}