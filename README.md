# Convert numeric value to English currency words
> Create a simple endpoint that converts input numeric value to English Currency Words

### Project Stacks
- API: .NET Core 5.0 Web API
- Unit Testing framework: NUnit

### How to run the application
- Install .NET Core 5.0(.401) SDK if you don't have: [Download](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- Clone the project
```
$ git clone https://github.com/uhback/ConvertCurrencyWords.git
```
- Open the API project (../ConvertApp/API) from VSCode (Visual Studio would be fine to use)
- Open Terminal and build using below command
```
$ dotnet build
$ dotnet run
```
- Once you run the project, Swagger will be opened on the browser
- Test the api (e.g. api/convert?inputNum=1.15) via Swagger

### What would be done with more time
- Deploy the project on AWS (EC2 or Serverless)
- Build frontend side (Angular) for client
- Extend the feature to using other currencies
