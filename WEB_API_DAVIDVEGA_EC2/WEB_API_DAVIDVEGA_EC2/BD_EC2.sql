CREATE DATABASE LifeSure;
use LifeSure;
-- tabla categoria
CREATE TABLE Categoria (
    CategoriaID INT PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL
);

-- Crear tabla de Marca
CREATE TABLE Marca (
    MarcaID INT PRIMARY KEY,
    NombreMarca NVARCHAR(50) NOT NULL
);

-- Crear tabla de Producto
CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY,
    NombreProducto NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    CategoriaID INT,
    MarcaID INT,
    FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID),
    FOREIGN KEY (MarcaID) REFERENCES Marca(MarcaID)
);

-- ingreso de datos a las tablas

INSERT INTO Categoria (CategoriaID, NombreCategoria) VALUES
(1, 'Electrónicos'),
(2, 'Ropa'),
(3, 'Hogar'),
(4, 'Alimentos'),
(5, 'Deportes');

-- Inserción de datos en la tabla Marca
INSERT INTO Marca (MarcaID, NombreMarca) VALUES
(1, 'Sony'),
(2, 'Nike'),
(3, 'Samsung'),
(4, 'Adidas'),
(5, 'KitchenAid');

-- Inserción de datos en la tabla Producto
INSERT INTO Producto (ProductoID, NombreProducto, Precio, CategoriaID, MarcaID) VALUES
(1, 'Televisor LED 4K', 799.99, 1, 3),
(2, 'Zapatillas para correr', 89.99, 2, 2),
(3, 'Lavadora de carga frontal', 499.99, 3, 5),
(4, 'Camiseta deportiva', 24.99, 2, 4),
(5, 'Cafetera de goteo', 69.99, 3, 5);

select * from Categoria
select * from Marca
select * from Producto