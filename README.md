# Templates.NET

## 1. Templates

| Name | Projects | Frameworks |
| --- | --- | --- |
| TemplatesDotNet/BaseTemplate | 1. ApiApplication <br> 2. ClientApplication <br> 3. Domain <br> 4. Infra <br> 5. WebApplication | 1. EntityFramework <br> 2. EntityFramework.SQLServer <br> 3. Swagger <br> 4. MediatR |
| TemplatesDotNet/BaseTemplate/Signalr | 1. ApiApplication <br> 2. ClientApplication <br> 3. Domain <br> 4. Infra <br> 5. WebApplication | 1. EntityFramework <br> 2. EntityFramework.SQLServer <br> 3. Swagger <br> 4. MediatR <br> 5. SignalR |

## 2. Create Template in local Machine
Ir para o template que você quer criar na máquina.
> cd ~/Templates.NET\templates\BaseApplication  
> dotnet new -i .\

## 3. Delete Template in local Machine
Ir para o template que você quer criar na máquina.
>  dotnet new -u \[localproject\]\Templates.NET\templates\BaseApplication

## 4. Create new project with this template
> dotnet new TemplatesDotNetBaseTemplate --appName YourApplicationName -o YourApplicationNameFolderOptional
