#!/bin/bash
set -e
OUTPUT_DIR="./nupkg"

# Create output directory if it doesn't exist
mkdir -p $OUTPUT_DIR

# Build the NuGet package
dotnet pack -c Release -o $OUTPUT_DIR