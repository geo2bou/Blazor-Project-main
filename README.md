# Description

You are given a solution that contains a Blazor Web App with a Customer model class.

You should fork this project and provide a github link for your solution.

You have to develop 

Required: 
- A grid with all customers with server side paging
- CRUD Operations on “Customer” model with new, edit and delete functionalities
- Expose all CRUD Operations as an API 
- Configure application to use Sql Server
- Manage migrations
- Below are the two classes Employee and Manager. Your task is to create a method in a new class that takes either Manager or an Employee as a parameter and prints its name.

```
public class Employee
{
	public string Name { get; set; }
}

public class Manager
{
	public string Name { get; set; }
}

```

Extra (nice to have) 
- Add authentication with the provided demo of Duende IdentityServer https://demo.duendesoftware.com/
- Protect your API with authentication with the provided demo of Duende IdentityServer done in the previous step
- Unit & Integration Tests

## Requirements 

- C#
- .NET 8+ 
- Blazor Wasm

Optional
- Blazor UI framework

## How to Run the Project

Follow the steps below to clone, configure, and run the application locally.

1. Clone the Repository

Use the GitHub CLI:
```
gh repo clone geo2bou/Blazor-Project-main
```
Or with git:
```
git clone https://github.com/geo2bou/Blazor-Project-main.git
```
2. Navigate into the Project Directory
```
cd Blazor-Project-main
```
3. Apply Entity Framework Migrations and Create the Database

Run the following commands to apply the initial migration and update the database:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Note: Make sure you have the Entity Framework CLI tools installed.
If not, you can install them with:
```
dotnet tool install --global dotnet-ef
```
4. Run the Application

Start the application with:
```
dotnet run
```
