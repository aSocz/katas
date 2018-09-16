using System.Numerics;

namespace FabergeEasterEggs
{
    public static class Faberge
    {
        public static BigInteger Height(int eggs, int tries, BigInteger[,] memory = null)
        {
            if (memory == null)
            {
                memory = new BigInteger[eggs + 1, tries + 1];
            }

            if (memory[eggs, tries] != default(BigInteger))
            {
                return memory[eggs, tries];
            }

            if (eggs == 0 || tries == 0)
            {
                return 0;
            }

            if (eggs == 1)
            {
                return tries;
            }

            if (eggs == 2)
            {
                //Basic case, see http://datagenetics.com/blog/july22012/index.html
                return tries * (tries + 1) / 2;
            }

            var eggBrokenCase = Height(eggs - 1, tries - 1, memory);
            memory[eggs - 1, tries - 1] = eggBrokenCase;

            var eggSurvivedCase = Height(eggs, tries - 1, memory);
            memory[eggs, tries - 1] = eggSurvivedCase;

            return 1 + eggBrokenCase + eggSurvivedCase;
        }
    }
}