
Scaffold-DbContext "Server=ServerName\SQLEXPRESS;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext -Tables TblPieChart

//EF Core Installation For Command
dotnet tool install --global dotnet-ef --version 7.0.0

//For Terminal
dotnet ef dbcontext scaffold "Server=ServerName;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f

EF Core Database First => Make Proj , Make Class Libraries, and Proj using reference from Class Libraries


