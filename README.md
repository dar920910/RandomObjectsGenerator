# Random Objects Generator

This tool implements a generator of random objects by its predefined models and uses JSON serialization to save created objects.

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

## :wrench: Build This Project from Source Code

Use **.NET 6 SDK** to build this project from source code.

---
