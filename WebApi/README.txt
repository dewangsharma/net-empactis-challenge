# EmpactisChallenge Solution 
Solution consist of different projects i.e. BusinessLogic, Core, DataAccess and WebApi
WebApi is the only & required startup project.

## NOTE
Provided CSV files(Absences.csv and Employees.csv) added as resource to the DataAccess project.
On start of the API, csv files are read and it's content is stored in the InMemoryDB.
API uses this InMemoryDB for reading the data.

## WebApi
REST API offers the endpoint for employee.
Project should be set as startup project

## Requirement
Please download and install .NET SDK from https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install

## Build environment
.NET 5 

## Start application
Start the solution (run WebAPI project) and this should start the api server at http://localhost:44123