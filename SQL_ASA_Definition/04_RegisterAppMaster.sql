--
-- Register app info to RBFX.AppMaster
--
DECLARE @appId AS NVARCHAR(100);
DECLARE @storageAccount AS NVARCHAR(256);
DECLARE @storageKey AS NVARCHAR(1000);
DECLARE @appInfo AS NVARCHAR(4000);
DECLARE @passPhrase AS NVARCHAR(100);
SET @appId = N'PepperShopApp';
SET @storageAccount = N'xxxxxxxxxxxxxx';
SET @storageKey = N'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx==';
SET @appInfo = N'{ "SqlConnString": "Server=tcp:xxxxx.database.windows.net,1433;Database=xxx;User ID=xxxxx;Password=xxxxx;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;","StorageAccount": "xxxxx","StorageKey": "xxxxx==","StorageContainer": "xxxxx","FaceApiKey": "xxxxx","FacialHairConfidence": "0.6" }';
SET @appInfoDevice = N'{ "InitialData": [{"DeviceId": "pepper01","DeviceKey": "xxxxxxxx"},{"DeviceId": "pepper02","DeviceKey": "xxxxxxxx"}] }' 
SET @passPhrase = N'xxxxxxxxxxxxxxxxxxxx'

DELETE FROM [RBFX].[AppMaster] WHERE AppId = @appId;

INSERT INTO [RBFX].[AppMaster]
(
  AppId,StorageAccount,StorageKeyEnc,AppInfoEnc,AppInfoDeviceEnc,[Status],[Description],Registered_DateTime
)
VALUES
(
  @appId,
  @storageAccount,
  EncryptByPassPhrase(@passPhrase, @storageKey, 1, CONVERT(varbinary, @appId)),
  EncryptByPassPhrase(@passPhrase, @appInfo, 1, CONVERT(varbinary, @appId)),
  EncryptByPassPhrase(@passPhrase, @appInfoDevice, 1, CONVERT(varbinary, @appId)),
  'Active',
  'Pepper Shop Application by Softbank Robotics',
  sysdatetime()
);


SELECT [SeqId]
      ,[AppId]
      ,[StorageAccount]
      ,[StorageKeyEnc]
      ,CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,StorageKeyEnc,1,CONVERT(varbinary,AppId))) AS StorageKey
      ,[AppInfoEnc]
      ,CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoEnc,1,CONVERT(varbinary,AppId))) AS AppInfo
      ,[AppInfoDeviceEnc]
      ,CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoDeviceEnc,1,CONVERT(varbinary,AppId))) AS AppInfoDevice
      ,[Status]
      ,[Description]
      ,[Registered_DateTime]
  FROM [RBFX].[AppMaster]
  WHERE AppId = @appId;

