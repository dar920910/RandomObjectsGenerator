# Random Objects Generator for Persons :two_men_holding_hands:

This tool implements a generator of random objects by its predefined models.

The tool uses JSON serialization as a persistance storage for its created objects.

Currently, the tool supports only generating objects of the **Person** type.

---

## :pencil: About Project Requirements

This program was created as a test project which should match employer's requirements.

Initial project requirements are documented in the [REQUIREMENTS.md](REQUIREMENTS.md) file:

:link: [REQUIREMENTS.md - Initial Requirements :pencil:](REQUIREMENTS.md#initial-requirements)

Some requirements to implementation details were changed by me when creating the project:

:link: [REQUIREMENTS.md - Changes of Initial Requirements :pencil2:](REQUIREMENTS.md#changes-of-initial-requirements)

---

## :triangular_ruler: Explore This Software Architecture Solution

This solution implements the software architecture design based on the following related projects:

### :pushpin: Application

#### :open_file_folder: RandomObjectsGenerator.App.CLI

This console application implements the command-line interface for the generator of random objects.

### :pushpin: Class Libraries

#### :open_file_folder: RandomObjectsGenerator.Library.Core

This class library contains the implementation of core features for the generator of random objects.

#### :open_file_folder: RandomObjectsGenerator.Library.DatabaseContext.InMemory

This class library implements the context of the in-memory database for the storage of generated objects.

#### :open_file_folder: RandomObjectsGenerator.Library.Serialization

This class library contains implementations of serialization devices for using into the project.

#### :open_file_folder: RandomObjectsGenerator.Library.TargetModels

This class library contains definitions of target models for the generator of random objects.

### :pushpin: Unit Testing

#### :open_file_folder: RandomObjectsGenerator.Library.TargetModels.UnitTests

This project contains unit tests for target models used by the generator of random objects.

---

## :beginner: Learn Quick Start Guide

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

**Variant 1:** Launch the program via the **dotnet** command-line tool

    dotnet run

**Variant 2:** Launch the program via its executable directly

    ./RandomObjectsGenerator.App.CLI

**Example 2:** Generate 100 person objects (less than the default value):

    ./RandomObjectsGenerator.App.CLI --count=100

**Example 3:** Generate 100 000 person objects (more than the default value):

    ./RandomObjectsGenerator.App.CLI --count=100000

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

## :warning: Be Aware About the Current Project Implementation

This project is is a limited implementation of the random objects generator.

Program's limitations exist because this project was created as a test project.

### :scroll: Known Program Limitations

The following list documents these limitations:

:black_square_button: Person objects are generated with placeholder values of the FirstName and the LastName properties (instead of real names for some culture or country).

:black_square_button: Credit card numbers contain 16 digits and are abstract numbers (no relations with known payment systems).

:black_square_button: Phone numbers contain 10 digits and are generated in the mobile phone number (no relations with phone numbers formats for different countries and other possible types like the home phone, the work phone, and etc.)

:black_square_button: Person's salary size is generated as an abstract decimal integer value (no relations with known currency units for different countries).

:dart: These limitations are candidates for issues to continue development the project in future.

---
