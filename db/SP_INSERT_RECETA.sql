USE [Recetario]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_RECETA]    Script Date: 12/03/2022 08:37:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jeovanny Nava
-- Create date: 12/03/2022
-- Description:	Inserta una receta
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_RECETA]
	
	 @Nombre nvarchar(max)
	,@Descripcion nvarchar(max)
	,@Imagen nvarchar(max)
	,@FechaCreacion DATE
	,@FechaActualizacion DATE
	,@IdReceta int out
AS
BEGIN
	SET NOCOUNT ON;
	 BEGIN TRANSACTION [Tran]
	     BEGIN TRY
	
	INSERT INTO Recetas
                        (Nombre, Descripcion, FechaCreacion, FechaActualizacion, Imagen)
            VALUES     (@Nombre, @Descripcion, @FechaCreacion, @FechaActualizacion, @Imagen)
			  commit
			 SET @IdReceta = SCOPE_IDENTITY()
	END TRY

	BEGIN CATCH
	  SET @IdReceta = 0;
        ROLLBACK TRANSACTION [Tran];  
    END CATCH   
	
END


