namespace Simplexer.Classes.Generators
{
    public class WhitespaceTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "whitespace";

        protected override string Pattern { get; } = @"^\s+";

        public override int Order { get; } = 5;
    }
}