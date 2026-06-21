-- CREATE TABLE Categoria (
--     Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
--     Descripcion VARCHAR(80) NULL,
--     Estado BIT DEFAULT 1 NOT NULL
-- )

-- CREATE PROCEDURE listarCategorias AS
-- SELECT Id,Descripcion, Estado FROM Categoria

    -- CREATE PROCEDURE AgregarCategoria 
    --     @Descripcion VARCHAR(80)
    --     AS
    --     INSERT INTO Categoria (Descripcion) VALUES (@Descripcion)

--  CREATE PROCEDURE ModificarCategoria 
--     @Id INT,
--     @Descrip VARCHAR(80)
--     AS
--     UPDATE Categoria SET Descripcion = @Descrip WHERE Id = @id

-- CREATE PROCEDURE BuscarCategoriaSeleccionado 
--     @IdCategoria INT
--     AS 
--     SELECT Id, Descripcion,Estado FROM Categoria WHERE Id = @IdCategoria 

-- CREATE PROCEDURE CambiarEstadoCategoria 
--     @Id INT,
--     @Estado BIT
--     AS
--     UPDATE Categoria SET Estado = @Estado WHERE Id = @Id



-- CREATE TABLE FormaDePago(
--     Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--     Descripcion VARCHAR(80) NULL,
--     Estado BIT DEFAULT 1 NOT NULL
-- )

-- -- INSERT INTO FormaDePago (Descripcion) VALUES ('Criptomoneda'), ('Tarjeta de debito'), ('Tarjeta de credito')

-- CREATE PROCEDURE listarFormasDePagos AS(
--     SELECT Id, Descripcion, Estado FROM FormaDePago
-- -- )

-- CREATE PROCEDURE AgregarFormaDePago 
--     @Descripcion VARCHAR (80)
--     AS
-- --     INSERT INTO FormaDePago(Descripcion) VALUES (@Descripcion)

-- CREATE PROCEDURE ModificarFormaDePago
--     @Id INT,
--     @Descripcion VARCHAR(80)
--     AS
--     UPDATE FormaDePago SET Descripcion = @Descripcion WHERE Id = @Id

-- CREATE PROCEDURE BuscarFormaDePago 
--     @Id INT
--     AS
-- --     SELECT Id, Descripcion, Estado FROM FormaDePago WHERE Id = @Id

-- CREATE PROCEDURE CambiarEstadoFormaDePago 
--     @Id INT,
--     @Estado BIT
--     AS
--     UPDATE FormaDePago SET Estado = @Estado WHERE Id = @Id

--MARCAS
-- CREATE TABLE Marca(
--     Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--     Descripcion VARCHAR(40) NULL,
--     UrlImagen VARCHAR(2000) NOT NULL,
--     Estado BIT NOT NULL DEFAULT 1
-- );

-- CREATE PROCEDURE ListarMarcas 
--     AS
--     SELECT Id, Descripcion, UrlImagen, Estado  FROM Marca


-- CREATE PROCEDURE BuscarMarca 
--     @Id INT
--     AS
--     SELECT Id, Descripcion, UrlImagen, Estado FROM Marca WHERE Id = @Id

-- CREATE PROCEDURE AgregarMarca 
-- --     @Descripcion VARCHAR(40),
-- --     @UrlImagen VARCHAR(2000)
-- --     AS
-- --     INSERT INTO Marca (Descripcion, UrlImagen) VALUES (@Descripcion,@UrlImagen)

--CREATE PROCEDURE ModificarMarca 
--     @Id INT,
--     @Descripcion  VARCHAR(40),
--     @UrlImagen VARCHAR(2000)
--     AS
--     UPDATE Marca SET Descripcion = @Descripcion, UrlImagen = @UrlImagen WHERE Id = @Id

--     CREATE PROCEDURE CambiarEstadoMarca 
--     @Id INT,
--     @Estado BIT
--     AS
--     UPDATE Marca SET Estado = @Estado WHERE Id = @Id

--TipoUsuario

-- CREATE TABLE TipoUsuario(
--     Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--     Descripcion VARCHAR(50)
-- )

-- --Usuario
-- CREATE TABLE Usuario (
--     Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--     Nombre VARCHAR(70) NULL,
--     Apellido VARCHAR(70) NULL,
--     Telefono VARCHAR(12) NULL,
--     Dni VARCHAR(8) NULL, 
--     Email VARCHAR(150) NOT NULL,
--     Pass VARCHAR(70) NOT NULL,
--     FechaNacimiento DATETIME NULL,
--     IdTipoUsuario INT FOREIGN KEY(IdTipoUsuario) REFERENCES TipoUsuario(Id) NOT NULL,
--     ImagenPefil VARCHAR(2000) NULL,
--     Estado BIT DEFAULT 1 NOT NULL
-- )
-- ALTER PROCEDURE VerificarLogin 
--     @Email VARCHAR(150),
--     @Pass VARCHAR(70)
--     AS
--     SELECT Id,Nombre, Apellido, Telefono, Dni, FechaNacimiento, ImagenPefil, IdTipoUsuario, Estado 
--     FROM Usuario TU WHERE Email = @Email AND Pass = @Pass AND Estado = 1

-- CREATE PROCEDURE EditarPerfil
-- --     @Id INT, 
-- --     @Nombre VARCHAR(70),
-- --     @Apellido  VARCHAR(70),
-- --     @Telefono VARCHAR(12),
-- --     @Dni VARCHAR(12),
-- --     @FechaNacimiento DATETIME,
-- --     @UrlImagen VARCHAR(2000)
-- --     AS
-- --     UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, 
-- --     Telefono = @Telefono, Dni = @Dni, FechaNacimiento = @FechaNacimiento,
-- --     ImagenPefil = @UrlImagen WHERE Id = @Id

--Direccion

-- CREATE TABLE Direccion(
--     Id INT IDENTITY(1,1) NOT NULL,
--     IdUsuario INT FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id) NOT NULL,
--     Calle VARCHAR(33) NOT NULL,
--     Altura INT NOT NULL,
--     Piso VARCHAR(8) NULL,
--     Departamento VARCHAR(10) NULL,
--     CodigoPostal VARCHAR(8),
--     Localidad VARCHAR(50) NOT NULL,
--     Observacion VARCHAR(200) NULL,
--     Estado BIT DEFAULT 1 NOT NULL   
-- )

-- CREATE PROCEDURE AgregarDireccionUsuario
--     @IdUsuario INT,
--     @Calle VARCHAR(33),
--     @Altura INT,
--     @Piso VARCHAR(8),
--     @Departamento VARCHAR(10),
--     @CodPostal VARCHAR(8),
--     @Localidad VARCHAR(50),
--     @Observacion VARCHAR(200)
--     AS
--     INSERT INTO Direccion (IdUsuario,Calle,Altura,Piso,Departamento,CodigoPostal,Localidad,Observacion)
--     VALUES (@IdUsuario,@Calle,@Altura,@Piso,@Departamento,@CodPostal,@Localidad,@Observacion);


-- CREATE PROCEDURE listarDomiciliosUsuarios
--     @IdUsuario INT
--     AS
--     SELECT Id, Calle, Altura, Piso, Departamento, CodigoPostal, Localidad, Observacion, Estado   
--     FROM Direccion WHERE IdUsuario = @IdUsuario

-- CREATE PROCEDURE BuscarDireccion
--     @IdDireccion INT
--     AS
--     SELECT Id, IdUsuario, Calle, Altura, Piso, Departamento, CodigoPostal, Localidad, Observacion, Estado   
--     FROM Direccion WHERE Id = @IdDireccion

-- CREATE PROCEDURE ModificarDireccion
--     @Id INT,
--     @Calle VARCHAR(33),
--     @Altura INT,
--     @Piso VARCHAR(8),
--     @Departamento VARCHAR(10),
--     @CodPostal VARCHAR(8),
--     @Localidad VARCHAR(50),
--     @Observacion VARCHAR(200)
--     AS
--     UPDATE Direccion SET Calle = @Calle, Altura = @Altura, Piso = @Piso, Departamento = @Departamento, 
--     CodigoPostal = @CodPostal, Localidad = @Localidad, Observacion = @Observacion WHERE Id = @Id
