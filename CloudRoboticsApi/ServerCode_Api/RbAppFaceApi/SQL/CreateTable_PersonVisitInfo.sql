--
-- Face API (Person Visit Info)
--

CREATE TABLE [RBApp].[PersonVisitInfo]
(
    [SeqId] int IDENTITY NOT NULL,
    [GroupId] NVARCHAR(100) NOT NULL,
    [PersonId] NVARCHAR(100) NOT NULL,
    [PersonName] NVARCHAR(100) NULL,
    [PersonNameKana] NVARCHAR(100) NULL,
    [LocationId] NVARCHAR(100) NOT NULL,
    [VisitCount] int NULL,
    [Description] NVARCHAR(1000) NULL,
    [Registered_DateTime] DATETIME NULL,
CONSTRAINT [PK_PersonVisitInfo] PRIMARY KEY CLUSTERED 
(
    [GroupId] ASC, [PersonId] ASC
))
WITH (DATA_COMPRESSION=PAGE)
