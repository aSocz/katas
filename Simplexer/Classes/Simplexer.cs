using Simplexer.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution
{
    class Simplexer : Iterator<Token>
    {
        private string input;
        private readonly TokenGenerators generators;
        private Token currentToken;

        public Simplexer(string buffer)
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

    class TokenGenerators
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
            if (input == null)
            {
                input = string.Empty;
            }

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

    abstract class TokenGenerator
    {
        protected abstract string Type { get; }

        protected abstract string Pattern { get; }

        public abstract byte Order { get; }

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

    struct TokenGenerationResult
    {
        public TokenGenerationResult(Token token, string mutuatedText)
        {
            Token = token;
            MutuatedText = mutuatedText;
        }

        public Token Token { get; }
        public string MutuatedText { get; }
        public bool IsMatched => Token != null;
    }

    class BooleanTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "boolean";

        protected override string Pattern { get; } = @"^(true|false)\b";

        public override byte Order { get; } = 1;
    }

    class IdentifierTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "identifier";

        protected override string Pattern { get; } = @"^(?=[^\d])(?=\w|$)(\w|$)+\b";

        public override byte Order { get; } = 6;
    }

    class IntegerTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "integer";

        protected override string Pattern { get; } = @"^\d+";

        public override byte Order { get; } = 0;
    }

    class KeywordTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "keyword";

        protected override string Pattern { get; } = @"^(if|else|for|while|return|func|break)\b";

        public override byte Order { get; } = 4;
    }

    class OperatorTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "operator";

        protected override string Pattern { get; } = @"^(\+|-|\*|\/|%|\(|\)|=){1}";

        public override byte Order { get; } = 3;
    }

    class StringTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "string";

        protected override string Pattern { get; } = @"^"".+""";

        public override byte Order { get; } = 2;
    }

    class WhitespaceTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "whitespace";

        protected override string Pattern { get; } = @"^\s+";

        public override byte Order { get; } = 5;
    }
}