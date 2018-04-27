* deploy no linux 
     dotnet publish CodeItAirLines.ConsoleApp/CodeItAirLines.ConsoleApp.csproj -c release -r ubuntu.16.10-x64q

* deploy no windows 
      dotnet publish CodeItAirLines.ConsoleApp/CodeItAirLines.ConsoleApp.csproj -c release -r win10-x64

* rodar os testes
      dotnet test CodeItAirLines.Domain.Tests/CodeItAirLines.Domain.Tests.csproj

