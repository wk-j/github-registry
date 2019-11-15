#addin "wk.StartProcess"
#addin "wk.ProjectParser"

using PS = StartProcess.Processor;
using ProjectParser;

var nugetToken = EnvironmentVariable("GITHUB_TOKEN");
var name = "MyLibrary";

var currentDir = new DirectoryInfo(".").FullName;
var info = Parser.Parse($"src/{name}/{name}.csproj");
var publishDir = ".publish";
var version = DateTime.Now.ToString("yy.MM.dd.HHmm");

Task("Pack").Does(() => {
    var settings = new DotNetCoreMSBuildSettings();
    settings.Properties["Version"] = new string[] { version };

    CleanDirectory(publishDir);
    DotNetCorePack($"src/{name}", new DotNetCorePackSettings {
        OutputDirectory = publishDir,
        MSBuildSettings = settings
    });
});

Task("Publish-NuGet")
    .IsDependentOn("Pack")
    .Does(() => {
        var nupkg = new DirectoryInfo(publishDir).GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            // Source = "https://www.nuget.org/api/v2/package",
            Source = "https://nuget.pkg.github.com/wk-j/index.json",
            ApiKey = nugetToken
        });
});


var target = Argument("target", "Pack");
RunTarget(target);
