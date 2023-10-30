FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/RandomObjectsGenerator
COPY RandomObjectsGenerator.Library.TargetModels/ RandomObjectsGenerator.Library.TargetModels/
COPY RandomObjectsGenerator.Library.TargetModels.UnitTests/ RandomObjectsGenerator.Library.TargetModels.UnitTests/
COPY RandomObjectsGenerator.Library.Core/ RandomObjectsGenerator.Library.Core/
COPY RandomObjectsGenerator.Library.DatabaseContext.InMemory/ RandomObjectsGenerator.Library.DatabaseContext.InMemory/
COPY RandomObjectsGenerator.Library.Serialization/ RandomObjectsGenerator.Library.Serialization/
COPY RandomObjectsGenerator.App.CLI/ RandomObjectsGenerator.App.CLI/
RUN dotnet publish RandomObjectsGenerator.App.CLI/RandomObjectsGenerator.App.CLI.csproj --output /usr/local/bin/RandomObjectsGenerator --configuration "Release" --use-current-runtime --no-self-contained
WORKDIR /usr/local/bin/RandomObjectsGenerator
