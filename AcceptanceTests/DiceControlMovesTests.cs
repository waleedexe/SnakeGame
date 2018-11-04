using BoardProvider;
using DiceProvider;
using FluentAssertions;
using Moq;
using SnakeGame;
using TokenProvider;
using Xunit;

namespace AcceptanceTests
{
  public class DiceControlMovesTests
  {
    private Mock<IDiceService> _diceMock = new Mock<IDiceService>();
    private Game _game;

    public DiceControlMovesTests()
    {
      _game = new Game(new BoardService(new TokenService()), _diceMock.Object);
    }

    [Fact]
    public void GivenNewGame_WhenDiceRolls4_ThenTokenMovesBy4()
    {
      var startPosition = 1;
      var moveSpaces = 4;

      GivenNewGame();
      AndTokenMovedBy(moveSpaces);
      ThenTokenIsOnSquare(startPosition + moveSpaces);
    }

    private void GivenNewGame()
    {
      _game.NewGame();
      _game.AddNewToken();
    }

    private void AndTokenMovedBy(int spaces)
    {
      _diceMock.Setup(d => d.RollDice()).Returns(spaces);
      _game.RollDice();
    }

    private void ThenTokenIsOnSquare(int position)
    {
      _game.GetTokenPosition().Should().Be(position);
    }
  }
}
