--
-- Register app info to RBFX.AppRouting
--
DECLARE @appId AS NVARCHAR(100) = N'PepperSampleApp';
DECLARE @appProcessingId AS NVARCHAR(100) = N'RbSampleApp';

DELETE FROM [RBFX].[AppRouting] 
  WHERE AppId = @appId and AppProcessingId = @appProcessingId;

INSERT INTO [RBFX].[AppRouting]
(
  AppId,AppProcessingId,BlobContainer,[FileName],ClassName,
  [Status],DevMode,DevLocalDir,[Description],Registered_DateTime
)
VALUES
(
  @appId,
  @appProcessingId,
  'appdll',
  'RbSampleApp.dll',
  'RbSampleApp.SayHello',
  'Active',
  'False',
  'C:\temp',
  'Map to Cognitive Services Web API',
  sysdatetime()
);

SELECT * FROM [RBFX].[AppRouting]
  WHERE AppId = @appId and AppProcessingId = @appProcessingId;