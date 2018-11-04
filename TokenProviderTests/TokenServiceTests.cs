using FluentAssertions;
using TokenProvider;
using Xunit;

namespace TokenProviderTests
{
  public class TokenServiceTests
  {
    ITokenService _sut;

    public TokenServiceTests()
    {
      _sut = new TokenService();
    }

    [Fact]
    public void GivenANewToken_ShouldBeInPosition1()
    {
      var result = _sut.CreateToken();

      result.Should().NotBeNull();
      _sut.GetPosition(result).Should().Be(1);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(14)]
    [InlineData(90)]
    public void GivenToken_WhenMoved_ShouldBeInPosition(int spaces)
    {
      var token = new Token();

      _sut.MoveToken(token, spaces);

      _sut.GetPosition(token).Should().Be(1 + spaces);
    }

    [Theory]
    [InlineData(3, 100)]
    [InlineData(10, 91)]
    public void GivenToken_WhenMovedOverMaxPosition_ShouldRemainInPosition(int startPosition, int spaces)
    {
      var token = new Token();
      _sut.MoveToken(token, startPosition - 1);

      _sut.MoveToken(token, spaces);

      _sut.GetPosition(token).Should().Be(startPosition);
    }
  }
}
