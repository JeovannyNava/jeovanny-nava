USE [Recetario]
GO
CREATE TYPE IngredientesReceta AS TABLE
( Nombre nvarchar(max)
, Porcion nvarchar(max)
,IdReceta int
,FechaActualizacion datetime
,FechaCreacion datetime
)

