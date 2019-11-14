## Registry

[![Actions](https://github.com/wk-j/github-registry/workflows/Build/badge.svg)](https://github.com/wk-j/github-registry/actions)

```
nuget source Remove -Name wk-j
nuget source Remove -Name GitHub

nuget source Add -Name GitHub \
    -Source "https://nuget.pkg.github.com/wk-j/index.json" \
    -UserName wk-j \
    -Password $GITHUB_TOKEN

nuget push \
    -Source GitHub \
    (find . -name "MyConsole*.nupkg")

dotnet nuget push \
    --source https://nuget.pkg.github.com/wk-j/index.json \
    --api-key $GITHUB_TOKEN \
    (find . -name "MyConsole*.nupkg")

dotnet nuget push \
    --source https://nuget.pkg.github.com/wk-j/index.json \
    --api-key $GITHUB_TOKEN \
    .publish/MyConsole.19.11.14.1245.nupkg

cat ~/.config/NuGet/NuGet.Config
```

## Issues

- https://github.community/t5/GitHub-API-Development-and/github-package-registry-not-compatible-with-dotnet-nuget-client/td-p/34776
- https://github.com/NuGet/Home/issues/8580