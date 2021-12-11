namespace SystemInit.Facts
{
    using Cupboard;
    using Spectre.Console.Cli;
    using Spectre.IO;
    using static Constants.Facts;

    public sealed class ChocolateyFactsProvider : IFactProvider
    {
        private readonly ICupboardFileSystem fileSystem;
        private readonly ICupboardEnvironment environment;

        public ChocolateyFactsProvider(ICupboardFileSystem fileSystem, ICupboardEnvironment environment)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public IEnumerable<(string Name, object Value)> GetFacts(IRemainingArguments args)
        {
            var path = new DirectoryPath(@"C:\ProgramData\chocolatey").MakeAbsolute(this.environment);
            yield return (CHOCOLATEY_INSTALLED, this.fileSystem.Exist(path));
        }
    }
}
