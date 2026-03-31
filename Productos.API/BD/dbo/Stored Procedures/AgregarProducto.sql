-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [AgregarProducto]
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
    Begin transaction

	 INSERT INTO [dbo].[Producto](
        Id,
        IdSubCategoria,
        Nombre,
        Descripcion,
        Precio,
        Stock,
        CodigoBarras
    )
    VALUES (
        @Id,
        @IdSubCategoria,
        @Nombre,
        @Descripcion,
        @Precio,
        @Stock,
        @CodigoBarras
    );
    select @Id
    commit Transaction
END