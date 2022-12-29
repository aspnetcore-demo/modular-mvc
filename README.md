# Modular Monolith in ASP.NET Core MVC

This is a sample application creating modular monolith in ASP.NET Core MVC application.

ASP.NET Core MVC `Areas` is a feature that helps us divide our large application into a small logical group.

Areas help us manage application in a better way to separate each functional aspect into different modules.

Each module has its own MVC structure by having subfolders for Models, Views, and Controller. For example, in an organization application, we will have a separate area for Employee, Department, Payroll, Attendance, Expense, etc.

[For more detailed description](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/areas)


## Application Structure
ModularMonolith is the main application. It has default Models, Views and Controllers. 

`Modules` folder contains the modular MVC applications.

 
