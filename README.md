### BookApp
A small project based on selected chapters of [Microservices in .NET, Second Edition](https://www.manning.com/books/microservices-in-net-second-edition) by Jon Smith.


### Requirements before running any EF Core migration command

To run any of the EF Core migration tools’ commands, you need to install the the CLI tools on your development computer via the appropriate command prompt. The following command will install the dotnet-ef tools globally so that you can use them in any directory:

```
dotnet tool install --global dotnet-ef --version 8.0.7
```

To get this project up and running, type:

```
dotnet ef database update
```
and place all your queries inside the Main function.

### DataBase Schema

![GitHub Logo](/images/diagram.png)


