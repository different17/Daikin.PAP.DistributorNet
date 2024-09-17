CREATE PROCEDURE [dbo].[GetDistributorById]
	@DistributorId VARCHAR(10)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		[Id], 
		[DistributorId], 
		[DistributorName], 
		[DistributorRole], 
		[DistributorType], 
		[IsActive] 
	FROM [dbo].[Distributor] WITH (NOLOCK)
	WHERE [DistributorId] = @DistributorId

END