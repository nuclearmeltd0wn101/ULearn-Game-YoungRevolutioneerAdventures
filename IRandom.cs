using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ulearn_game_YoungRevolutioneerGame
{
    public interface IRandom
    {
        public int Next();
        public int Next(int maxValue);
        public int Next(int minValue, int maxValue);
    }

    public class NormalRandom : IRandom
    {
        private Random rand = new Random();

        public int Next() => rand.Next();
        public int Next(int maxValue) => rand.Next(maxValue);
        public int Next(int minValue, int maxValue) => rand.Next(minValue, maxValue);
    }

    public class ReplayingRandom : IRandom
    {
        private List<int> replayValues;
        public ReplayingRandom(List<int> replayValues) => this.replayValues = replayValues;

        public int Next()
        {
            var value = replayValues[0];
            replayValues.RemoveAt(0);
            return value;
        }

        public int Next(int maxValue) => Next();

        public int Next(int minValue, int maxValue) => Next();
    }
}