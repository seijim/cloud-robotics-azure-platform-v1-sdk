--
-- Conversation API (Conversation State)
--

CREATE TABLE [RBApp].[ConversationState]
(
    [SeqId] int IDENTITY NOT NULL,
    [DeviceId] NVARCHAR(100) NOT NULL,
    [AppId] NVARCHAR(100) NOT NULL,
    [State] VARCHAR(MAX) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_ConversationState] PRIMARY KEY CLUSTERED 
(
    [DeviceId] ASC, [AppId] ASC
))
WITH (DATA_COMPRESSION=PAGE)
