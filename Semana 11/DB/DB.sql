CREATE DATABASE Ejemplo;

USE Ejemplo;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    Contrasena NVARCHAR(255) NOT NULL, -- Almacenamos la contraseña
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    FechaCreacion DATETIME DEFAULT GETDATE()
)

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10,2) NOT NULL,
    IdUsuario INT NOT NULL, -- Relacion con el usuario que creo el producto
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
)

SELECT * FROM Usuarios;