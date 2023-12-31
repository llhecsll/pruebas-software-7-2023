



/*

create database upd_database

use upd_database


USUARIOS
CATEGORIA_PRODUCTO
PRODUCTO
DETALLE_CARRITO
CARRITO_COMPRA

DROP TABLE USUARIOS;
DROP TABLE CATEGORIA_PRODUCTO;
DROP TABLE PRODUCTO;
DROP TABLE DETALLE_CARRITO;
DROP TABLE CARRITO_COMPRA;


*/


--/////////////////////////USUARIOS///////////////////////////////////////////

IF OBJECT_ID('USUARIOS', 'U') IS NOT NULL 
  DROP TABLE USUARIOS; 
GO

CREATE TABLE USUARIOS
(
  "ID"                          INT IDENTITY(1,1),
  "USER_NAME"                   VARCHAR(40) NOT NULL,
  "NOMBRE_COMPLETO"             VARCHAR(100) NOT NULL,
  "PASSWORD"		            VARCHAR(100) NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT USUARIOS_PK		PRIMARY KEY (ID)
);

--/////////////////////////CATEGORIA_PRODUCTO///////////////////////////////////////////

IF OBJECT_ID('CATEGORIA_PRODUCTO', 'U') IS NOT NULL 
  DROP TABLE CATEGORIA; 
GO

CREATE TABLE CATEGORIA_PRODUCTO
(
  "ID"								INT IDENTITY(1,1),
  "NOMBRE"							VARCHAR(100) NOT NULL,
  "USUARIO_REGISTRO"				VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"					DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"					INT DEFAULT 1 NOT NULL, 
  CONSTRAINT CATEGORIA_PRODUCTO_PK	PRIMARY KEY (ID)
);

--/////////////////////////PRODUCTO///////////////////////////////////////////

IF OBJECT_ID('PRODUCTO', 'U') IS NOT NULL 
  DROP TABLE PRODUCTO; 
GO

CREATE TABLE PRODUCTO
(
  "ID"                          INT IDENTITY(1,1),
  "NOMBRE"						VARCHAR(100) NOT NULL,
  "ID_CATEGORIA"				INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PRODUCTO_PK		PRIMARY KEY (ID)
);

ALTER TABLE PRODUCTO
  ADD CONSTRAINT "FK_PRODUCTO_TO_CATEGORIA_PRODUCTO" 
  FOREIGN KEY(ID_CATEGORIA)
  REFERENCES CATEGORIA_PRODUCTO("ID");
  
  
--/////////////////////////CARRITO_COMPRA///////////////////////////////////////////

IF OBJECT_ID('CARRITO_COMPRA', 'U') IS NOT NULL 
  DROP TABLE CARRITO_COMPRA; 
GO

CREATE TABLE CARRITO_COMPRA
(
  "ID"                          INT IDENTITY(1,1),
  "FECHA"						DATETIME NOT NULL,
  "ID_USUARIO"					INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT CARRITO_COMPRA_PK		PRIMARY KEY (ID)
);

ALTER TABLE CARRITO_COMPRA
  ADD CONSTRAINT "FK_CARRITO_COMPRA_TO_USUARIO" 
  FOREIGN KEY("ID_USUARIO")
  REFERENCES USUARIOS("ID");


--/////////////////////////DETALLE_CARRITO///////////////////////////////////////////

IF OBJECT_ID('DETALLE_CARRITO', 'U') IS NOT NULL 
  DROP TABLE DETALLE_CARRITO; 
GO

CREATE TABLE DETALLE_CARRITO
(
  "ID"								INT IDENTITY(1,1),
  "CANTIDAD"						INT NOT NULL,
  "ID_PRODUCTO"						INT NOT NULL,
  "ID_CARRITO_COMPRA"				INT NOT NULL,
  "USUARIO_REGISTRO"				VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"					DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"					INT DEFAULT 1 NOT NULL, 
  CONSTRAINT DETALLE_CARRITO_PK		PRIMARY KEY (ID)
);

ALTER TABLE DETALLE_CARRITO
  ADD CONSTRAINT "FK_DETALLE_CARRITO_TO_PRODUCTO" 
  FOREIGN KEY("ID_PRODUCTO")
  REFERENCES PRODUCTO("ID");

ALTER TABLE DETALLE_CARRITO
  ADD CONSTRAINT "FK_DETALLE_CARRITO_TO_CARRITO_COMPRA" 
  FOREIGN KEY("ID_CARRITO_COMPRA")
  REFERENCES CARRITO_COMPRA("ID");


  

/*


select * from USUARIOS //Backend
select * from CATEGORIA_PRODUCTO //Backend
select * from PRODUCTO //Backend
select * from CARRITO_COMPRA //Backend
select * from DETALLE_CARRITO




INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES ('jorge.c', 'Jorge Campos', '2023') 




INSERT INTO [dbo].[CATEGORIA_PRODUCTO]([NOMBRE]) VALUES ('Limpieza') 


INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 1', 1) 
INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 2', 1) 
INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 3', 1) 



INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (getdate(), 1) 


INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (10, 1, 1) 
INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (5, 2, 1) 
INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (1, 3, 1) 

*/

/*
--/////////////////////////PROVEEDOR///////////////////////////////////////////

IF OBJECT_ID('PROVEEDOR', 'U') IS NOT NULL 
  DROP TABLE PROVEEDOR; 
GO

CREATE TABLE PROVEEDOR
(
  "ID"                          INT IDENTITY(1,1),
  "RAZON_SOCIAL"                VARCHAR(100) NOT NULL,
  "NIT"                         VARCHAR(20) NOT NULL,
  "DIRECCION"                   VARCHAR(200) NOT NULL,
  "NOMBRE_PROVEEDOR"            VARCHAR(100) NOT NULL,
  "TELEFONO"                    VARCHAR(20) NOT NULL,
  "EMAIL"                       VARCHAR(100) NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"             INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PROVEEDOR_PK      PRIMARY KEY (ID)
);  


--Generar un script para poblar la tabla PEDIDO con pedidos aleatorios y no repetidos, utilizando números aleatorios entre 1 y 100 para los atributos ID_USUARIO. a continuacion es scrip de la tabla PEDIDO: 

--/////////////////////////PEDIDO///////////////////////////////////////////

IF OBJECT_ID('PEDIDO', 'U') IS NOT NULL 
  DROP TABLE PEDIDO; 
GO

CREATE TABLE PEDIDO
(
  "ID"                          INT IDENTITY(1,1),
  "ID_USUARIO"                  INT NOT NULL,
  "FECHA_PEDIDO"                DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_PEDIDO"               INT DEFAULT 1 NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"             INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PEDIDO_PK          PRIMARY KEY (ID),
  CONSTRAINT FK_PEDIDO_USUARIO  FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID)
);

--Generar un script para poblar la tabla DETALLE_PEDIDO con 100 filas con datos aleatorios y no repetidos, utilizando números aleatorios entre 1 y 50 para los atributos ID_USUARIO e ID_PROVEEDOR. a continuacion es scrip de la tabla DETALLE_PEDIDO: 

--/////////////////////////DETALLE DE PEDIDO/////////////////////////////////

IF OBJECT_ID('DETALLE_PEDIDO', 'U') IS NOT NULL 
  DROP TABLE DETALLE_PEDIDO; 
GO

CREATE TABLE DETALLE_PEDIDO
(
  "ID_PEDIDO"                   INT NOT NULL,
  "ID_PRODUCTO"                 INT NOT NULL,
  "ID_PROVEEDOR"                INT NOT NULL,
  "CANTIDAD"                    INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"             INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PK_DETALLE_PEDIDO   PRIMARY KEY (ID_PEDIDO, ID_PRODUCTO),
  CONSTRAINT FK_DETALLE_PEDIDO_PEDIDO    FOREIGN KEY (ID_PEDIDO) REFERENCES PEDIDO(ID),
  CONSTRAINT FK_DETALLE_PEDIDO_PRODUCTO  FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTO(ID),
  CONSTRAINT FK_DETALLE_PEDIDO_PROVEEDOR FOREIGN KEY (ID_PROVEEDOR) REFERENCES PROVEEDOR(ID)
);



*/