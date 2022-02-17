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

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

    CREATE PROCEDURE [dbo].[AgregarPeliculaProtagonista] 
        @PeliculaID INT = NULL,
        @NombreProtagonista VARCHAR(100) = NULL,
        @ProtagonistaID INT = NULL
    AS 
    BEGIN

        SELECT TOP (1) @ProtagonistaID = ProtagonistaID 
        FROM Protagonista 
        WHERE LOWER(NombreProtagonista) = LOWER(TRIM(@NombreProtagonista))

        IF (@ProtagonistaID IS NULL)
        BEGIN
            INSERT INTO Protagonista VALUES (@NombreProtagonista)
            SELECT TOP (1) @ProtagonistaID = ProtagonistaID FROM Protagonista ORDER BY ProtagonistaID DESC
        END

        INSERT INTO PeliculaProtagonista VALUES (@PeliculaID, @ProtagonistaID)

        SELECT *
        FROM Protagonista 
        WHERE ProtagonistaID = @ProtagonistaID
        
    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

    ALTER PROCEDURE [dbo].[BorrarPelicula] 
        @PeliculaID INT = NULL
    AS 
    BEGIN

        SELECT P.*, C.DescripcionCorta, C.DescripcionLarga, D.NombreDirector, PP.Poster
        FROM Pelicula P 
            INNER JOIN Categoria C ON P.CategoriaID = C.CategoriaID
            LEFT JOIN Director D ON D.DirectorID = P.DirectorID
            LEFT JOIN PosterPelicula PP ON P.PeliculaID = PP.PeliculaID 
        WHERE P.PeliculaID = ISNULL(@PeliculaID, P.PeliculaID)

        DELETE FROM PeliculaProtagonista
        WHERE PeliculaID = @PeliculaID

        DELETE FROM PosterPelicula
        WHERE PeliculaID = @PeliculaID

        DELETE FROM Pelicula
        WHERE PeliculaID = @PeliculaID

    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- EXEC dbo.CargarListaActores
    -- EXEC dbo.CargarListaActores @PeliculaID=17
    CREATE PROCEDURE [dbo].[CargarListaActores] 
        @PeliculaID INT = NULL
    AS 
    BEGIN

        SELECT P.ProtagonistaID, P.NombreProtagonista
        FROM PeliculaProtagonista PP 
            INNER JOIN Protagonista P ON PP.ProtagonistaID =    P.ProtagonistaID
        WHERE PP.PeliculaID = ISNULL(@PeliculaID, PP.PeliculaID)

    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- EXEC dbo.CargarListaPeliculas 
    ALTER PROCEDURE [dbo].[CargarListaPeliculas] 
        @PeliculaID INT = NULL
    AS 
    BEGIN

        SELECT P.*, C.DescripcionCorta, C.DescripcionLarga, D.NombreDirector, PP.Poster
        FROM Pelicula P 
            INNER JOIN Categoria C ON P.CategoriaID = C.CategoriaID
            LEFT JOIN Director D ON D.DirectorID = P.DirectorID
            LEFT JOIN PosterPelicula PP ON P.PeliculaID = PP.PeliculaID 
        WHERE P.PeliculaID = ISNULL(@PeliculaID, P.PeliculaID)

    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- EXEC dbo.CargarProtagonistas @PeliculaID=1 
    CREATE PROCEDURE [dbo].[CargarProtagonistas]
    -- DECLARE
        @PeliculaID INT = NULL
    AS 
    BEGIN

        SELECT P.ProtagonistaID 'ProtagonistaID', P.NombreProtagonista 'NombreProtagonista'
        FROM PeliculaProtagonista PP INNER JOIN Protagonista P ON PP.ProtagonistaID = P.ProtagonistaID
        WHERE PP.PeliculaID = @PeliculaID

    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- EXEC dbo.DeletePeliculaProtagonista @PeliculaID=15, @ProtagonistaID=4

    -- INSERT INTO PeliculaProtagonista VALUES (15,4), (15,3)

    CREATE PROCEDURE [dbo].[DeletePeliculaProtagonista] 
        @PeliculaID INT = NULL,
        @ProtagonistaID INT = NULL
    AS 
    BEGIN

        SELECT P.ProtagonistaID, P.NombreProtagonista
        FROM PeliculaProtagonista PP INNER JOIN Protagonista P ON PP.ProtagonistaID = P.ProtagonistaID
        WHERE PeliculaID = @PeliculaID AND P.ProtagonistaID = @ProtagonistaID

        DELETE FROM PeliculaProtagonista
        WHERE PeliculaID = @PeliculaID AND ProtagonistaID = @ProtagonistaID

    END
    GO

    --
    --
    --

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- EXEC dbo.CargarListaPeliculas 
    CREATE PROCEDURE [dbo].[GuardarPelicula](
        @PeliculaID INT = 0,
        @NombrePelicula VARCHAR(100),
        @Duracion DECIMAL(5, 2) = NULL,
        @CategoriaID INT = NULL,
        @DirectorID INT = NULL,
        @Poster VARCHAR(MAX) = NULL
    )AS 
    BEGIN

        IF(@PeliculaID = 0)
        BEGIN
            INSERT INTO dbo.Pelicula VALUES (@NombrePelicula, @Duracion, @CategoriaID, @DirectorID)
            SELECT TOP (1) @PeliculaID = P.PeliculaID FROM dbo.Pelicula P ORDER BY P.PeliculaID DESC
        END

        ELSE
        BEGIN
            UPDATE dbo.Pelicula
            SET 
                NombrePelicula = ISNULL(@NombrePelicula, NombrePelicula),
                Duracion = ISNULL(@Duracion, Duracion),
                CategoriaID = ISNULL(@CategoriaID, CategoriaID),
                DirectorID = ISNULL(@DirectorID, DirectorID)
            WHERE PeliculaID = @PeliculaID
        END

        IF(@Poster IS NOT NULL)
        BEGIN
            IF (@PeliculaID NOT IN (SELECT P.PeliculaID FROM dbo.PosterPelicula P))
                INSERT INTO dbo.PosterPelicula VALUES (@PeliculaID, @Poster)
            ELSE
                UPDATE dbo.PosterPelicula 
                SET Poster = @Poster
                WHERE PeliculaID = @PeliculaID
        END

        -- return de pelicula
        SELECT P.*, C.DescripcionCorta, C.DescripcionLarga, D.NombreDirector, PP.Poster
        FROM Pelicula P 
            INNER JOIN Categoria C ON P.CategoriaID = C.CategoriaID
            LEFT JOIN Director D ON D.DirectorID = P.DirectorID
            LEFT JOIN PosterPelicula PP ON P.PeliculaID = PP.PeliculaID 
        WHERE P.PeliculaID = ISNULL(@PeliculaID, P.PeliculaID)

    END
    GO
