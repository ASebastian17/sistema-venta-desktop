
/****************************************************
*	Proyecto Final de Aplicación de Base de Datos	*
*													*
*													*
*	   Alumno: Guerra Morales Armando Sebastian		*
*													*
*		   Universidad Nacional del Callao			*
*													*
*													*
*****************************************************/
--
--
-- SQL Server 2019
-- SSMS 18
--
-- Idioma del SQL: us_english
--
SET LANGUAGE us_english
GO

--
-- Creación de la base de datos
--

CREATE DATABASE TIENDA_ABD2020
GO

USE TIENDA_ABD2020
GO

--
-- Creación de las tablas
--

CREATE TABLE Producto
(
	IdProducto CHAR(5) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	Marca VARCHAR(50) NOT NULL,
	Stock INT NOT NULL,
	PrecioUnit MONEY NOT NULL,
	Categoria INT NOT NULL,
	Proveedor CHAR(5) NOT NULL
)
GO

CREATE TABLE Categoria
(
	IdCategoria INT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Empleado
(
	IdEmpleado CHAR(5) NOT NULL,
	Contraseña VARCHAR(15),
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	Edad TINYINT NOT NULL,
	DNI INT NOT NULL,
	Genero CHAR(1) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Teléfono VARCHAR(10) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Sueldo MONEY NOT NULL,
	Fecha_Ingreso DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
	Fecha_Nac DATE NOT NULL,
	Cargo INT NOT NULL
)
GO

CREATE TABLE Cargo
(
	IdCargo INT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Cliente
(
	IdCliente INT NOT NULL IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	Edad TINYINT NOT NULL,
	DNI INT NOT NULL,
	Genero CHAR(1) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Teléfono VARCHAR(10),
	Email VARCHAR(50),
	RUC VARCHAR(20),
	Fecha_Nac DATE NOT NULL,
)
GO

CREATE TABLE Proveedor
(
	IdProveedor CHAR(5) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Telefono VARCHAR(10) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Venta
(
	IdVenta INT NOT NULL IDENTITY,
	Cliente INT NOT NULL,
	Vendedor CHAR(5) NOT NULL,
	Fecha DATETIME NOT NULL,
	Subtotal MONEY NOT NULL,
	IGV MONEY NOT NULL,
	Total MONEY NOT NULL
)
GO

CREATE TABLE Detalle_Venta
(
	IdVenta INT NOT NULL,
	IdProducto CHAR(5) NOT NULL,
	Cantidad INT NOT NULL,
	Precio_Venta MONEY NOT NULL,
	Descuento MONEY
)
GO

--
-- Agregamos los constraints
--

-- Primary Keys (PK)
ALTER TABLE Producto
ADD CONSTRAINT PK_Producto_IdProducto
PRIMARY KEY (IdProducto)
GO

ALTER TABLE Categoria
ADD CONSTRAINT PK_Categoria_IdCategoria
PRIMARY KEY (IdCategoria)
GO

ALTER TABLE Empleado
ADD CONSTRAINT Pk_Empleado_IdEmpleado
PRIMARY KEY (IdEmpleado)
GO

ALTER TABLE Cargo
ADD CONSTRAINT Pk_Cargo_IdCargo
PRIMARY KEY (IdCargo)
GO

ALTER TABLE Cliente
ADD CONSTRAINT Pk_Cliente_IdCliente
PRIMARY KEY (IdCliente)
GO

ALTER TABLE Proveedor
ADD CONSTRAINT Pk_Proveedor_IdProveedor
PRIMARY KEY (IdProveedor)
GO

ALTER TABLE Venta
ADD CONSTRAINT Pk_Venta_IdVenta
PRIMARY KEY (IdVenta)
GO

ALTER TABLE Detalle_Venta
ADD CONSTRAINT Pk_DetalleVenta_IdVenta_IdProducto
PRIMARY KEY (IdVenta, IdProducto)
GO

-- Foreign Keys (FK)
ALTER TABLE Producto
ADD CONSTRAINT FK_Producto_Categoria
FOREIGN KEY (Categoria) REFERENCES Categoria(IdCategoria)
GO

ALTER TABLE Producto
ADD CONSTRAINT FK_Producto_Proveedor
FOREIGN KEY (Proveedor) REFERENCES Proveedor(IdProveedor)
GO

ALTER TABLE Empleado
ADD CONSTRAINT FK_Empleado_Cargo
FOREIGN KEY (Cargo) REFERENCES Cargo(IdCargo)
GO

ALTER TABLE Venta
ADD CONSTRAINT FK_Venta_Cliente
FOREIGN KEY (Cliente) REFERENCES Cliente(IdCliente)
GO

ALTER TABLE Venta
ADD CONSTRAINT FK_Venta_Vendedor
FOREIGN KEY (Vendedor) REFERENCES Empleado(IdEmpleado)
GO

ALTER TABLE Detalle_Venta
ADD CONSTRAINT FK_DetalleVenta_IdVenta
FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta)
ON DELETE CASCADE
GO

ALTER TABLE Detalle_Venta
ADD CONSTRAINT FK_DetalleVenta_IdProducto
FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
GO

-- Check (CK)
ALTER TABLE Producto
ADD CONSTRAINT Ck_Producto_IdProducto
CHECK (IdProducto LIKE 'P[0-9][0-9][0-9][0-9]' AND IdProducto <> 'P0000')
GO

ALTER TABLE Empleado
ADD CONSTRAINT Ck_Empleado_IdEmpleado
CHECK (IdEmpleado LIKE 'E[0-9][0-9][0-9][0-9]' AND IdEmpleado <> 'E0000')
GO

ALTER TABLE Empleado
ADD CONSTRAINT Ck_Empleado_Genero
CHECK (Genero = 'M' OR Genero = 'F')
GO

ALTER TABLE Empleado
ADD CONSTRAINT Ck_Empleado_FechaNac
CHECK (Fecha_Ingreso > Fecha_Nac)
GO

ALTER TABLE Cliente
ADD CONSTRAINT Ck_Cliente_Genero
CHECK (Genero = 'M' OR Genero = 'F')
GO

ALTER TABLE Proveedor
ADD CONSTRAINT Ck_Proveedor_IdProveedor
CHECK (IdProveedor LIKE 'S[0-9][0-9][0-9][0-9]' AND IdProveedor <> 'S0000')
GO

-- Unique (UN)
ALTER TABLE Empleado
ADD CONSTRAINT UN_Empleado_DNI
UNIQUE (DNI)
GO

ALTER TABLE Empleado
ADD CONSTRAINT UN_Empleado_Email
UNIQUE (Email)
GO

ALTER TABLE Cliente
ADD CONSTRAINT UN_Cliente_DNI
UNIQUE (DNI)
GO

ALTER TABLE Proveedor
ADD CONSTRAINT UN_Proveedor_Email
UNIQUE (Email)
GO

-----------------------------------
-- Insertamos Algunos datos -------
-----------------------------------
SET DATEFORMAT 'DMY'
GO

INSERT INTO Cargo VALUES
(1, 'Administrador'), 
(2, 'Cajero'),
(3, 'Personal de Limpieza'),
(4, 'Personal de Seguridad'),
(5, 'Encargado de Almacén')
GO

INSERT INTO Empleado VALUES 
('E0001', 'sebas123','Sebastian', 'Guerra Morales', 20, 77745987, 'M', 'Callao', '999448958', 'armasebas17@hotmail.com', 2700, '12-01-2020', '17-05-2000', 1),
('E0002', 'abcde','Luis', 'Bermudez Carrera', 26, 77653984, 'M', 'Callao', '987654321', 'luisbc01@gmail.com', 2000, '15-01-2020', '01-03-1994', 2),
('E0003', '12345','Elizabeth', 'Garay Mendoza', 28, 79846513, 'F', 'Los Olivos', '978159735', 'eligaray@gmail.com', 1800, '16-01-2020', '05-04-1996', 2),
('E0004', 'qwerty','Juan Carlos', 'Mendoza Ramos', 35, 74516892, 'M', 'Bellavista', '997567894', 'mendozajc@gmail.com', 1800, '23-01-2020', '23-07-1985', 2),
('E0005', 'asdfgh','Andrea', 'Palacios Leyva', 30, 77269468, 'F', 'La Punta', '913451378', 'andreapalacios16@gmail.com', 1600, '05-02-2020', '16-11-1989', 2),
('E0006', 'zxcvbn','Marco Antonio', 'Vargas Herrera', 22, 77776158, 'M', 'Ventanilla', '997853157', 'marcoantoniovh@gmail.com', 1500, '09-03-2020', '28-04-1998', 2),
('E0007', NULL,'Jesus', 'Torres Quispe', 46, 73294683, 'M', 'Callao', '978159753', 'torresjesus2110@hotmail.com', 1400, '21-01-2020', '21-10-1973', 3),
('E0008', NULL,'Milagros', 'Cupe Delgado', 30, 74568712, 'F', 'Bellavista', '978942678', 'milagroscd1990@hotmail.com', 1400, '16-02-2020', '05-08-1990', 3),
('E0009', NULL,'Daniel', 'Vicente Campos', 31, 79865432, 'M', 'La Perla', '978998689', 'danielv2908@gmail.com', 1500, '29-01-2020', '29-08-1988', 4),
('E0010', 'asdfgh', 'Dylan', 'Duarte Salazar', 20, 1, 'M', 'Callao', '000000000', 'ds@hotmail.com', 1900, '13-08-2020', '01-08-2000', 5)
GO

INSERT INTO Categoria VALUES
(1, 'Cuadernos y Blocks'),
(2, 'Útiles'),
(3, 'Papelería'),
(4, 'Cintas y Pegamentos'),
(5, 'Pintura'),
(6, 'Archivo'),
(7, 'Articulos de Escritorio')
GO

INSERT INTO Proveedor VALUES
('S0001', 'Proveedor A', '945687123', 'San Isidro', 'proveedor_a@gmail.com'),
('S0002', 'Proveedor B', '978456832', 'San Juan de Lurigancho', 'proveedor_b@gmail.com'),
('S0003', 'Proveedor C', '987458973', 'Cercado de Lima', 'proveedor_c@gmail.com'),
('S0004', 'Proveedor D', '999666333', 'Cercado de Lima', 'proveedor_d@gmail.com')
GO

INSERT INTO Producto VALUES
-- Categoria 1
('P1001', 'Cuaderno DLX A-4 Rayado', 'Loro', 48, 4.70, 1, 'S0001'),
('P1002', 'Cuaderno Anillado A-4 160 H Cuadriculado', 'Arco Iris', 62, 18.40, 1, 'S0002'),
('P1003', 'Cuaderno DLX A-4 Rayado', 'College', 59, 4.90, 1, 'S0001'),
-- Categoria 2
('P2001', 'Bolígrafo 032-M Trilux Azul', 'Faber Castell', 60, 0.70, 2, 'S0001'),
('P2002', 'Bolígrafo 032-M Trilux Negro', 'Faber Castell', 65, 0.70, 2, 'S0001'),
('P2003', 'Bolígrafo 032-M Trilux Rojo', 'Faber Castell', 61, 0.70, 2, 'S0001'),
-- Categoria 3
('P3001', 'Papel Fotocopia 80gr A-4 PQX500', 'Report', 41, 11.40, 3, 'S0002'),
('P3002', 'Papel Fotocopia 75gr Oficio PQX500', 'Report', 40, 14.20, 3, 'S0002'),
-- Categoria 4
('P4001', 'Cola X 60cc Con Aplicador', 'Pegafan', 38, 1.30, 4, 'S0003'),
('P4002', 'Cola X 130cc Con Aplicador', 'Pegafan', 65, 1.90, 4, 'S0003'),
('P4003', 'Cola X 250cc Con Aplicador', 'David', 43, 2.90, 4, 'S0003'),
-- Categoria 5
('P5001', 'Lapiz Carbon Prensado Blanco', 'Faber Castell', 41, 5.80, 5, 'S0001'),
('P5002', 'Estuche de Acuarelas + Pincel', 'Faber Castell', 38, 7.90, 5, 'S0001'),
('P5003', 'Témpera Estuche X7 Puppy', 'Layconsa', 45, 6.00, 5, 'S0003'),
('P5004', 'Témperas X7 Colores + Pincel + Paleta Mezcladora', 'Artesco', 39, 5.90, 5, 'S0003'),
-- Categoria 6
('P6001', 'Sobre Manila A4 PQX50', 'Gallo', 60, 10.80, 6, 'S0002'),
('P6002', 'Sobre Manila Pago PQX50', 'Gallo', 48, 3.30, 6, 'S0002'),
('P6003', 'Sobre Manila Carta PQX50', 'Gallo', 45, 11.90, 6, 'S0002'),
('P6004', 'Portapapel A4 X10', 'Artesco', 50, 3.50, 6, 'S0004'),
-- Categoria 7
('P7001', 'Engrapador 20H Con Sacagrapa', 'Rapid', 40, 65.80, 7, 'S0004'),
('P7002', 'Tablero de Madera A4 Duratex', 'Acrimet', 40, 4.20, 7, 'S0004'),
('P7003', 'Tacho Mediano Circular Negro Tipo Rejilla', 'Ove', 25, 12.40, 7, 'S0004')



GO

INSERT INTO Cliente(Nombre, Apellido, Edad, DNI, Genero, Direccion, Teléfono, Email, RUC, Fecha_Nac) VALUES
('Carlos', 'Hernandez Apaza', 38, 78945114, 'M', 'Callao', '998787898', 'ch1982@gmail.com', NULL, '20-03-1982'),
('Andrea', 'Medina Delgado', 45, 78945118, 'F', 'Bellavista', NULL, 'amd@hotmail.com', NULL, '01-08-1975'),
('Luis', 'Rojas Benites', 22, 78945119, 'M', 'Ventanilla', '998877665', NULL, '1110987654321', '17-01-1998'),
('Ruth', 'Ayala Gayardo', 31, 78945120, 'F', 'Callao', NULL, 'ruth89@hotmail.com', NULL, '05-07-1989'),
('Andres', 'Guzman Salazar', 50, 78945121, 'M', 'La Perla', NULL, NULL, NULL, '29-06-1970'),
('Junior', 'Espinoza Huaman', 38, 78945122, 'M', 'Callao', '999666888', NULL, NULL, '02-01-1982'),
('Maria', 'Malca Garcia', 28, 78945123, 'F', 'La Perla', '987654987', NULL, NULL, '25-02-1992'),
('Kevin', 'Fernandez Ponce', 47, 78945124, 'M', 'Ventanilla', '987456159', NULL, '1234567891011', '15-08-1973')
GO

--------------------------------------------------------------------------
-- Creación de los Procedimientos almacenados a usarse en el programa --
------------------------------------------------------------------------

CREATE PROCEDURE SP_LoginValidation
@Usuario VARCHAR(50)
AS
BEGIN
	SELECT IdEmpleado, Contraseña, Descripcion, Nombre FROM Empleado E
	INNER JOIN Cargo C ON E.Cargo = C.IdCargo
	WHERE IdEmpleado = @Usuario
END
GO

CREATE PROCEDURE SP_BuscarEmpleados
@Nombre VARCHAR(50),
@Cargo VARCHAR(50),
@Direccion VARCHAR(50)
AS
BEGIN
	IF @Cargo = '---' OR @Cargo = ''
		SELECT IdEmpleado, Apellido + ' ' + Nombre AS 'Nombres', Edad, DNI, Genero, Direccion, Teléfono, Email, Sueldo, Fecha_Ingreso, Fecha_Nac, Descripcion As 'Cargo'
		FROM Empleado E
		INNER JOIN Cargo C ON E.Cargo = C.IdCargo
		WHERE Apellido + ' ' + Nombre LIKE '%' + @Nombre +'%' AND Direccion LIKE '%' + @Direccion +'%'
	ELSE
		SELECT IdEmpleado, Apellido + ' ' + Nombre AS 'Nombres', Edad, DNI, Genero, Direccion, Teléfono, Email, Sueldo, Fecha_Ingreso, Fecha_Nac, Descripcion As 'Cargo'
		FROM Empleado E
		INNER JOIN Cargo C ON E.Cargo = C.IdCargo
		WHERE Apellido + ' ' + Nombre LIKE '%' + @Nombre +'%' AND Descripcion = @Cargo AND Direccion LIKE '%' + @Direccion +'%'
END
GO

CREATE PROCEDURE SP_AgregarEmpleados
@Id CHAR(5),
@Contraseña VARCHAR(15),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Edad TINYINT,
@Dni INT,
@Genero CHAR(1),
@Direccion VARCHAR(50),
@Telefono VARCHAR(10),
@Email VARCHAR(50),
@Sueldo MONEY,
@FechaNac DATE,
@Cargo INT
AS
BEGIN
	-- En caso se repita el IdEmpleado
	IF EXISTS (SELECT IdEmpleado FROM Empleado WHERE IdEmpleado = @Id)
		BEGIN
		PRINT 'El Id ingresado ya existe'
		END

	-- En caso se repita el Dni
	IF EXISTS (SELECT DNI FROM Empleado WHERE DNI = @Dni)
		BEGIN
		PRINT 'El Dni ingresado ya existe'
		END

	-- En caso se repita el correo electrónico
	IF EXISTS (SELECT Email FROM Empleado WHERE Email = @Email)
		BEGIN
		PRINT 'El Correo ingresado ya existe'
		END

	IF @Cargo IN (3, 4)
		INSERT INTO Empleado(IdEmpleado, Nombre, Apellido, Edad, DNI, Genero, Direccion, Teléfono, Email, Sueldo, Fecha_Nac, Fecha_Ingreso, Cargo)
		VALUES
		(@Id, @Nombre, @Apellido, @Edad, @Dni, @Genero, @Direccion, @Telefono, @Email, @Sueldo, @FechaNac, CURRENT_TIMESTAMP, @Cargo)
	ELSE
		INSERT INTO Empleado(IdEmpleado, Contraseña, Nombre, Apellido, Edad, DNI, Genero, Direccion, Teléfono, Email, Sueldo, Fecha_Nac, Fecha_Ingreso, Cargo)
		VALUES
		(@Id, @Contraseña, @Nombre, @Apellido, @Edad, @Dni, @Genero, @Direccion, @Telefono, @Email, @Sueldo, @FechaNac, CURRENT_TIMESTAMP, @Cargo)
END
GO

CREATE PROCEDURE SP_BuscarProductos
@Nombre VARCHAR(100),
@Marca VARCHAR(50),
@Categoria VARCHAR(50),
@Proveedor VARCHAR(50),
@PrecioMayorA VARCHAR(4),
@PrecioMenorA VARCHAR(5)
AS
BEGIN
	-- Para que muestre todas las categorias
	IF @Categoria = '---'
		BEGIN
		SET @Categoria = ''
		END
	-- Para que muestre todos los proveedores
	IF @Proveedor = '---'
		BEGIN
		SET @Proveedor = ''
		END
	-- Para comprobar que los precios ingresados sean números
	IF ISNUMERIC(@PrecioMayorA) = 0 OR @PrecioMayorA = ''
		BEGIN
		SET @PrecioMayorA = '0'
		END
	IF ISNUMERIC(@PrecioMenorA) = 0 OR @PrecioMenorA = ''
		BEGIN
		SET @PrecioMenorA = '99999'
		END	
	
	SELECT IdProducto, P.Descripcion, Marca, Stock, PrecioUnit, C.Descripcion AS 'Categoria', PV.Nombre AS 'Proveedor' FROM Producto P
	INNER JOIN Categoria C ON P.Categoria = C.IdCategoria
	INNER JOIN Proveedor PV ON P.Proveedor = PV.IdProveedor
	WHERE	P.Descripcion LIKE '%' + @Nombre + '%' AND 
			P.Marca LIKE '%' + @Marca + '%' AND
			C.Descripcion LIKE '%' + @Categoria + '%' AND
			PV.Nombre LIKE '%' + @Proveedor + '%' AND
			P.PrecioUnit > @PrecioMayorA AND
			P.PrecioUnit < @PrecioMenorA
END
GO

CREATE PROCEDURE SP_MostrarDatosProductoE
@Id VARCHAR(5)
AS
BEGIN
	SELECT P.Descripcion, Marca, Stock, C.Descripcion FROM Producto P
	INNER JOIN Categoria C ON P.Categoria = C.IdCategoria
	WHERE IdProducto = @Id
END
GO

CREATE PROCEDURE SP_AddProdExistente
@Id VARCHAR(5),
@Cantidad INT
AS
BEGIN
	UPDATE Producto
	SET Stock = Stock + @Cantidad
	WHERE IdProducto = @Id
END
GO

CREATE PROCEDURE SP_AddProdNuevo
@id VARCHAR(5),
@descripcion VARCHAR(100),
@marca VARCHAR(50),
@stock INT,
@precio DECIMAL(10, 2),
@categoria INT,
@proveedor VARCHAR(5)
AS
BEGIN
	INSERT INTO Producto VALUES
	(@id, @descripcion, @marca, @stock, @precio, @categoria, @proveedor)
END
GO

CREATE PROCEDURE SP_BuscarClientes
@Nombre VARCHAR(50),
@Direccion VARCHAR(50)
AS
BEGIN
	SELECT IdCliente, Apellido + ' ' + Nombre AS 'Nombres', Edad, DNI, Genero, Direccion, Teléfono, Email, RUC, Fecha_Nac
	FROM Cliente
	WHERE Apellido + ' ' + Nombre LIKE '%' + @Nombre +'%' AND Direccion LIKE '%' + @Direccion +'%'
END
GO

CREATE PROCEDURE SP_AgregarCliente
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Edad TINYINT,
@Dni INT,
@Genero CHAR(1),
@Direccion VARCHAR(50),
@Telefono VARCHAR(10),
@Email VARCHAR(50),
@Ruc VARCHAR(20),
@FechaNac DATE
AS
BEGIN
	-- Valores opcionales
	IF @Telefono = ''
		BEGIN
		SET @Telefono = NULL
		END
	IF @Email = ''
		BEGIN
		SET @Email = NULL
		END
	IF @Ruc = ''
		BEGIN
		SET @Ruc = NULL
		END
	-- Insertar datos
	INSERT INTO Cliente(Nombre, Apellido, Edad, DNI, Genero, Direccion, Teléfono, Email, RUC, Fecha_Nac) 
	VALUES
	(@Nombre, @Apellido, @Edad, @Dni, @Genero, @Direccion, @Telefono, @Email, @Ruc, @FechaNac)
END
GO

CREATE PROCEDURE SP_RlzVentaClienteData
@Dni VARCHAR(10)
AS
BEGIN
	SELECT Apellido + ' ' +Nombre AS 'Nombres', IdCliente FROM Cliente
	WHERE Dni = @Dni
END
GO

CREATE PROCEDURE SP_RlzVentaProductoData
@Id VARCHAR(5)
AS
BEGIN
	SELECT Descripcion, PrecioUnit FROM Producto
	WHERE IdProducto = @Id
END
GO

CREATE PROCEDURE SP_RlzVentaEmpleadoData
@Id VARCHAR(5)
AS
BEGIN
	SELECT Apellido + ' ' +Nombre AS 'Nombres', Dni FROM Empleado
	WHERE IdEmpleado = @Id AND Cargo IN (1, 2)
END
GO

CREATE PROCEDURE SP_RlzVentaCompletarVenta
@Cliente INT,
@Vendedor VARCHAR(5),
@Total MONEY
AS
BEGIN
	DECLARE @Igv MONEY
	DECLARE @Subtotal MONEY

	SET @Igv = @Total * 0.18
	SET @Subtotal = @Total - @Igv

	INSERT INTO Venta(Cliente, Vendedor, Fecha, Subtotal, Igv, Total) VALUES
	(@Cliente, @Vendedor, GETDATE(), @Subtotal, @Igv, @Total)
END
GO

CREATE PROCEDURE SP_RlzVentaIngresarDetalles
@IdProducto VARCHAR(5),
@Cantidad INT,
@Precio MONEY
AS
BEGIN
	DECLARE @Id INT
	SET @Id = (SELECT TOP 1 IdVenta FROM Venta ORDER BY IdVenta DESC)

	-- Reducimos del almacén
	UPDATE Producto
	SET Stock = Stock - @Cantidad
	WHERE IdProducto = @IdProducto

	INSERT INTO Detalle_Venta VALUES
	(@Id, @IdProducto, @Cantidad, @Precio, 0)
END
GO

CREATE PROCEDURE SP_VentasRealizadas
AS
BEGIN
	SELECT IdVenta, C.Apellido + ' ' + C.Nombre AS 'Cliente', E.Apellido + ' ' + E.Nombre AS 'Vendedor', CONVERT(VARCHAR, Fecha, 0) AS 'Fecha', Subtotal, IGV, Total FROM Venta V
	INNER JOIN Cliente C ON V.Cliente = C.IdCliente
	INNER JOIN Empleado E ON V.Vendedor = E.IdEmpleado 
END
GO

CREATE PROCEDURE SP_Proveedores
AS
BEGIN
	SELECT IdProveedor, Nombre, Telefono, Direccion, Email, COUNT(IdProducto) AS 'Cantidad de Productos' FROM Proveedor, Producto
	WHERE Proveedor = IdProveedor
	GROUP BY IdProveedor, Nombre, Telefono, Direccion, Email
END
GO
