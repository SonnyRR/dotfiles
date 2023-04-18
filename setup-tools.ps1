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
    dotnet-6.0-sdk `
    dotnet-sdk `
    microsoft-windows-terminal `
    notepadplusplus `
    powertoys `
    pwsh `
    sysinternals `
    sumatrapdf `
    jetbrainstoolbox `
    azure-cli `
    dotnet `
    docker-desktop `
    linqpad `
    postman `
    vscode `
    fnm `
    ilspy `
    neovim `
    devtoys `
    mobaxterm `
    sharex `
    vlc `
    neovim `
    gimp `
    qbittorrent `
    obsidian `
    wiztree `
    googleearthpro `
    -y