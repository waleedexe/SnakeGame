using BoardProvider;
using DiceProvider;
using FluentAssertions;
using NSpec;
using SnakeGame;
using TokenProvider;

namespace Acceptance.Specs.Tests
{
  public class token_can_move : nspec
  {
    private Game _game = new Game(
      new BoardService(new TokenService()), new DiceService());

    public void given_game_started()
    {
      before = () => _game.NewGame();

      context["when the token is placed on the board"] = () =>
      {
        before = () => _game.AddNewToken();

        it["Then the token is on square 1"] = () =>
        {
          _game.GetTokenPosition().Should().Be(1);
        };
      };
    }
  }
}
