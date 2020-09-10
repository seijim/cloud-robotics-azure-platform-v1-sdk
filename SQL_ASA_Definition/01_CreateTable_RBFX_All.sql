CREATE SCHEMA RBFX
GO

--
-- Device Configuration
--

CREATE TABLE [RBFX].[DeviceMaster]
(
    [SeqId] int IDENTITY NOT NULL,
    [DeviceId] NVARCHAR(100) NOT NULL,
    [DeviceType] NVARCHAR(100) NULL,
    [Status] VARCHAR(20) NULL,
    [ResourceGroupId] VARCHAR(40) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_DeviceMaster] PRIMARY KEY CLUSTERED 
(
    [DeviceId] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE TABLE [RBFX].[DeviceRouting]
(
    [SeqId] int IDENTITY NOT NULL,
    [DeviceId] NVARCHAR(100) NOT NULL,
    [RoutingKeyword] NVARCHAR(100) NOT NULL,
    [TargetType] VARCHAR(20) NULL,
    [TargetDeviceGroupId] NVARCHAR(100) NULL,
    [TargetDeviceId] NVARCHAR(100) NULL,
    [Status] VARCHAR(20) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_ DeviceRouting] PRIMARY KEY CLUSTERED 
(
    [DeviceId] ASC,
    [RoutingKeyword] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE TABLE [RBFX].[DeviceGroup]
(
    [SeqId] int IDENTITY NOT NULL,
    [DeviceGroupId] NVARCHAR(100) NOT NULL,
    [DeviceId] NVARCHAR(100) NOT NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_DeviceGroup] PRIMARY KEY CLUSTERED 
(
    [DeviceGroupId] ASC,
    [DeviceId] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE INDEX [IDX1] ON [RBFX].[DeviceGroup]
(
    [DeviceId] ASC
)
WITH (DATA_COMPRESSION=PAGE)


--
-- App Routing Configuration
--

CREATE TABLE [RBFX].[AppMaster]
(
    [SeqId] int IDENTITY NOT NULL,
    [AppId] NVARCHAR(100) NOT NULL,
    [StorageAccount] NVARCHAR(256) NULL,
    [StorageKeyEnc] VARBINARY(2000) NULL, 
    [AppInfoEnc] VARBINARY(8000) NULL,
    [AppInfoDeviceEnc] VARBINARY(8000) NULL,
    [Status] VARCHAR(20) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_AppMaster] PRIMARY KEY CLUSTERED 
(
    [AppId] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE TABLE [RBFX].[AppRouting]
(
    [SeqId] int IDENTITY NOT NULL,
    [AppId] NVARCHAR(100) NOT NULL,
    [AppProcessingId] NVARCHAR(100) NOT NULL,
    [BlobContainer] NVARCHAR(100) NULL,
    [FileName] NVARCHAR(100) NULL,
    [ClassName] NVARCHAR(100) NULL,
    [Status] VARCHAR(20) NULL,
    [DevMode] VARCHAR(5) NULL,
    [DevLocalDir] NVARCHAR(1000) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_AppRouting] PRIMARY KEY CLUSTERED 
(
    [AppId] ASC,
    [AppProcessingId] ASC
))
WITH (DATA_COMPRESSION=PAGE)


--
-- Customer (SaaS) Configuration
--

CREATE TABLE [RBFX].[CustomerInfo]
(
    [SeqId] int IDENTITY NOT NULL,
    [CustomerId] NVARCHAR(100) NOT NULL,
    [CustomerName] NVARCHAR(100) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_CustomerInfo] PRIMARY KEY CLUSTERED 
(
    [CustomerId] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE TABLE [RBFX].[CustomerResource]
(
    [SeqId] int IDENTITY NOT NULL,
    [CustomerId] NVARCHAR(100) NOT NULL,
    [ResourceGroupId] NVARCHAR(40) NOT NULL,
    [ResourceGroupName] NVARCHAR(100) NULL,
    [SqlConnectionStringEnc] VARBINARY(2000) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_CustomerResource] PRIMARY KEY CLUSTERED 
(
    [CustomerId] ASC,
    [ResourceGroupId] ASC
))
WITH (DATA_COMPRESSION=PAGE)

CREATE INDEX [IDX1] ON [RBFX].[CustomerResource]
(
    [ResourceGroupId] ASC
)
WITH (DATA_COMPRESSION=PAGE)

