namespace SystemInit.Catalogs
{
    using Cupboard;
    using SystemInit.Manifests;
    using static Constants.Args;

    public sealed class WindowsMachine : WindowsCatalog
    {
        public override void Execute(CatalogContext context)
        {
            bool useChocolatey = context.Facts.HasArgument(CHOCOLATEY);

            if (useChocolatey)
            {
                context.UseManifest<Chocolatey>();
                return;
            }

            context.UseManifest<Winget>();
        }
    }
}
