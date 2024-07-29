### BookApp
A small project based on selected chapters of [Microservices in .NET, Second Edition](https://www.manning.com/books/microservices-in-net-second-edition) by Jon Smith.


### Databases

This project uses the following databases:

* SQL Server 2022 Express Edition 
* MongoDB Community Server v7.0.8

### Entity Framework Core tools

To set up the database on your computer via CLI, the following command will install the dotnet-ef tools globally so that you can use them in any directory:

```
dotnet tool install --global dotnet-ef --version 8.0.7
```

To get this project up and running, type:

```
dotnet ef database update -project BookApp.Data --context SqlContext
```

And place all your queries inside the Main function.

### Database Schema

![GitHub Logo](/images/diagram.png)