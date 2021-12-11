namespace SystemInit.Manifests
{
    using Cupboard;
    using SystemInit.Packages;
    using static Constants.Facts;

    public sealed class Chocolatey : Manifest
    {
        private const string SET_EXEC_POLICY = "Set execution policy";
        private const string CHOCOLATEY_INSTALL = "Install Chocolatey";

        public override void Execute(ManifestContext context)
        {
            if (!context.Facts[CHOCOLATEY_INSTALLED])
            {
                this.InstallChocolatey(context);
            }

            foreach (var pkg in WingetPackages.Packages)
            {
                context.Resource<ChocolateyPackage>(pkg)
                    .Ensure(PackageState.Installed)
                    .After<PowerShell>(CHOCOLATEY_INSTALL);
            }
        }

        private void InstallChocolatey(ManifestContext context)
        {
            context.Resource<Download>("https://chocolatey.org/install.ps1")
                .ToFile("~/install-chocolatey.ps1");

            // Set execution policy
            context.Resource<RegistryValue>(SET_EXEC_POLICY)
                .Path(@"HKLM:\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell")
                .Value("ExecutionPolicy")
                .Data("Unrestricted", RegistryValueKind.String);

            context.Resource<PowerShell>(CHOCOLATEY_INSTALL)
                .Script("~/install-chocolatey.ps1")
                .Flavor(PowerShellFlavor.PowerShell)
                .RequireAdministrator()
                .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
                .After<RegistryValue>("Set execution policy")
                .After<Download>("https://chocolatey.org/install.ps1");
        }
    }
}
