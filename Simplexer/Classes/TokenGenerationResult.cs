namespace Simplexer.Classes
{
    public struct TokenGenerationResult
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
}