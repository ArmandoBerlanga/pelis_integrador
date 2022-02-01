-- 1) CREACION DE LA BD
    CREATE DATABASE ActividadDiagnostico  
      
-- 2) CREATES DE LAS TABLAS
    CREATE TABLE Categoria (
        CategoriaID INT PRIMARY KEY IDENTITY(1,1),
        DescripcionCorta VARCHAR(20) NOT NULL,
        DescripcionLarga VARCHAR(100)
    )

    CREATE TABLE Director(
        DirectorID INT PRIMARY KEY IDENTITY(1,1),
        NombreDirector VARCHAR(100) NOT NULL
    )

    CREATE TABLE PeliculaID(
        PeliculaID INT PRIMARY KEY IDENTITY(1,1),
        NombrePelicula VARCHAR(100) NOT NULL,
        Duracion DECIMAL(5,2) NOT NULL DEFAULT 0.0,
        CategoriaID INT FOREIGN KEY REFERENCES Categoria(CategoriaID),
    )

    CREATE TABLE Protagonista(
        ProtagonistaID INT PRIMARY KEY IDENTITY(1,1),
        NombreProtagonista VARCHAR(100) NOT NULL
    )

    CREATE TABLE PeliculaProtagonista(
        PeliculaID INT FOREIGN KEY REFERENCES PeliculaID(PeliculaID),
        ProtagonistaID INT FOREIGN KEY REFERENCES Protagonista(ProtagonistaID)

        CONSTRAINT PK_PeliProta PRIMARY KEY (PeliculaID, ProtagonistaID)
    )
