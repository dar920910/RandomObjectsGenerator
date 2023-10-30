# Solution's Details

$repo = "RandomObjectsGenerator"

$targetModelsLibraryProject = "$repo.Library.TargetModels"
$targetModelsUnitTestingProject = "$repo.Library.TargetModels.UnitTests"
$coreLibraryProject = "$repo.Library.Core"
$databaseContextLibraryProject = "$repo.Library.DatabaseContext.InMemory"
$serializationLibraryProject = "$repo.Library.Serialization"
$consoleApplicationProject = "$repo.App.CLI"

$containerSrcFolder = "/usr/local/src/$repo"
$containerBinFolder = "/usr/local/bin/$repo"

$executableFileName = $consoleApplicationProject

# Dockerfile

$dockerfileFileName = "Dockerfile"
$dockerfileContent = @"
FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR $containerSrcFolder
COPY $targetModelsLibraryProject/ $targetModelsLibraryProject/
COPY $targetModelsUnitTestingProject/ $targetModelsUnitTestingProject/
COPY $coreLibraryProject/ $coreLibraryProject/
COPY $databaseContextLibraryProject/ $databaseContextLibraryProject/
COPY $serializationLibraryProject/ $serializationLibraryProject/
COPY $consoleApplicationProject/ $consoleApplicationProject/
RUN dotnet publish $consoleApplicationProject/$consoleApplicationProject.csproj --output $containerBinFolder --configuration "Release" --use-current-runtime --no-self-contained
WORKDIR $containerBinFolder
"@

# .dockerignore

$dockerignoreFileName = ".dockerignore"
$dockerignoreContent = @"
# directories
.github/
.vs/
.vscode/
**/bin/
**/obj/
**/out/
# files
Create-DockerConfig.ps1
Create-Solution.ps1
Create-StyleCopConfig.ps1
Dockerfile*
**/*.md
"@

# PowerShell Scripts

$dockerImageTag = "random_objects_generator"

$dockerBuildScriptFileName = "Execute-DockerBuild.ps1"
$dockerBuildScriptContent = "docker build --file Dockerfile --tag $dockerImageTag ."

$dockerLaunchScriptFileName = "Execute-DockerLaunch.ps1"
$dockerLaunchScriptContent = "docker run --interactive --tty --rm $dockerImageTag $containerBinFolder/$executableFileName"

$dockerRunScriptFileName = "Execute-DockerRun.ps1"
$dockerRunScriptContent = "docker run --interactive --tty --rm $dockerImageTag"


# Generate Docker configuration for this repository

function Set-DockerConfiguration {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$FileName,

        [Parameter(Mandatory)]
        [string]$FileContent
    )

    $homeDirectoryPath = Get-Location
    $filePath = "$homeDirectoryPath/$FileName"

    if (Test-Path -Path $filePath) {
        Write-Host "$filePath : Skip the existing file: $filePath"
    }
    else {
        Write-Host "Create the Docker configuration: $filePath"
        Set-Content -Path $filePath -Value $FileContent
    }

    Write-Host
}

Set-DockerConfiguration -FileName $dockerfileFileName -FileContent $dockerfileContent
Set-DockerConfiguration -FileName $dockerignoreFileName -FileContent $dockerignoreContent
Set-DockerConfiguration -FileName $dockerBuildScriptFileName -FileContent $dockerBuildScriptContent
Set-DockerConfiguration -FileName $dockerLaunchScriptFileName -FileContent $dockerLaunchScriptContent
Set-DockerConfiguration -FileName $dockerRunScriptFileName -FileContent $dockerRunScriptContent
