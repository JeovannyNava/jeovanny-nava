USE [Recetario]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_RECETA]    Script Date: 12/03/2022 09:18:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jeovanny Nava
-- Create date: 12/03/2022
-- Description:	Inserta una receta
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_RECETA]
	
	   @IdReceta int 
	  ,@Result int out
	
AS
BEGIN
	SET NOCOUNT ON;
	 BEGIN TRANSACTION [Tran]
	     BEGIN TRY
		 DELETE FROM Ingredientes WHERE IdReceta=@IdReceta
		 DELETE FROM Recetas WHERE IdReceta=@IdReceta
	
	commit
	set @Result=1;
	END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION [Tran];  
	set @Result=0;
	END CATCH
END

