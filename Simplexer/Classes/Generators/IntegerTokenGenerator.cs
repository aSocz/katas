namespace Simplexer.Classes.Generators
{
    public class IntegerTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "integer";

        protected override string Pattern { get; } = @"^\d+";

        public override int Order { get; } = 0;
    }
}