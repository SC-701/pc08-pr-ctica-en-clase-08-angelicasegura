-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EditarProducto
	@Id as uniqueidentifier,
    @IdSubCategoria as UNIQUEIDENTIFIER,
    @Nombre         as VARCHAR(MAX),
    @Descripcion    as VARCHAR(MAX),
    @Precio         as DECIMAL(18,2),
    @Stock          as INT,
    @CodigoBarras   as VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    BEGIN TRANSACTION

	 UPDATE [dbo].[Producto]
    SET
        [IdSubCategoria] = @IdSubCategoria,
        [Nombre]         = @Nombre,
        [Descripcion]    = @Descripcion,
        [Precio]        = @Precio,
        [Stock]          = @Stock,
        [CodigoBarras]   = @CodigoBarras
    WHERE Id = @Id;
     select @Id
    commit Transaction
    
END