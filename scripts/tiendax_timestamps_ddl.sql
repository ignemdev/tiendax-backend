USE [Tiendax]
GO

CREATE PROCEDURE [mant].[Usp_SetTimestamps](
    @TableName VARCHAR(20),
    @ColumnName VARCHAR(11),
    @RowId INT
)
AS
DECLARE @DynamicSQL NVARCHAR(200) 
SET @DynamicSQL = N'UPDATE ' + @TableName 
                + ' SET '+ @ColumnName +' = ''' + convert(VARCHAR, getdate(), 120) +	
                + ''' WHERE Id = ' + CONVERT(VARCHAR, @RowId)
PRINT(@DynamicSQL)
EXECUTE sp_executesql @DynamicSQL
GO

--Categorias
CREATE TRIGGER [mant].[T_CategoriasCreadoTimestamp]
ON [mant].[Categorias]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_CategoriasModificadoTimestamp]
ON [mant].[Categorias]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Caracteristicas
CREATE TRIGGER [mant].[T_CaracteristicasCreadoTimestamp]
ON [mant].[Caracteristicas]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_CaracteristicasModificadoTimestamp]
ON [mant].[Caracteristicas]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Colores
CREATE TRIGGER [mant].[T_ColoresCreadoTimestamp]
ON [mant].[Colores]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_ColoresModificadoTimestamp]
ON [mant].[Colores]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Marcas
CREATE TRIGGER [mant].[T_MarcasCreadoTimestamp]
ON [mant].[Marcas]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_MarcasModificadoTimestamp]
ON [mant].[Marcas]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Productos
CREATE TRIGGER [mant].[T_ProductosCreadoTimestamp]
ON [mant].[Productos]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_ProductosModificadoTimestamp]
ON [mant].[Productos]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Variantes
CREATE TRIGGER [mant].[T_VariantesCreadoTimestamp]
ON [mant].[Variantes]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_VariantesModificadoTimestamp]
ON [mant].[Variantes]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO

--Imagenes
CREATE TRIGGER [mant].[T_ImagenesCreadoTimestamp]
ON [mant].[Imagenes]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Creado', @RowId
END
GO

CREATE TRIGGER [mant].[T_ImagenesModificadoTimestamp]
ON [mant].[Imagenes]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RowId INT
    DECLARE @TableName VARCHAR(20)

    SELECT @RowId = i.Id FROM inserted i
    SELECT @TableName = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.name = OBJECT_NAME(@@PROCID)

    EXEC [mant].[Usp_SetTimestamps] @TableName, 'Modificado', @RowId
END
GO