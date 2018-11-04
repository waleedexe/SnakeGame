using System;

namespace DiceProvider
{
  public class DiceService : IDiceService
  {
    private readonly Random _rand;

    public DiceService()
    {
      _rand = new Random();
    }

    public int RollDice()
    {
      var result = _rand.Next(1, 6);

      return result;
    }
  }
}
