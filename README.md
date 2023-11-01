# Random Objects Generator

This tool implements a generator of random objects by its predefined models and uses JSON serialization to save created objects.

---

## :beginner: Quick Start

Run the console application from the command-line with the **count** argument according the following format:

    <EXECUTABLE> --count={your count of Person objects to generate}

The output **Persons.json** JSON file with generated objects are in the following directory:

- **Windows:** the the current user's desktop folder (for example, "C:\Users\\dar920920\Desktop")
- **Unix-based OS:** the current directory of the application

### **Possible Parameters:**

#### --count

This parameter sets the custom count of objects which are instances of the Person class.
If this parameter is skipped, the count equals the default value (10 000 objects).
Possible values are limited by valid values within the range of the [System.UInt32](https://learn.microsoft.com/en-us/dotnet/api/system.uint32?view=net-6.0) integer type.

### Command Examples

**Example 1:** Generate 10 000 person objects (by default, according project's requirements):

Variant 1:

    dotnet run

Variant 2:

    ./RandomObjectsGenerator.App.CLI

**Example 2:** Generate 100 person objects (less than the default value):

    ./RandomObjectsGenerator.App.CLI --count=100

**Example 3:** Generate 100 000 person objects (more than the default value):

    ./RandomObjectsGenerator.App.CLI --count=100000

---

## :triangular_ruler: Explore This Software Architecture Solution

This solution implements the software architecture design based on the following related projects:

- **RandomObjectsGenerator.Library.TargetModels** - this class library contains definitions of target models for the generator of random objects.
- **RandomObjectsGenerator.Library.TargetModels.UnitTests** - this project contains unit tests for target models used by the generator of random objects.
- **RandomObjectsGenerator.Library.Core** - this class library contains the implementation of core features for the generator of random objects.
- **RandomObjectsGenerator.Library.DatabaseContext.InMemory** - this class library implements the context of the in-memory database for the storage of generated objects.
- **RandomObjectsGenerator.Library.Serialization** - this class library contains implementations of serialization devices for using into the project.
- **RandomObjectsGenerator.App.CLI** - this console application implements the command-line interface for the generator of random objects.

---

## :whale2: Deploy This Project via Docker

This program can be built and launched into the Docker container via provided **PowerShell** and **Bash** scripts:

1. Build app's Docker image via the **Execute-DockerBuild** script.
2. Launch the app from a new container via the **Execute-DockerLaunch** script.

:mag_right: You can investigate the content of this image via the **Execute-DockerRun** script.

---

## :wrench: Build-Test-Run This Project from Source Code

This project should be built from source code via [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0):

**Build the Project:**

    dotnet build

**Run Unit Tests:**

    dotnet test

**Run the Application:**

    cd ./RandomObjectsGenerator.App.CLI
    dotnet run

---
