# BudgetHomeCalculator

Simple CRUD SPA writen in Angular with .NET Core 3.1 Web API support. Application alows us to Add/Remove and Update tasks. My responsibility in Group project was to build Backend for application.

## Technologies

*  .NET Core 3.1
*  Angular 8
*  Node.js(LTS version)
*  MS SQL Server 2017

## Used Packages/Libraries
* AutoMapper
* Autofac
* Entity Framework Core

## 1. Prepare Environment
* Install Visual Studio(easy way) or use .NET CLI (harder way)
* Install Node.js (LTS is best option)
* Install globaly Angular CLI
* Install MS SQL Server

## 2. Prepare Database
* Create database server instance
* Open Api project and change ConnectionString in appsettings.json
```
 "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER; User Id=YOUR_USER_ID; Password=YOUR_USER_PASSWORD; Database=FarminoDb"
  },
```
* Run prepared Database Migration using Package Manager Console:
```
#aplaying prepared migration
update-database
```

## 3. Run Application
* Open Backend project in VS using Kestrel : choose in running options selector Farmino.API or in Project directory use .NET CLI run command:
```
#at first build project
dotnet build

#then run
dotnet run
```
* Go to frontend project folder and run Frontend local serve:
```
ng serve
```
Application should be able to use on port 4200!
