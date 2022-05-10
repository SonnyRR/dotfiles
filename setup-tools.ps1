Write-Host "Installing/Updating Choco"
if ($null -eq (Get-Command -Name choco.exe -ErrorAction SilentlyContinue)) {
    Set-ExecutionPolicy Bypass -Scope Process -Force
    [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
    Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
} else {
    & choco update Chocolatey
}

Write-Host  "Intstalling minimal setup"
& choco install `
    7zip `
    git `
    oh-my-posh `
    microsoft-windows-terminal `
    notepadplusplus `
    powertoys `
    pwsh `
    sysinternals `
    -y


# add tools
if ((Read-Host "Install dev tools: (y/N)").ToLower() -eq 'y') {
    & choco install `
        azure-cli `
        dotnet `
        docker-desktop `
        insomnia-rest-api-client `
        linqpad `
        nodejs-lts `
        nswagstudio `
        postman `
        vscode `
        ilspy `
        devtoys `
        git `
        nvm `
        neovim `
        -y
}

if ((Read-Host "Install paid tools: (y/N)").ToLower() -eq 'y') {
    & choco install `
        visualstudio2019enterprise `
        -y
}

if ((Read-Host "Install other apps: (y/N)").ToLower() -eq 'y') {
    & choco install `
        sumatrapdf.install `
        jetbrainstoolbox `
        -y
}
