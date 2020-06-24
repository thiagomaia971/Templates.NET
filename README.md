# Templates.NET

## 1. BaseApplication

### 1.1. Description

Projects:
1. ApiApplication
1. ClientApplication
1. Domain
1. Infra
1. WebApplication

Frameworks:
1. EntityFramework
1. EntityFramework.SQLServer
1. Swagger
1. MediatR


### 1.2 Create Template in local Machine
> cd ~/Templates.NET\templates\BaseApplication  
> dotnet new -i .\

### 1.3 Delete Template in local Machine
>  dotnet new -u \[localproject\]\Templates.NET\templates\BaseApplication

### 1.4 Create new project with this template
> dotnet new TemplatesDotNetBaseTemplate --appName YourApplicationName -o YourApplicationNameFolderOptional
