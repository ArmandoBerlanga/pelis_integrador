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

    CREATE TABLE Pelicula(
        PeliculaID INT PRIMARY KEY IDENTITY(1,1),
        NombrePelicula VARCHAR(100) NOT NULL,
        Duracion DECIMAL(5,2) NOT NULL DEFAULT 0.0,
        CategoriaID INT FOREIGN KEY REFERENCES Categoria(CategoriaID),
        DirectorID INT FOREIGN KEY REFERENCES Director(DirectorID)
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

    CREATE TABLE PosterPelicula(
        PeliculaID INT NOT NULL FOREIGN KEY REFERENCES Pelicula(PeliculaID),
        Poster VARCHAR(MAX)
    )

-- 3) SPS

    -- EXEC dbo.CargarListaPeliculas 
    ALTER PROCEDURE dbo.CargarListaPeliculas 
    AS 
    BEGIN

        SELECT P.*, C.DescripcionCorta, C.DescripcionLarga, D.NombreDirector, PP.Poster
        FROM Pelicula P 
            INNER JOIN Categoria C ON P.CategoriaID = C.CategoriaID
            INNER JOIN Director D ON D.DirectorID = P.DirectorID
            LEFT JOIN PosterPelicula PP ON P.PeliculaID = PP.PeliculaID 

    END

    --
    --
    --
