oh-my-posh --init --shell pwsh --config ~\Documents\PowerShell\vk-cfg.json | Invoke-Expression
Import-Module posh-git
$GitPromptSettings.EnablePromptStatus = $false