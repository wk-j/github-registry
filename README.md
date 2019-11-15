## Registry

[![Actions](https://github.com/wk-j/github-registry/workflows/Build/badge.svg)](https://github.com/wk-j/github-registry/actions)

```bash
nuget source Remove -Name wk-j
nuget source Remove -Name GitHub

nuget source Add -Name GitHub \
    -Source "https://nuget.pkg.github.com/wk-j/index.json" \
    -UserName wk-j \
    -Password $GITHUB_TOKEN

dotnet pack src/MyConsole/MyConsole.fsproj --output .publish
dotnet pack src/MyLibrary/MyLibrary.csproj --output .publish
dotnet pack src/NuGetPackages/NuGetPackages.csproj --output .publish

# Package deletion from the command line is disabled in GitHub Package Registry
nuget delete nuget-packages 1.0.0 -Source GitHub

nuget push \
    -Source GitHub \
    .publish/nuget-packages.1.0.0.nupkg

nuget push \
    -Source GitHub \
    .publish/wk.MyLibrary.1.0.0.nupkg

cat ~/.config/NuGet/NuGet.Config
```

## Issues

- https://github.community/t5/GitHub-API-Development-and/github-package-registry-not-compatible-with-dotnet-nuget-client/td-p/34776
- https://github.com/NuGet/Home/issues/8580
- https://github.com/NuGet/Home/issues/5972