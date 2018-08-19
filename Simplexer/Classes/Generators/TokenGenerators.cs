using System.Collections.Generic;
using System.Linq;

namespace Simplexer.Classes.Generators
{
    public class TokenGenerators
    {
        private readonly IOrderedEnumerable<TokenGenerator> generators;

        public TokenGenerators()
        {
            generators = new List<TokenGenerator>
            {
                new BooleanTokenGenerator(),
                new IdentifierTokenGenerator(),
                new IntegerTokenGenerator(),
                new KeywordTokenGenerator(),
                new OperatorTokenGenerator(),
                new StringTokenGenerator(),
                new WhitespaceTokenGenerator()
            }.OrderBy(g => g.Order);
        }

        public TokenGenerationResult TryGenerateToken(string input)
        {
            foreach (var generator in generators)
            {
                var result = generator.TryGenerate(input);
                if (result.IsMatched)
                {
                    return result;
                }
            }

            return new TokenGenerationResult(null, input);
        }
    }
}