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
    [Descripcion]       VARCHAR(500) NOT NULL,
    [MarcaId]           INT NOT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL,

    CONSTRAINT [PK_Productos] PRIMARY KEY (Id),
    CONSTRAINT [FK_Productos_Marcas_MarcaId] FOREIGN KEY (MarcaId) REFERENCES [mant].[Marcas],
    CONSTRAINT [UK_Productos_Nombre] UNIQUE (Nombre),
)

CREATE TABLE [mant].[Variantes](
    [Id]                INT IDENTITY(1, 1) NOT NULL,
    [ProductoId]        INT NOT NULL,
    [Sku]               VARCHAR(8) NOT NULL,
    [Stock]             INT NOT NULL,
    [Precio]            FLOAT NOT NULL,
    [ColorId]           INT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL,

    CONSTRAINT [PK_Variantes] PRIMARY KEY (Id), 
    CONSTRAINT [UK_Variantes_ProductoId_ColorId] UNIQUE (ProductoId, ColorId),
    CONSTRAINT [UK_Variantes_Sku] UNIQUE (Sku),
    CONSTRAINT [FK_Variantes_Productos_ProductoId] FOREIGN KEY (ProductoId) REFERENCES [mant].[Productos],
    CONSTRAINT [CHK_Variantes_Sku] CHECK (LEN(Sku) = 8 AND ISNUMERIC(Sku) = 1)
)

CREATE TABLE [mant].[Imagenes](
    [Id]                INT IDENTITY(1, 1) NOT NULL,
    [Path]              VARCHAR(MAX) NOT NULL,
    [VarianteId]        INT NOT NULL,

    [Activo]            BIT NULL,
    [Creado]            DATETIME NULL,
    [Modificado]        DATETIME NULL,

    CONSTRAINT [PK_Imagenes] PRIMARY KEY (Id), 
    CONSTRAINT [FK_Imagenes_Variantes_VarianteId] FOREIGN KEY (VarianteId) REFERENCES [mant].[Variantes]   
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
    CONSTRAINT [FK_ProductosCaracteristicas_Caracteristicas_CaracteristicaId] FOREIGN KEY (CaracteristicaId) REFERENCES [mant].[Caracteristicas],
)