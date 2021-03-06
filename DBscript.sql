USE [master]
GO
/****** Object:  Database [TaskCrudDB]    Script Date: 4/10/2020 5:54:42 PM ******/
CREATE DATABASE [TaskCrudDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskCrudDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TaskCrudDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskCrudDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TaskCrudDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TaskCrudDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskCrudDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskCrudDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskCrudDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskCrudDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskCrudDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskCrudDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskCrudDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskCrudDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskCrudDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskCrudDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskCrudDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskCrudDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskCrudDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskCrudDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskCrudDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskCrudDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskCrudDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskCrudDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskCrudDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskCrudDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskCrudDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskCrudDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskCrudDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskCrudDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskCrudDB] SET  MULTI_USER 
GO
ALTER DATABASE [TaskCrudDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskCrudDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskCrudDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskCrudDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskCrudDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskCrudDB] SET QUERY_STORE = OFF
GO
USE [TaskCrudDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TaskCrudDB]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](30) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Role]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (2, N'Owner')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (3, N'Editor')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (4, N'Contributor')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (5, N'Viewer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Phone], [CreatedDate], [RoleId]) VALUES (2, N'Name1', N'LastName1', N'email1', N'phone1', CAST(N'2020-01-10T03:33:05.503' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Phone], [CreatedDate], [RoleId]) VALUES (3, N'Name2', N'LastName2', N'email2', N'phone2', CAST(N'2020-04-10T03:34:53.820' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Phone], [CreatedDate], [RoleId]) VALUES (4, N'Name3', N'LastName3', N'LastName3', N'phone3', CAST(N'2020-04-10T13:34:31.043' AS DateTime), 3)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Phone], [CreatedDate], [RoleId]) VALUES (20, N'name5', N'lname5', N'email5', N'phone5', CAST(N'2020-04-10T17:47:40.753' AS DateTime), 5)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Phone], [CreatedDate], [RoleId]) VALUES (21, N'6', N'6', N'string', N'string', CAST(N'2020-04-10T17:48:46.323' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [NonClusteredIndex-20200410-030304]    Script Date: 4/10/2020 5:54:43 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20200410-030304] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20200410-034933]    Script Date: 4/10/2020 5:54:43 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20200410-034933] ON [dbo].[Users]
(
	[CreatedDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]

	@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Users
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRole] 
	
	@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Roles
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUser]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Users a
	LEFT JOIN Roles b
	ON a.RoleId = b.Id
	WHERE a.Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Users a
	LEFT JOIN Roles b
	ON a.RoleId = b.Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersByDate]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsersByDate]
	@start datetime,
	@end datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM Users a
	LEFT JOIN Roles b
	ON a.RoleId = b.Id
	WHERE a.CreatedDate BETWEEN @start AND @end;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersByRole]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsersByRole]
	@roleid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Users a
	LEFT JOIN Roles b
	ON a.RoleId = b.Id
	WHERE a.RoleId = @roleid
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
	
	@firstname nvarchar(30),
	@lastname nvarchar(50),
	@email nvarchar(60),
	@phone varchar(20),
	@roleid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @userid int

	INSERT INTO Users (FirstName,LastName,Email,Phone,RoleId)
				VALUES(@firstname,@lastname,@email,@phone,@roleid)

	SET  @userid = @@IDENTITY

	EXEC GetUser @id = @userid

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 4/10/2020 5:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@firstname nvarchar(30),
	@lastname nvarchar(50),
	@email nvarchar(60),
	@phone varchar(20),
	@roleid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @userid int

	UPDATE Users 
	SET FirstName = @firstname,
		LastName = @lastname,
		Email = @email,
		Phone = @phone,
		RoleId = @roleid
	WHERE Id = @id

	SET  @userid = @id

	EXEC GetUser @id = @userid
END
GO
USE [master]
GO
ALTER DATABASE [TaskCrudDB] SET  READ_WRITE 
GO
