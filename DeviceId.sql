USE [NetACS]
GO

/****** Object:  Table [dbo].[DeviceId]    Script Date: 14/11/2019 15:00:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DeviceId](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Manufacturer] [text] NULL,
	[OUI] [varchar](6) NULL,
	[ProductClass] [text] NULL,
	[SerialNumber] [text] NULL,
 CONSTRAINT [PK_DeviceId] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DeviceId] ADD  CONSTRAINT [DF_DeviceId_ID]  DEFAULT (newid()) FOR [ID]
GO