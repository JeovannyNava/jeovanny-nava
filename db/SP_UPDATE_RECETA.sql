USE [Recetario]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_RECETA]    Script Date: 12/03/2022 09:20:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jeovanny Nava
-- Create date: 12/03/2022
-- Description:	Actualiza una receta
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_RECETA]
	
	 @Nombre nvarchar(max)
	,@Descripcion nvarchar(max)
	,@FechaActualizacion DATE
	,@Imagen nvarchar(max)
	,@Id int
	,@Result int out
AS
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION [Tran]
	     BEGIN TRY
		 delete from Ingredientes where IdReceta=@Id
		 
	  UPDATE Recetas

            SET    Nombre = @Nombre,
                   Descripcion = @Descripcion,
                   FechaActualizacion = @FechaActualizacion,
				   Imagen = @Imagen
            WHERE  IdReceta = @Id
		 commit
			set @Result=1
			
			END TRY
			BEGIN CATCH
			set @Result=0
			 ROLLBACK TRANSACTION [Tran];  
				
			END CATCH
END