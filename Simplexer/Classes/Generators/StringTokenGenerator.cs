namespace Simplexer.Classes.Generators
{
    public class StringTokenGenerator : TokenGenerator
    {
        protected override string Type { get; } = "string";

        protected override string Pattern { get; } = @"^"".+""";

        public override int Order { get; } = 2;
    }
}