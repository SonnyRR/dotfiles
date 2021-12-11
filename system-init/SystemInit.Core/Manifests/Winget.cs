namespace SystemInit.Manifests
{
    using Cupboard;
    using SystemInit.Packages;

    public sealed class Winget : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            foreach (var pkg in WingetPackages.Packages)
            {
                context.Resource<WingetPackage>(pkg)
                   .Ensure(PackageState.Installed);
            }
        }
    }
}
