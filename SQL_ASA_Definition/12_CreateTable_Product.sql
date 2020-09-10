CREATE TABLE [RBApp].[Product](
	[SKUID] [nvarchar](40) NOT NULL,
	[カテゴリ] [nvarchar](100) NULL,
	[製品名] [nvarchar](200) NULL,
	[カラー] [nvarchar](100) NULL,
	[代表SKU] [nvarchar](40) NULL,
	[単価] int NULL
PRIMARY KEY CLUSTERED 
(
	[SKUID] ASC
)
)

GO


