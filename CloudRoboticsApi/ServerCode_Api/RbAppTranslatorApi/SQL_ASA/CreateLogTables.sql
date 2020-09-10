-- IoT Hub Log
CREATE TABLE [RBApp].[TranslatorLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventEnqueuedUtcTime] [datetime2](7) NULL,
	[EventProcessedUtcTime] [datetime2](7) NULL,
	[PartitionId] [nvarchar](4000) NULL,
	[IoTHub_ConnectionDeviceId] [nvarchar](4000) NULL,
	[RBFX_RoutingType] [nvarchar](4000) NULL,
	[RBFX_RoutingKeyword] [nvarchar](4000) NULL,
	[RBFX_AppId] [nvarchar](4000) NULL,
	[RBFX_AppProcessingId] [nvarchar](4000) NULL,
	[RBFX_MessageId] [nvarchar](4000) NULL,
	[RBFX_MessageSeqno] [bigint] NULL,
	[RBFX_SendDateTime] [datetime] NULL,
	[RBFX_SourceDeviceId] [nvarchar](4000) NULL,
	[RBFX_SourceDeviceType] [nvarchar](4000) NULL,
	[RBFX_SourceDevRescGroupId] [nvarchar](4000) NULL,
	[RBFX_TargetType] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceGroupId] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceId] [nvarchar](4000) NULL,
	[RBFX_ProcessingStack] [nvarchar](4000) NULL,
	[visitor][nvarchar](100) NULL, 
	[visitor_id][nvarchar](100) NULL, 
	[text] [nvarchar](4000) NULL,
	[tolang] [nvarchar](4000) NULL
)
-------------------------------------------------------------------
-- If SQLDB service tier is Premium, create CCI
-------------------------------------------------------------------
--CREATE CLUSTERED COLUMNSTORE INDEX CCI ON [RBApp].[TranslatorLog]
GO

-- Cloud Robotics FX C2D Log
CREATE TABLE [RBApp].[TranslatorLogC2D](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventEnqueuedUtcTime] [datetime2](7) NULL,
	[EventProcessedUtcTime] [datetime2](7) NULL,
	[PartitionId] [nvarchar](4000) NULL,
	[IoTHub_ConnectionDeviceId] [nvarchar](4000) NULL,
	[RBFX_RoutingType] [nvarchar](4000) NULL,
	[RBFX_RoutingKeyword] [nvarchar](4000) NULL,
	[RBFX_AppId] [nvarchar](4000) NULL,
	[RBFX_AppProcessingId] [nvarchar](4000) NULL,
	[RBFX_MessageId] [nvarchar](4000) NULL,
	[RBFX_MessageSeqno] [bigint] NULL,
	[RBFX_SendDateTime] [datetime] NULL,
	[RBFX_SourceDeviceId] [nvarchar](4000) NULL,
	[RBFX_SourceDeviceType] [nvarchar](4000) NULL,
	[RBFX_SourceDevRescGroupId] [nvarchar](4000) NULL,
	[RBFX_TargetType] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceGroupId] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceId] [nvarchar](4000) NULL,
	[RBFX_ProcessingStack] [nvarchar](4000) NULL,
	[success][nvarchar](10) NULL, 
	[visitor][nvarchar](100) NULL, 
	[visitor_id][nvarchar](100) NULL, 
	[translated_text] [nvarchar](4000) NULL
)
-------------------------------------------------------------------
-- If SQLDB service tier is Premium, create CCI
-------------------------------------------------------------------
--CREATE CLUSTERED COLUMNSTORE INDEX CCI ON [RBApp].[TranslatorLogC2D]
GO


-- View
CREATE VIEW [dbo].[V_TranslatorLog] AS
SELECT a.[id]
      ,DATEADD(hour,9,a.[EventEnqueuedUtcTime]) as LocalDateTime
      ,DATENAME(month,DATEADD(hour,9,a.[EventEnqueuedUtcTime])) as LocalMonth
	  ,DATENAME(day,DATEADD(hour,9,a.[EventEnqueuedUtcTime])) as LocalDay
      ,DATENAME(hour,DATEADD(hour,9,a.[EventEnqueuedUtcTime])) as LocalHour
      ,a.[IoTHub_ConnectionDeviceId]
      ,a.[visitor]
      ,a.[visitor_id]
	  ,a.[tolang]
	  ,a.[text]
	  ,b.[translated_text]
  FROM [RBApp].[TranslatorLog] a, [RBApp].[TranslatorLogC2D] b
  WHERE
	a.[RBFX_AppId] = b.[RBFX_AppId] AND
	a.[RBFX_AppProcessingId] = b.[RBFX_AppProcessingId] AND
	a.[RBFX_MessageSeqno] = b.[RBFX_MessageSeqno] AND
	a.[RBFX_SendDateTime] = b.[RBFX_SendDateTime] AND
	a.[IoTHub_ConnectionDeviceId] = b.[IoTHub_ConnectionDeviceId] 

GO

