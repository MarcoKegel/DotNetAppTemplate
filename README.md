# DotNetAppTemplate
A template including boilerplate to reduce startup efforts.

# Included functionality

Logging with nlog

CommandlineParser

Testing with nunit

Dependency injection

Filesystem abstraction

# Use

lore ipsum

# Inspired by

- [Custom templates for dotnet new msdn documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)

# Development

- *sourceName* "*consolename_template*" is used as template for the new application name. This alias is used in the project name, namespace and other

## Deployment

**Pack a template into a NuGet package**

`nuget pack`

**install a template package from a local nupkg file**

`dotnet new install <PATH_TO_NUPKG_FILE>`


**Uninstall a template package**

`dotnet new uninstall <NUGET_PACKAGE_ID>`


