namespace Simplexer.Classes.Generators
{
    public class BooleanTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "boolean";

        protected override string Pattern { get; } = @"^(true|false)\b";

        public override int Order { get; } = 1;
    }
}