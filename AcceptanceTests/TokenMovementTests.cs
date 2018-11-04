using BoardProvider;
using DiceProvider;
using FluentAssertions;
using Moq;
using SnakeGame;
using TokenProvider;
using Xunit;

namespace AcceptanceTests
{
  public class TokenMovementTests
  {
    private Mock<IDiceService> _diceMock = new Mock<IDiceService>();
    private Game _game;

    public TokenMovementTests()
    {
      _game = new Game(new BoardService(new TokenService()), _diceMock.Object);
    }

    [Fact]
    public void GivenNewToken_ShouldBeInSquare1()
    {
      GivenNewGame();
      WhenTokenIsAdded();
      ThenTokenIsOnSquare(1);
    }

    [Fact]
    public void GivenTokenInSquare1_WhenMovedBy3_ShouldBeInSquare4()
    {
      GivenNewGame();
      WhenTokenIsAdded();
      AndTokenMovedBy(3);
      ThenTokenIsOnSquare(4);
    }

    [Fact]
    public void GivenTokenInSquare1_WhenMovedBy3And4_ShouldBeInSquare8()
    {
      GivenNewGame();
      WhenTokenIsAdded();
      AndTokenMovedBy(3);
      AndTokenMovedBy(4);
      ThenTokenIsOnSquare(8);
    }

    private void GivenNewGame()
    {
      _game.NewGame();
    }

    private void WhenTokenIsAdded()
    {
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
