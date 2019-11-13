GO
/****** Object:  Table [dbo].[ApiLogger]    Script Date: 2/24/2018 12:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ApiLogger](
	[LoggerId] [bigint] IDENTITY(1,1) NOT NULL,
	[Application] [nvarchar](200) NULL,
	[ApplicaionUser] [nvarchar](200) NULL,
	[Machine] [nvarchar](200) NULL,
	[RequestTimestamp] [datetime] NULL,
	[RequestIpAddress] [nvarchar](200) NULL,
	[RequestContentType] [varchar](max) NULL,
	[RequestContentBody] [varchar](max) NULL,
	[RequestUri] [nvarchar](500) NULL,
	[RequestMethod] [nvarchar](100) NULL,
	[RequestHeaders] [varchar](max) NULL,
	[ResponseTimestamp] [datetime] NULL,
	[ResponseContentType] [varchar](max) NULL,
	[ResponseContentBody] [varchar](max) NULL,
	[ResponseStatusCode] [int] NULL,
	[ResponseHeaders] [varchar](max) NULL,
 CONSTRAINT [PK_ApiLogger] PRIMARY KEY CLUSTERED 
(
	[LoggerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
