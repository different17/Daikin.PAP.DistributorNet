CREATE PROCEDURE [dbo].[GetAllDistributors]
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
	FROM [dbo].[Distributor]

END