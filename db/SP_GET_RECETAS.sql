USE [Recetario]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_RECETAS]    Script Date: 12/03/2022 09:20:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jeovanny Nava
-- Create date: 12/03/2022
-- Description:	Actualiza una receta
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_RECETAS]
	
	
AS
BEGIN
	SET NOCOUNT ON;
	 select * from Recetas
END