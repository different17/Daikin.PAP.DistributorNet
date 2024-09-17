CREATE PROCEDURE [dbo].[UpdateDistributor]
	@DistributorId VARCHAR(10),
	@DistributorName NVARCHAR(50),
	@DistributorRole VARCHAR(30),
	@DistributorType VARCHAR(5),
	@IsActive BIT,
	@UpdatedBy INT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Id AS UNIQUEIDENTIFIER;
	SET @Id = ( SELECT TOP 1 [Id] FROM [dbo].[Distributor] WHERE DistributorId = @DistributorId )

	UPDATE [dbo].[Distributor]
	SET
		[DistributorId] = @DistributorId,
		[DistributorName] = @DistributorName,
		[DistributorRole] = @DistributorRole,
		[DistributorType] = @DistributorType,
		[IsActive] = @IsActive,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE()
	WHERE
		[Id] = @Id

END