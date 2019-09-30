## Registry

``
nuget source Remove -Name wk-j
nuget source Remove -Name GitHub

nuget source Add -Name wk-j \
    -Source "https://nuget.pkg.github.com/wk-j/index.json" \
    -UserName wk-j \
    -Password $GH_TOKEN

nuget push \
    -Source wk-j \
    -ApiKey $GH_TOKEN \
    (find . -name "MyConsole*.nupkg")

cat ~/.config/NuGet/NuGet.Config
```