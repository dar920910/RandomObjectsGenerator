$repo = "RandomObjectsGenerator"
Write-Host "`n*** $repo : Create Solution and Projects ***`n"
dotnet new sln --name $repo

$targetFramework = "net6.0"

$targetModelsLibraryProject = "$repo.Library.TargetModels"
Write-Host "`n--- $targetModelsLibraryProject ---`n"
dotnet new classlib --framework $targetFramework --name $targetModelsLibraryProject
dotnet sln add $targetModelsLibraryProject

$targetModelsUnitTestingProject = "$repo.Library.TargetModels.UnitTests"
Write-Host "`n--- $targetModelsUnitTestingProject ---`n"
dotnet new xunit --framework $targetFramework --name $targetModelsUnitTestingProject
dotnet add $targetModelsUnitTestingProject reference $targetModelsLibraryProject
dotnet sln add $targetModelsUnitTestingProject

$coreLibraryProject = "$repo.Library.Core"
Write-Host "`n--- $coreLibraryProject ---`n"
dotnet new classlib --framework $targetFramework --name $coreLibraryProject
dotnet add $coreLibraryProject reference $targetModelsLibraryProject
dotnet sln add $coreLibraryProject

$databaseContextLibraryProject = "$repo.Library.DatabaseContext.InMemory"
Write-Host "`n--- $databaseContextLibraryProject ---`n"
dotnet new classlib --framework $targetFramework --name $databaseContextLibraryProject
dotnet add $databaseContextLibraryProject package Microsoft.EntityFrameworkCore.InMemory --version 7.0.13
dotnet add $databaseContextLibraryProject reference $targetModelsLibraryProject
dotnet sln add $databaseContextLibraryProject

$serializationLibraryProject = "$repo.Library.Serialization"
Write-Host "`n--- $serializationLibraryProject ---`n"
dotnet new classlib --framework $targetFramework --name $serializationLibraryProject
dotnet add $serializationLibraryProject package Newtonsoft.Json --version 13.0.3
dotnet add $serializationLibraryProject reference $targetModelsLibraryProject
dotnet sln add $serializationLibraryProject

$consoleApplicationProject = "$repo.App.CLI"
Write-Host "`n--- $consoleApplicationProject ---`n"
dotnet new console --framework $targetFramework --name $consoleApplicationProject
dotnet add $consoleApplicationProject reference $targetModelsLibraryProject
dotnet add $consoleApplicationProject reference $coreLibraryProject
dotnet add $consoleApplicationProject reference $databaseContextLibraryProject
dotnet add $consoleApplicationProject reference $serializationLibraryProject
dotnet sln add $consoleApplicationProject

Write-Host "`n*** $repo : Print Solution's Projects ***`n"
dotnet sln list
