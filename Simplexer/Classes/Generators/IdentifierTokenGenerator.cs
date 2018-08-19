namespace Simplexer.Classes.Generators
{
    public class IdentifierTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "identifier";

        protected override string Pattern { get; } = @"^(?=[^\d])(?=\w|$)(\w|$)+\b";

        public override int Order { get; } = 6;
    }
}