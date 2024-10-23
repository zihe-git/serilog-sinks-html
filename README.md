# Serilog Sinks Html
Serilog sink to write logs to an HTML file.<br>
The package Serilog.Sinks.Html can be found on https://www.nuget.org.<br>
<hr>
You can install HtmlSink using the NuGet package manager:

```bash
dotnet add package Serilog.Sinks.Html
```
## Usage Example
1. Create a console project
` dotnet new console -n yourProjectName `
2. Add the HtmlSink package
` dotnet add package Serilog.Sinks.Html `
3. In the .csproj file, ensure that it includes a reference to Serilog. If it's not there, add it manually:
```
<ItemGroup>
    <PackageReference Include="Serilog" Version="4.1.0" />
    <PackageReference Include="ITCTraining.Serilog.Sinks.Html" Version="1.0.0" />
</ItemGroup>

```
4. Reference the packag
` using ITCTraining.Serilog.Sinks.Html; `
5. Configure and use the Serilog logger
```
Log.Logger = new LoggerConfiguration()
            .WriteTo.HtmlSink("log.html") 
            .CreateLogger();

        Log.Information("This is a test log message.");
        Log.CloseAndFlush();
```
6. After running the program, you will find an HTML file in the project directory.
   <hr/>
<b>Here’s the complete code for using the HtmlSink in a console application:　</b>
```
using System;
using Serilog;
using ITCTraining.Serilog.Sinks.Html; 

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.HtmlSink("log.html") 
            .CreateLogger();

        Log.Information("This is a test log message.");
        Log.CloseAndFlush();
    }
}
```
