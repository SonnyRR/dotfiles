# 💻 dotfiles

My personal dotfiles for Windows & Linux machines.

Most of the `pwsh` scripts & configurations are based off: `wicksipedia/dotfiles`. Go check it out.

## 🔍Contains:

- C# Application for automatiaclly initializing new systems with `winget` or `chocolatey`.
- Powershell script for installing common tools via `chocolatey`
- Powershell script for configuring `oh-my-posh` and extending global `.gitconfig` with custom settings.
- `VS Code` user settings & recommended extensions.
- `Oh my ZSH` configuration.

### 🥏 How to use:
***
#### Use the .NET console app:

```pwsh
dotnet run #For restoring packages with winget.
``` 
```pwsh
dotnet run --choco #For restoring packages with chocolatey.
``` 

or run one of the `powershell` scripts in the root directory.