using Simplexer.Classes;
using System.Collections.Generic;
using Xunit;

namespace CodewarsSandbox
{
    public class SimplexerTests
    {
        private static Token[] ToArray(SimplexerOriginal lexer)
        {
            var tokens = new List<Token>();
            while (lexer.MoveNext())
            {
                tokens.Add(lexer.Current);
            }

            return tokens.ToArray();
        }

        [Fact]
        public void TestEmpty()
        {
            var lexer = new SimplexerOriginal("");
            Assert.False(lexer.MoveNext());
        }

        [Fact]
        public void TestExpression()
        {
            // Simple Expression
            var lexer = new SimplexerOriginal("(1 + 2) - 5");
            Assert.Equal(
                new[]
                {
                    new Token("(", "operator"),
                    new Token("1", "integer"),
                    new Token(" ", "whitespace"),
                    new Token("+", "operator"),
                    new Token(" ", "whitespace"),
                    new Token("2", "integer"),
                    new Token(")", "operator"),
                    new Token(" ", "whitespace"),
                    new Token("-", "operator"),
                    new Token(" ", "whitespace"),
                    new Token("5", "integer")
                },
                ToArray(lexer));
        }

        [Fact]
        public void TestSingle()
        {
            // Identifier
            var lexer = new SimplexerOriginal("x");
            Assert.True(lexer.MoveNext());
            Assert.Equal(new Token("x", "identifier"), lexer.Current);

            // Boolean
            lexer = new SimplexerOriginal("true");
            Assert.True(lexer.MoveNext());
            Assert.Equal(new Token("true", "boolean"), lexer.Current);

            // Integer
            lexer = new SimplexerOriginal("12345");
            Assert.True(lexer.MoveNext());
            Assert.Equal(new Token("12345", "integer"), lexer.Current);

            // String
            lexer = new SimplexerOriginal("\"Hello\"");
            Assert.True(lexer.MoveNext());
            Assert.Equal(new Token("\"Hello\"", "string"), lexer.Current);

            // Keyword
            lexer = new SimplexerOriginal("break");
            Assert.True(lexer.MoveNext());
            Assert.Equal(new Token("break", "keyword"), lexer.Current);
        }

        [Fact]
        public void TestStatement()
        {
            // Simple statement
            var lexer = new SimplexerOriginal("return x + 1");
            Assert.Equal(
                new[]
                {
                    new Token("return", "keyword"),
                    new Token(" ", "whitespace"),
                    new Token("x", "identifier"),
                    new Token(" ", "whitespace"),
                    new Token("+", "operator"),
                    new Token(" ", "whitespace"),
                    new Token("1", "integer")
                },
                ToArray(lexer));
        }
    }
}