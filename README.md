## Registry

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