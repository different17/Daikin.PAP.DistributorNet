CREATE PROCEDURE [dbo].[AddNewDistributor]
	@DistributorId VARCHAR(10),
	@DistributorName NVARCHAR(50),
	@DistributorRole VARCHAR(30),
	@DistributorType VARCHAR(5),
	@AddedBy INT
AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[Distributor]
	(
		[Id],
		[DistributorId], 
		[DistributorName], 
		[DistributorRole], 
		[DistributorType],
		[IsActive],
		[AddedBy],
		[AddedDate]
	)
	VALUES
	(
		NEWID(),
		@DistributorId,
		@DistributorName,
		@DistributorRole,
		@DistributorType,
		1,
		@AddedBy,
		GETDATE()
	)

END