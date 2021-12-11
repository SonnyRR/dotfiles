namespace SystemInit
{
    using Catalogs;
    using Cupboard;

    public static class Startup
    {
        public static int Main(string[] args)
        {
            return CupboardHost.CreateBuilder()
                   .AddCatalog<WindowsMachine>()
                   .Run(args);
        }
    }
}