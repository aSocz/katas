using System.Text.RegularExpressions;

namespace Simplexer.Classes
{
    public abstract class TokenGenerator
    {
        protected abstract string Type { get; }

        protected abstract string Pattern { get; }

        public abstract int Order { get; }

        public TokenGenerationResult TryGenerate(string input)
        {
            var match = Regex.Match(input, Pattern);
            if (!match.Success)
            {
                return new TokenGenerationResult(null, input);
            }

            var mutuatedText = Regex.Replace(input, Pattern, string.Empty);
            var token = new Token(match.Value, Type);

            return new TokenGenerationResult(token, mutuatedText);
        }
    }
}