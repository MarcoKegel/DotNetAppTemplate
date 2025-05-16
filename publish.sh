#!/bin/bash
set -e
OUTPUT_DIR="./nupkg"

# Create output directory if it doesn't exist
mkdir -p $OUTPUT_DIR

# Build the NuGet package
dotnet pack -c Release -o $OUTPUT_DIR

# Inform the user
echo "To import the template into the dotnet CLI, run:"
echo "dotnet new -i $OUTPUT_DIR/MyProject.1.0.0.nupkg"