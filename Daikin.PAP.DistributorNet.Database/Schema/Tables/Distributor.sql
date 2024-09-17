CREATE TABLE [dbo].[Distributor]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [DistributorId] VARCHAR(10) NOT NULL, 
    [DistributorName] NVARCHAR(50) NULL, 
    [DistributorRole] VARCHAR(50) NULL, 
    [DistributorType] VARCHAR(50) NULL, 
    [IsActive] BIT NULL DEFAULT 1, 
    [AddedBy] INT NULL, 
    [AddedDate] DATETIME NULL, 
    [UpdatedBy] INT NULL, 
    [UpdatedDate] DATETIME NULL
)
