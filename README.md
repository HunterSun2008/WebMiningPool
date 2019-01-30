# WebMiningPool

##Use Mysql running in docker
```
1. sudo docker pull mysql/mysql-server:8.0
2. sudo docker run --name=mysql-dev -p 3306:3306 -d mysql/mysql-server:8.0
3. sudo docker logs mysql-dev 2>&1 | grep GENERATED
       GENERATED ROOT PASSWORD: Axegh3kAJyDLaRuBemecis&EShOs
4. sudo docker exec -it mysql-dev mysql -uroot -p
5. ALTER USER 'root'@'localhost' IDENTIFIED BY 'password';
    5.1 CREATE USER 'admin'@'localhost' IDENTIFIED BY 'admin1@3';
    5.2 CREATE USER 'admin'@'%' IDENTIFIED BY 'admin1@3';
    5.3 GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost';
    5.4 GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%';
    5.5 FLUSH PRIVILEGES;
```

#Add required NuGet packages
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package MySql.Data.EntityFrameworkCore
    dotnet add package SapientGuardian.EntityFrameworkCore.MySql

## set connection string
    "ConnectionStrings": {
    "MovieContext": "server=localhost;port=3306;userid=admin;password=admin1@3;database=test;"
    }

## use module
    using Microsoft.EntityFrameworkCore;
    using MySql.Data.EntityFrameworkCore;         

## Register the database context    
    services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("MovieContext")));

## Scaffold the movie model
    dotnet tool install --global dotnet-aspnet-codegenerator
    dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

## Initial migration
    dotnet ef migrations add InitialCreate
    dotnet ef database update

