
#!/bin/bash
set -e
echo "Publishing the templates..."
dotnet pack -c Release
echo "Templates published successfully."