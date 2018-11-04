using BoardProvider;
using DiceProvider;
using FluentAssertions;
using Moq;
using SnakeGame;
using TokenProvider;
using Xunit;

namespace AcceptanceTests
{
  public class PlayerCanWinTests
  {
    private Mock<IDiceService> _diceMock = new Mock<IDiceService>();
    private Game _game;

    public PlayerCanWinTests()
    {
      _game = new Game(new BoardService(new TokenService()), _diceMock.Object);
    }

    [Fact]
    public void GivenTokenIsOn97_WhenMovedBy3_ThenTokenIsOn100AndWon()
    {
      GivenTokenIsOn(97);
      AndTokenMovedBy(3);
      ThenTokenIsOnSquare(100);
      AndPlayerHasWon(true);
    }

    [Fact]
    public void GivenTokenIsOn97_WhenMovedBy4_ThenTokenIsOn97AndNotWon()
    {
      GivenTokenIsOn(97);
      AndTokenMovedBy(4);
      ThenTokenIsOnSquare(97);
      AndPlayerHasWon(false);
    }

    private void GivenTokenIsOn(int position)
    {
      _game.NewGame();
      _game.AddNewToken();
      _diceMock.Setup(d => d.RollDice()).Returns(position - 1);
      _game.RollDice();
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

    private void AndPlayerHasWon(bool isWon)
    {
      _game.IsGameWon().Should().Be(isWon);
    }
  }
}
