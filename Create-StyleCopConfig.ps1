
$analyzerPackage = "StyleCop.Analyzers"
$analyzerVersion = "1.1.118"

$analyzerConfigFileName = "stylecop.json"
$analyzerConfigContent = @"
{
    "`$schema": "https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/StyleCop.Analyzers/StyleCop.Analyzers/Settings/stylecop.schema.json",
    "settings": {
        "documentationRules": {
            "companyName": "Demo Projects Workshop",
            "copyrightText": "Copyright (c) {companyName}. All rights reserved.\nLicensed under the {licenseName} license. See {licenseFile} file in the project root for full license information.",
            "variables": {
                "licenseName": "MIT",
                "licenseFile": "LICENSE.md"
            },
            "headerDecoration": "---------------------------------------------------------------------------"
        }
    }
}
"@

$solutionProjects = @(
    "RandomObjectsGenerator.App.CLI",
    "RandomObjectsGenerator.Library.Core",
    "RandomObjectsGenerator.Library.DatabaseContext.InMemory",
    "RandomObjectsGenerator.Library.Serialization",
    "RandomObjectsGenerator.Library.TargetModels",
    "RandomObjectsGenerator.Library.TargetModels.UnitTests"
)

$homeDirectoryPath = Get-Location

foreach ($project in $solutionProjects) {
    $projectFilePath = "$homeDirectoryPath/$project/$project.csproj"

    if (Test-Path -Path $projectFilePath) {
        Write-Host "$projectFilePath : Configuring StyleCop Analyzers ..."

        dotnet add $projectFilePath package $analyzerPackage --version $analyzerVersion

        $analyzerConfigFilePath = "$homeDirectoryPath/$project/$analyzerConfigFileName"
        Set-Content -Path $analyzerConfigFilePath -Value $analyzerConfigContent
    }
    else {
        Write-Host "$projectFilePath : Cannot detect a project in this folder !"
    }

    Write-Host
}
