CREATE SCHEMA RBApp
GO

CREATE TABLE [RBApp].[IoTHubLog](
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
	[RBFX_TargetType] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceGroupId] [nvarchar](4000) NULL,
	[RBFX_TargetDeviceId] [nvarchar](4000) NULL,
	[RBFX_ProcessingStack] [nvarchar](4000) NULL,
	[visitor] [nvarchar](100) NULL,
	[gender] [nvarchar](100) NULL,
	[age] [nvarchar](100) NULL,
	[product] [nvarchar](100) NULL,
	[quantity] [nvarchar](100) NULL,
	[stock] [nvarchar](100) NULL,
	[result] [nvarchar](100) NULL,
)

----
--This is an option.
----
--CREATE CLUSTERED COLUMNSTORE INDEX CCI ON [RBApp].[IoTHubLog]

GO


