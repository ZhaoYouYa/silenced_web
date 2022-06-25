## 1. Create a project

```powershell

dotnet new sln # Create a project that have same name with the dir

dotnet new webapi -o Main # Create Main Project

dotnet sln add Main/Main.csproj # add a project to the solution

cd Main 

dotnet run # ./swagger/index.html to see the api swagger


dotnet new classlib -o DesktopTool # add a lib

dotnet sln add DesktopTool/DesktopTool.csproj # add the lib to the solution


dotnet add package  Microsoft.AspNetCore.App # add a package to the lib(DesktopTool)


cd Main 
dotnet add reference ../DesktopTool/DesktopTool.csproj # add a reference to the project


```

```powershell

```

then, 

```powershell

dotnet run 


```

## 2. Add a package