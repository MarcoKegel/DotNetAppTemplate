# DotNetAppTemplate

This repository provides project templates for the dotnet CLI, comparable to 'dotnet new console', to create a new .NET console application. The templates should include boilerplate code for various aspects like development environment, packages for default use cases, and deployment.

## Repository Requirements
These requirements apply to the structure and content of this repository:
- The repository must follow the workspace structure required for dotnet templates.
- The repository must contain:
  - A `README.md` file explaining the purpose of the repository and how to use the templates.
  - A `LICENSE` file specifying the license for the repository.
  - A `doc` folder containing documentation, including this requirements file (`req.md`).

### Scripts to build, test, and publish the templates.
- the publish script should create the nuget package by using the dotnet cli
- the package name should contain the version number referenced in the project file.
- the publish script should inform the user how to import the template into the dotnet CLI with reference created file by refering to the package created by dotnet cli

## Template Requirements

### These requirements apply to the templates provided in the repository (e.g., `/templates/console`):
- The template must follow the dotnet CLI template structure.

### The template must include:
- A `README.md` file in the template root (`/templates/console/README.md`) explaining the purpose of the template and how to use it.
- A subfolder `src` containing the business logic of the application.
- A subfolder `test` containing the tests for the business logic.
- A dotnet console project in the `src` subfolder.
- A dotnet NUnit project in the `test` subfolder.

### Boilerplate code for:
- Dependency injection
- Configuration
- Logging
- Unit testing

### Scripts in the template root (`/templates/console`) to:
- Build the project
- Test the project
- Publish the project



