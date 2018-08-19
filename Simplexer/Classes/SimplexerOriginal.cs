using Simplexer.Classes.Generators;

namespace Simplexer.Classes
{
    //https://www.codewars.com/kata/54b8204dcd7f514bf2000348/train/csharp
    public class SimplexerOriginal : Iterator<Token>
    {
        private string input;
        private readonly TokenGenerators generators;
        private Token currentToken;

        public SimplexerOriginal(string buffer)
        {
            input = buffer;
            generators = new TokenGenerators();
        }

        public override bool MoveNext()
        {
            var result = generators.TryGenerateToken(input);
            if (!result.IsMatched)
            {
                return false;
            }

            currentToken = result.Token;
            input = result.MutuatedText;
            return true;
        }

        public override Token Current => currentToken;
    }
}