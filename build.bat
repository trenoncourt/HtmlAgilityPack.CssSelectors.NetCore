@echo off

dotnet restore

dotnet build

cd ".\test\HtmlAgilityPack.CssSelectors.NetCore.UnitTests"

dotnet test "."

cd "../.."

dotnet pack ".\src\HtmlAgilityPack.CssSelectors.NetCore" -c Release -o ".\bin\NuGetPackages"

pause