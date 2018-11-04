using DiceProvider;
using FluentAssertions;
using Xunit;

namespace DiceProviderTests
{
  public class DiceServiceTests
  {
    [Fact]
    public void WhenDiceRolled_Should_ReturnNumberBw1And6()
    {
      var sut = new DiceService();
      var result = sut.RollDice();

      result.Should().BeInRange(1, 6);
    }
  }
}
