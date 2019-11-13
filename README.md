# ApiLogger

ApiLogger will help you to log each and every request and response data including its header and parameters in SQL Server or Notepad or MongoDB

You can directly reference TGSLogHandler.dll to your project or include the project reference of TGSLoggerHandler into your project with below minimal setup to log the each request and response of api call. You can see how to implement in example project (LoggerWebAPI).



1.Add key in WebConfig
	- <add key="LoggerConnectionString" value="MongoDB or SQLDBConnection" />
    - <add key="LoggerApplicationName" value="TGSMVCApiLogger" />
    - <add key="MongoDBName" value="Mongo DB Name" />
		
2.Add connection string name as specified the value in App settings key "LoggerConnectionString" in WebConfig
	- For SQLServer
		- <add name="SQLDBConnection" connectionString="data source=xxxx;initial catalog=Demo;Integrated Security=False;User Id=xxxxx; Password=xxxxxx;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=true;" providerName="System.Data.SqlClient" />
	
	- For MongoDB
		- <add name="MongoDB" connectionString="mongodb://localhost:27017" />


3.Add NuGet packages with version
	- Newtonsoft.Json 	- Version: 11.0.0.0
	- MongoDB.Driver	- Version: 2.5.0

4.Add code in Global.asax.cs file in Application_Start() method
	- GlobalConfiguration.Configuration.MessageHandlers.Add(new LogHandler([Options]));
	- [Options]
		- Enums.LoggerStorage.TextFile.ToString()
		- Enums.LoggerStorage.SqlServerDB.ToString()
		- Enums.LoggerStorage.MongoDB.ToString()
	- e.g. GlobalConfiguration.Configuration.MessageHandlers.Add(new LogHandler(Enums.LoggerStorage.MongoDB.ToString()));

5.If you choose TextFile
	- you find that log file in api project root directory in "Log" folder

6.If you choose SqlServerDB for Stored Log Detail
	- Create table in your database - below script
	
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
