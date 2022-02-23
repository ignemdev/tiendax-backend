CREATE DATABASE [Tiendax]
GO

USE [Tiendax]
GO

CREATE TABLE [mant].[Categorias](
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR(100) NOT NULL,
    
    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL 

    CONSTRAINT [PK_Categorias] PRIMARY KEY (Id),
    CONSTRAINT [UK_Categorias_Descripcion] UNIQUE (Descripcion)
)
GO

CREATE TABLE [mant].[Caracteristicas](
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR(200) NOT NULL,


    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL

    CONSTRAINT [PK_Caracteristicas] PRIMARY KEY (Id),
    CONSTRAINT [UK_Caracteristicas_Descripcion] UNIQUE (Descripcion)
)
GO


CREATE TABLE [mant].[Colores](
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR(200) NOT NULL,
    [Hex]               VARCHAR(6) NOT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL 

    CONSTRAINT [PK_Colores] PRIMARY KEY (Id),
    CONSTRAINT [UK_Colores_Hex] UNIQUE (Hex),
    CONSTRAINT [CHK_Colores_Hex] CHECK (CHARINDEX('#', Hex) = 0)
)
GO

CREATE TABLE [mant].[Marcas](
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (200) NOT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL 

    CONSTRAINT [PK_Marcas] PRIMARY KEY (Id),
    CONSTRAINT [UK_Marcas_Nombre] UNIQUE (Nombre)
)
GO

CREATE TABLE [mant].[Productos](
    [Id]                INT IDENTITY(1, 1) NOT NULL,
    [Nombre]            VARCHAR(250) NOT NULL,
    [Sku]               VARCHAR(8),
    [Stock]             INT NOT NULL,
    [Descripcion]       VARCHAR(500) NOT NULL,
    [MarcaId]           INT NOT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL,

    CONSTRAINT [PK_Productos] PRIMARY KEY (Id),
    CONSTRAINT [FK_Productos_Marcas_MarcaId] FOREIGN KEY (MarcaId) REFERENCES [mant].[Marcas],
    CONSTRAINT [UK_Productos_Nombre] UNIQUE (Nombre),
    CONSTRAINT [CHK_Productos_Sku] CHECK (LEN(Sku) = 8 AND ISNUMERIC(Sku) = 1) 
)

CREATE TABLE [mant].[ProductosCategorias](
    [ProductoId]        INT NOT NULL,
    [CategoriaId]       INT NOT NULL

    CONSTRAINT [PK_ProductosCategorias] PRIMARY KEY (ProductoId, CategoriaId),
    CONSTRAINT [FK_ProductosCategorias_Productos_ProductoId] FOREIGN KEY (ProductoId) REFERENCES [mant].[Productos],
    CONSTRAINT [FK_ProductosCategorias_Categorias_CategoriaId] FOREIGN KEY (CategoriaId) REFERENCES [mant].[Categorias],
)

CREATE TABLE [mant].[ProductosCaracteristicas](
    [ProductoId]        INT NOT NULL,
    [CaracteristicaId]  INT NOT NULL,
    [Valor]             VARCHAR(500) NOT NULL

    CONSTRAINT [PK_ProductosCaracteristicas] PRIMARY KEY (ProductoId, CaracteristicaId),
    CONSTRAINT [FK_ProductosCaracteristicas_Productos_ProductoId] FOREIGN KEY (ProductoId) REFERENCES [mant].[Productos],
    CONSTRAINT [FK_ProductosCaracteristicas_Caracteristica_CaracteristicaId] FOREIGN KEY (CaracteristicaId) REFERENCES [mant].[Caracteristicas],
)

CREATE TABLE [mant].[ProductosColoresImagenes](
    [ProductoId]        INT NOT NULL,
    [ColorId]           INT NOT NULL,
    [Path]              VARCHAR(MAX) NULL,

    CONSTRAINT [PK_ProductosColoresImagenes] PRIMARY KEY (ProductoId, ColorId),
    CONSTRAINT [FK_ProductosColoresImagenes_Productos_ProductoId] FOREIGN KEY (ProductoId) REFERENCES [mant].[Productos],
    CONSTRAINT [FK_ProductosColoresImagenes_Colores_ColorId] FOREIGN KEY (ColorId) REFERENCES [mant].[Colores],
)

CREATE TABLE [mant].[ProductosColoresPrecios](
    [ProductoId]        INT NOT NULL,
    [ColorId]           INT NOT NULL,
    [Precio]            VARCHAR(MAX) NULL,

    CONSTRAINT [PK_ProductosColoresPrecios] PRIMARY KEY (ProductoId, ColorId),
    CONSTRAINT [FK_ProductosColoresPrecios_Productos_ProductoId] FOREIGN KEY (ProductoId) REFERENCES [mant].[Productos],
    CONSTRAINT [FK_ProductosColoresPrecios_Colores_ColorId] FOREIGN KEY (ColorId) REFERENCES [mant].[Colores],
)