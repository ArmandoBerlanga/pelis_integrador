Para la construccion de la WEB API:

1- Primero correr la creacion de modelos (simplifica el NO tener que hacerlo)

dotnet ef dbcontext Scaffold "Server=localhost,1433;Database=ActividadDiagnostico;User=sa;Password=Pass123*;" Microsoft.EntityFrameworkCore.SqlServer -o Models


2- Por cada modelo corerrer el siguiente comando

dotnet aspnet-codegenerator controller -name CategoriaController -async -api -m Categoria -dc ActividadDiagnosticoContext -outDir Controllers



dotnet aspnet-codegenerator controller -name CategoriaController -async -api -m Categorium -dc ActividadDiagnosticoContext -outDir Controllers