namespace Simplexer.Classes.Generators
{
    public class KeywordTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "keyword";

        protected override string Pattern { get; } = @"^(if|else|for|while|return|func|break)\b";

        public override int Order { get; } = 4;
    }
}