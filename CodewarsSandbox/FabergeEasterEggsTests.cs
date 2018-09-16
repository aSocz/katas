using FabergeEasterEggs;
using System.Numerics;
using Xunit;

namespace CodewarsSandbox
{
    public class FabergeEasterEggsTests
    {
        private static BigInteger b; // for holding temporary BigInteger instances

        [Fact]
        public void BasicTests()
        {
            Assert.Equal(new BigInteger(0), Faberge.Height(0, 14));
            Assert.Equal(new BigInteger(0), Faberge.Height(2, 0));
            Assert.Equal(new BigInteger(105), Faberge.Height(2, 14));
            Assert.Equal(new BigInteger(137979), Faberge.Height(7, 20));
        }

        [Fact]
        public void AdvancedTests()
        {
            Assert.Equal(BigInteger.Parse("1507386560013475"), Faberge.Height(7, 500));
            b = BigInteger.Parse("431322842186730691997112653891062105065260343258332219390917925258990318721206767477889789852729810256244129132212314387344900067338552484172804802659");
            Assert.Equal(b, Faberge.Height(237, 500));
            b = BigInteger.Parse("3273390607896141870013189696827599152216642046043064789483291368096133796404674554883270092325904157150886684127420959866658939578436425342102468327399");
            Assert.Equal(b, Faberge.Height(477, 500));
        }
    }
}