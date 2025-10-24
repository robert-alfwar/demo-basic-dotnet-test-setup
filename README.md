# TDD Integration Test Demo Project

This project demonstrates Test-Driven Development (TDD) with unit tests and integration tests in .NET using xUnit.

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (Visual Studio, VS Code, or Rider)

## 🚀 Getting Started

### 1. Clone or Create the Project

```bash
# If creating from scratch, follow the setup commands below
# Otherwise clone this repository
git clone <repository-url>
cd MySolution
```

### 2. Restore Client-Side Libraries

```bash
# Install LibMan CLI tool (one-time setup)
dotnet tool install --global Microsoft.Web.LibraryManager.Cli

# Restore client-side libraries (Bootstrap, jQuery, etc.)
cd MyProject
libman restore
cd ..
```

### 3. Build the Project

```bash
dotnet build
```

### 4. Run the Application

```bash
cd MyProject
dotnet run
```

Visit `http://localhost:5171` or `https://localhost:7205` in your browser.

## 🧪 Running Tests

### Run All Tests

```bash
dotnet test
```

### Run Unit Tests Only

```bash
dotnet test --filter Category=Unit
```

### Run Integration Tests Only

```bash
dotnet test --filter Category=Integration
```

### Run Tests with Code Coverage (Unit Tests Only)

**IMPORTANT:** Code coverage should only measure unit tests, not integration tests.

```bash
# Run only unit tests with coverage
dotnet test --filter Category=Unit /p:CollectCoverage=true
```

### Generate Code Coverage Report

**Prerequisites (one-time setup):**

**Option 1: Global Installation (recommended for personal use)**
```bash
# Install ReportGenerator tool globally
dotnet tool install --global dotnet-reportgenerator-globaltool
```

**Option 2: Local Installation (recommended for team projects)**
```bash
# Create tool manifest if it doesn't exist
dotnet new tool-manifest

# Install ReportGenerator as local tool
dotnet tool install dotnet-reportgenerator-globaltool

# Team members can restore tools with:
dotnet tool restore
```

**Windows PowerShell:**
```powershell
# 1. Run unit tests with code coverage
dotnet test --filter Category=Unit /p:CollectCoverage=true

# 2. Generate HTML report
# If installed globally:
reportgenerator -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html

# If installed locally:
dotnet reportgenerator -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html

# 3. Open report in browser
start ./TestResults/CoverageReport/index.html
```

**Mac/Linux (bash):**
```bash
# 1. Run unit tests with code coverage
dotnet test --filter Category=Unit /p:CollectCoverage=true

# 2. Generate HTML report
# If installed globally:
reportgenerator \
  -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml \
  -targetdir:./TestResults/CoverageReport \
  -reporttypes:Html

# If installed locally:
dotnet reportgenerator \
  -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml \
  -targetdir:./TestResults/CoverageReport \
  -reporttypes:Html

# 3. Open report
open ./TestResults/CoverageReport/index.html
```

### View Coverage in Terminal

**Windows PowerShell:**
```powershell
# Run with detailed coverage output
dotnet test --filter Category=Unit /p:CollectCoverage=true

# View summary in terminal
# If installed globally:
reportgenerator -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:TextSummary

# If installed locally:
dotnet reportgenerator -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:TextSummary

# Display the summary
Get-Content ./TestResults/CoverageReport/Summary.txt
```

**Mac/Linux (bash):**
```bash
# Run with detailed coverage output
dotnet test --filter Category=Unit /p:CollectCoverage=true

# View summary in terminal
# If installed globally:
reportgenerator \
  -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml \
  -targetdir:./TestResults/CoverageReport \
  -reporttypes:TextSummary

# If installed locally:
dotnet reportgenerator \
  -reports:./MyProject.UnitTests/TestResults/coverage.cobertura.xml \
  -targetdir:./TestResults/CoverageReport \
  -reporttypes:TextSummary

# Display the summary
cat ./TestResults/CoverageReport/Summary.txt
```

### View Coverage in VS Code

**Recommended Extension:** [Coverage Gutters](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters)

1. Install the Coverage Gutters extension in VS Code
2. Run tests with coverage: `dotnet test --filter Category=Unit /p:CollectCoverage=true`
3. Open any source file in [`MyProject/`](MyProject/)
4. Click "Watch" in the status bar or press `Ctrl+Shift+7` (Windows/Linux) or `Cmd+Shift+7` (Mac)
5. Coverage will be displayed with colored gutters:
   - 🟢 **Green** - Line is covered by tests
   - 🔴 **Red** - Line is not covered by tests
   - 🟡 **Yellow** - Line is partially covered

**Alternative:** Use the built-in VS Code Test Explorer:
1. Install [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) (includes Test Explorer)
2. Open the Testing panel in VS Code (beaker icon in the sidebar)
3. Run tests directly from the Test Explorer
4. View test results inline in the editor

## 📁 Project Structure

```
MySolution/
├── MyProject/                    # MVC application
│   ├── Controllers/              # Controllers
│   ├── Models/                   # Business logic
│   └── Views/                    # Razor views
├── MyProject.UnitTests/          # Unit tests
│   ├── CalculatorTests.cs
│   └── HomeControllerTests.cs
└── MyProject.IntegrationTests/   # Integration tests
    ├── Fixtures/
    │   └── CustomWebApplicationFactory.cs
    └── HomeControllerTests.cs
```

## 🔍 Test Types

### Unit Tests
- Test individual components in isolation
- Fast to execute
- Use mocking for dependencies
- Tagged with `[Trait("Category", "Unit")]`

### Integration Tests
- Test interaction between components
- Use `WebApplicationFactory` to start the application
- Test HTTP endpoints with RestSharp
- Tagged with `[Trait("Category", "Integration")]`

## 📚 Technologies

- **xUnit** - Testing framework
- **Moq** - Mocking library
- **RestSharp** - HTTP client for integration tests
- **WebApplicationFactory** - In-memory test server
- **Coverlet** - Code coverage tool
- **ReportGenerator** - Generates HTML reports from code coverage

## 🔗 Resources

- [xUnit Documentation](https://xunit.net/docs/getting-started/netcore/cmdline)
- [Moq Quickstart](https://github.com/moq/moq4/wiki/Quickstart)
- [Testing Controllers in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing)
- [Coverlet GitHub](https://github.com/coverlet-coverage/coverlet)
- [ReportGenerator GitHub](https://github.com/danielpalme/ReportGenerator)

## 📄 License

This project is created for demonstration and educational purposes.