-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EliminarProducto
	@Id as uniqueidentifier

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION

	  DELETE FROM [dbo].[Producto]
    WHERE Id = @Id;
     select @Id
    commit Transaction
    
END