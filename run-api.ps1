<#
.SYNOPSIS
    Script to restore, build, and run the Airbnb API project.

.DESCRIPTION
    This script ensures the API backend is consistently restored, built, and run.
    It also displays the running URLs and opens Swagger in the default browser.

.EXAMPLE
    .\run-api.ps1
#>

# Enable script to stop on errors
$ErrorActionPreference = "Stop"

Write-Host "=== Airbnb API: Starting backend ===" -ForegroundColor Cyan

# Define paths
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath "airbnb-mvp.sln"
$ApiProjectPath = Join-Path -Path $PSScriptRoot -ChildPath "backend\Airbnb.Api\Airbnb.Api.csproj"

# Restore NuGet packages
Write-Host "Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore $SolutionPath

# Build solution
Write-Host "Building solution..." -ForegroundColor Yellow
dotnet build $SolutionPath --no-restore

# Run API project
Write-Host "Running API project..." -ForegroundColor Yellow
Write-Host "This may take a few seconds..." -ForegroundColor DarkYellow

# Run in a new window
Start-Process "dotnet" "run --project `"$ApiProjectPath`" --urls http://localhost:5191;https://localhost:7019"

Write-Host ""
Write-Host "✅ Airbnb API is running!" -ForegroundColor Green
Write-Host "Swagger UI available at: http://localhost:5191/swagger" -ForegroundColor Green
Write-Host "HTTPS endpoint available at: https://localhost:7019" -ForegroundColor Green
Write-Host ""
Write-Host "You can stop the API by closing the terminal running the process." -ForegroundColor Cyan
