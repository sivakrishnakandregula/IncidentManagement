USE [IncidentMonitoring]
GO
/****** Object:  Table [dbo].[IncidentDetails]    Script Date: 4/12/2021 9:16:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IncidentDetails](
	[ID] [int] NOT NULL,
	[ApplicationID] [int] NULL,
	[IncidentID] [int] NULL,
	[Description] [varchar](50) NULL,
	[Severity] [int] NULL,
	[Priority] [int] NULL,
	[Status] [varchar](50) NULL,
	[IncidentCreateDate] [varchar](30) NULL,
	[IncidentAnalysisStartDate] [varchar](30) NULL,
	[IncidentClosedOn] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SupportApplication]    Script Date: 4/12/2021 9:16:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupportApplication](
	[ID] [int] NOT NULL,
	[ApplicationName] [varchar](50) NULL,
	[Description] [varchar](1000) NULL,
	[OperatingSystem] [varchar](10) NULL,
	[LastUpdate] [varchar](30) NULL,
	[ModifiedDate] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/12/2021 9:16:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[UserName] [varchar](10) NULL,
	[Password] [varchar](30) NULL,
	[IsActive] [bit] NULL,
	[IsAdmin] [bit] NULL,
	[CreatedBy] [varchar](10) NULL,
	[CreatedDate] [varchar](50) NULL,
	[ModifiedDate] [varchar](50) NULL,
 CONSTRAINT [PK__User__3214EC2793E0A648] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[IncidentDetails] ([ID], [ApplicationID], [IncidentID], [Description], [Severity], [Priority], [Status], [IncidentCreateDate], [IncidentAnalysisStartDate], [IncidentClosedOn]) VALUES (1, 1, 1, N'Login Issue', 1, 1, N'false', N'Mar 23 2021 12:00AM', NULL, NULL)
INSERT [dbo].[IncidentDetails] ([ID], [ApplicationID], [IncidentID], [Description], [Severity], [Priority], [Status], [IncidentCreateDate], [IncidentAnalysisStartDate], [IncidentClosedOn]) VALUES (2, 1, 2, N'Token  Issue ', 1, 2, N'false', N'Mar 23 2021 12:00AM', NULL, NULL)
INSERT [dbo].[IncidentDetails] ([ID], [ApplicationID], [IncidentID], [Description], [Severity], [Priority], [Status], [IncidentCreateDate], [IncidentAnalysisStartDate], [IncidentClosedOn]) VALUES (3, 1, 2, N'Dashboard Issue', 2, 2, N'false', N'03/26/2021', NULL, NULL)
INSERT [dbo].[SupportApplication] ([ID], [ApplicationName], [Description], [OperatingSystem], [LastUpdate], [ModifiedDate]) VALUES (1, N'OMS', N'Order Management System', N'Windows', N'Mar 23 2021 12:00AM', N'Mar 22 2021 12:00AM')
INSERT [dbo].[User] ([ID], [UserName], [Password], [IsActive], [IsAdmin], [CreatedBy], [CreatedDate], [ModifiedDate]) VALUES (1, N'Admin', N'UO6ZkdgbqUGgal74jNSEhQ==', 1, 1, N'mvc', N'18-03-2021', N'19-03-2021')
INSERT [dbo].[User] ([ID], [UserName], [Password], [IsActive], [IsAdmin], [CreatedBy], [CreatedDate], [ModifiedDate]) VALUES (2, N'user1', N'VXxI5tmxxd4=', 1, 0, N'vc', N'17-03-2021', N'19-03-2021')
ALTER TABLE [dbo].[IncidentDetails]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationID] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[SupportApplication] ([ID])
GO
ALTER TABLE [dbo].[IncidentDetails] CHECK CONSTRAINT [FK_ApplicationID]
GO
