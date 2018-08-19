namespace Simplexer.Classes.Generators
{
    public class OperatorTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "operator";

        protected override string Pattern { get; } = @"^(\+|-|\*|\/|%|\(|\)|=){1}";

        public override int Order { get; } = 3;
    }
}