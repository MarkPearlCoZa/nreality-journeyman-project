using PrizeGiving.Domain.SelectWinner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrizeGiving.Domain.Commands
{
    public class CSharpRandomizer : Randomizer
    {
        public int GetRandomNumber(int maximumValue)
        {
            Random random = new Random();
            return random.Next(maximumValue);
        }
    }
}
