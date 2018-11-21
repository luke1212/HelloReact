1. Do Dbfactory
2. To make typewriter work:
   Add dependency by right click on the project--> Project Dependencies 
   Make all the version of the  netcoreappp to the 2.1 in HelloReact.web.csproj
3 github connection: 
   Click Remote --> add --> Remote name: default remote --> URL/Path: GitHubURL --> ok --> type in password
4 database import:
   install many packages: inflector 1.0.0, 
		          microsoft.entityframeworkCore.design 2.1.4,
		          microsoft.entityframeworkCore.sqlserver 2.1.4,
			  microsoft.NetCore.App 2.1.0
5 StartUp connenct to HelloReact Database
	 .UseSqlServer("Server=localhost;Database=HelloReact;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true")
  

#Scaffoled Db Command
- Ensure HelloReact.Data is startup project
- Use PackageManager Console with HelloReact.Data selected
- Scaffold-DbContext "Server=localhost;Database=HelloReact;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Context HelloReact-Force
