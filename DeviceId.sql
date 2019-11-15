USE [NetACS]
GO

/****** Object:  Table [dbo].[DeviceId]    Script Date: 15/11/2019 09:26:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DeviceId](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Device] [uniqueidentifier] NOT NULL,
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

ALTER TABLE [dbo].[DeviceId]  WITH CHECK ADD  CONSTRAINT [FK_DeviceId_Device] FOREIGN KEY([Device])
REFERENCES [dbo].[Device] ([ID])
GO

ALTER TABLE [dbo].[DeviceId] CHECK CONSTRAINT [FK_DeviceId_Device]
GO