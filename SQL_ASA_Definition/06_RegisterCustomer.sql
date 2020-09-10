--
-- Register app info to RBFX.CustomerInfo & RBFX.CustomerResource
--
DECLARE @customerId AS NVARCHAR(100) = N'CR000001';
DECLARE @customerName AS NVARCHAR(100) = N'ABC Company';
DECLARE @resourceGroupId AS NVARCHAR(40) = CONVERT(NVARCHAR(40),NEWID());
DECLARE @resourceGroupName AS NVARCHAR(100) = N'Sales Division';
DECLARE @sqlConnectionString AS NVARCHAR(1000) = N'Server=tcp:xxxxxx.database.windows.net,1433;Database=xxx;User ID=xxxxxx;Password=xxxxxx;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;';
DECLARE @passPhrase AS NVARCHAR(100) = N'This is a passphrase!!'

DELETE FROM [RBFX].[CustomerResource] WHERE CustomerId = @customerId;
DELETE FROM [RBFX].[CustomerInfo] WHERE CustomerId = @customerId;

INSERT INTO [RBFX].[CustomerResource]
(
  CustomerId,ResourceGroupId,ResourceGroupName,
  SqlConnectionStringEnc,[Description],Registered_DateTime
)
VALUES
(
  @customerId,
  @resourceGroupId,
  @resourceGroupName,
  EncryptByPassPhrase(@passPhrase, @sqlConnectionString, 1, CONVERT(varbinary, @resourceGroupId)),
  'テスト用',
  sysdatetime()
);

INSERT INTO [RBFX].[CustomerInfo]
(
  CustomerId,CustomerName,[Description],Registered_DateTime
)
VALUES
(
  @customerId,
  @customerName,
  'テスト用',
  sysdatetime()
);

SELECT [SeqId]
      ,[CustomerId]
      ,[ResourceGroupId]
      ,[ResourceGroupName]
      ,[SqlConnectionStringEnc]
      ,CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,SqlConnectionStringEnc,1,CONVERT(varbinary,ResourceGroupId))) AS SqlConnectionString
      ,[Description]
      ,[Registered_DateTime]
  FROM [RBFX].[CustomerResource]
  WHERE CustomerId = @customerId;

SELECT [SeqId]
      ,[CustomerId]
      ,[CustomerName]
      ,[Description]
      ,[Registered_DateTime]
  FROM [RBFX].[CustomerInfo]
  WHERE CustomerId = @customerId;

