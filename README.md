# Task Manager

It is a small application where the user plans the daily, weekly, monthly tasks.

[View Demo](https://fytasks.azurewebsites.net)

## About The Project

I developed this project with ASP<span></span>.NET Core 5. I used MSSQL as database and Entity Framework as ORM tool. I used tools like Autofac, AutoMapper and FluentValidation. I tried to develop a project in accordance with SOLID principles. I added features like photo upload, SweetAlert. I used Bootstrap and jQuery in the design part. I saved the passwords by hashing them into the database. I tried to avoid code duplication. I used the code-first technique while developing the database.

### Built With
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core)
- [MSSQL](https://www.microsoft.com/en-us/sql-server)
- [Bootstrap](https://getbootstrap.com)
- [JQuery](https://jquery.com)
- [Autofac](https://autofac.org)
- [AutoMapper](https://automapper.org)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest)

## Getting Started

1. Clone the repo
   ```sh
   git clone https://github.com/furkanyazar/TaskManager.git
   ```
2. Open project from TaskManager.sln
3. View => Solution Explorer => Right click WebApp and click Set as Startup Project
4. View => Other Windows => Package Manager Console => Default Project: DataAccess
5. Run database update code
   ```sh
   update-database
   ```

## Contact

Furkan YAZAR - [furkanyazar9853@gmail.com](mailto:furkanyazar9853@gmail.com) - [LinkedIn](https://www.linkedin.com/in/furkanyazar/)

Project Link: [https://github.com/furkanyazar/TaskManager](https://github.com/furkanyazar/TaskManager)
