USE [master]
GO
/****** Object:  Database [umsdb]    Script Date: 5/27/2019 9:15:25 PM ******/
CREATE DATABASE [umsdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'umsdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\umsdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'umsdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\umsdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [umsdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [umsdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [umsdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [umsdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [umsdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [umsdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [umsdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [umsdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [umsdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [umsdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [umsdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [umsdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [umsdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [umsdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [umsdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [umsdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [umsdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [umsdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [umsdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [umsdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [umsdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [umsdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [umsdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [umsdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [umsdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [umsdb] SET  MULTI_USER 
GO
ALTER DATABASE [umsdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [umsdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [umsdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [umsdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [umsdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [umsdb] SET QUERY_STORE = OFF
GO
USE [umsdb]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Credit] [float] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradePoint] [float] NOT NULL,
	[DateTime] [date] NULL,
	[CourseId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] NOT NULL,
	[FormattedId] [nvarchar](255) NOT NULL,
	[Cgpa] [float] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/27/2019 9:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[UserName] [nvarchar](24) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[Type] [int] NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (2, N'Software Service Engineering', N'VSR 101', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (3, N'Advance Management of Data', N'DMS 102', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (4, N'Design of Distributed Systems', N'VSR 103', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (5, N'Databases and Web Techniques', N'DMS 104', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (6, N'XML', N'VSR 105', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (7, N'Databases and Object Orientation', N'DMS 106', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (8, N'Security in Distributed Software', N'VSR 107', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (11, N'Media Coding', N'ME 101', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (12, N'Media Retrieval', N'ME 102', 5, 2)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (14, N'DaF Kurs 1', N'DAF 101', 4, 24)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (15, N'DaF Kurs 2', N'DAF 102', 4, 24)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (21, N'Math I', N'MAT 101', 5, 17)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (22, N'Math II', N'MAT 102', 5, 17)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (23, N'Math III', N'MAT 103', 5, 17)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (24, N'Math IV', N'MAT 104', 5, 17)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (25, N'Dependable Systems', N'ASE 101', 6, 3)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (26, N'Realtime Systems', N'ASE 102', 5, 3)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (30, N'Parallel Programming', N'ASE 103', 5, 3)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (37, N'Information Systems', N'ICS 101', 6, 5)
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [DepartmentId]) VALUES (38, N'Communication Systems', N'ICS 102', 6, 5)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Name], [Description]) VALUES (2, N'WE', N'Web Engineering')
INSERT [dbo].[Departments] ([Id], [Name], [Description]) VALUES (3, N'ASE', N'Autmotive Software Engineering')
INSERT [dbo].[Departments] ([Id], [Name], [Description]) VALUES (5, N'ICS', N'Information & Communication Systems')
INSERT [dbo].[Departments] ([Id], [Name], [Description]) VALUES (17, N'Math', N'Mathematics')
INSERT [dbo].[Departments] ([Id], [Name], [Description]) VALUES (24, N'SZ', N'Sprache Zentrum')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Registrations] ON 

INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (172, 0, CAST(N'2019-05-27' AS Date), 6, 11, 60)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (173, 0, CAST(N'2019-05-27' AS Date), 11, 16, 60)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (182, 0, CAST(N'2019-05-27' AS Date), 4, 8, 60)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (196, 0, CAST(N'2019-05-27' AS Date), 2, 4, 60)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (197, 0, CAST(N'2019-05-27' AS Date), 3, 7, 60)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (198, 0, CAST(N'2019-05-27' AS Date), 25, 47, 62)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (199, 0, CAST(N'2019-05-27' AS Date), 26, 43, 62)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (200, 0, CAST(N'2019-05-27' AS Date), 30, 44, 62)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (201, 0, CAST(N'2019-05-27' AS Date), 25, 47, 35)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (202, 0, CAST(N'2019-05-27' AS Date), 26, 43, 35)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (204, 0, CAST(N'2019-05-27' AS Date), 2, 4, 61)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (205, 0, CAST(N'2019-05-27' AS Date), 2, 4, 66)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (206, 0, CAST(N'2019-05-27' AS Date), 21, 59, 64)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (207, 0, CAST(N'2019-05-27' AS Date), 23, 60, 64)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (208, 0, CAST(N'2019-05-27' AS Date), 37, 57, 63)
INSERT [dbo].[Registrations] ([Id], [GradePoint], [DateTime], [CourseId], [SectionId], [StudentId]) VALUES (209, 0, CAST(N'2019-05-27' AS Date), 38, 58, 63)
SET IDENTITY_INSERT [dbo].[Registrations] OFF
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (3, N'A', 2)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (4, N'B', 2)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (5, N'C', 2)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (6, N'A', 3)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (7, N'B', 3)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (8, N'A', 4)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (9, N'B', 4)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (10, N'A', 5)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (11, N'A', 6)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (12, N'A', 7)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (13, N'A', 8)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (16, N'A', 11)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (17, N'B', 11)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (37, N'C', 11)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (43, N'A', 26)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (44, N'A', 30)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (47, N'A', 25)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (48, N'C', 25)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (49, N'B', 26)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (56, N'A', 14)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (57, N'A', 37)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (58, N'A', 38)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (59, N'A', 21)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (60, N'A', 23)
INSERT [dbo].[Sections] ([Id], [Name], [CourseId]) VALUES (61, N'C', 26)
SET IDENTITY_INSERT [dbo].[Sections] OFF
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (35, N'19-3-0', 0, 3)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (60, N'19-2-1', 0, 2)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (61, N'19-2-2', 0, 2)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (62, N'19-3-3', 0, 3)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (63, N'19-5-4', 0, 5)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (64, N'19-17-5', 0, 17)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (65, N'19-24-6', 0, 24)
INSERT [dbo].[Students] ([Id], [FormattedId], [Cgpa], [DepartmentId]) VALUES (66, N'19-2-7', 0, 2)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (1, N'Dev Admin', N'devadmin', N'cfcd208495d565ef66e7dff9f98764da', 1, N'admin@ums.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (35, N'Mobasser Ahmed', N'amobasser', N'cfcd208495d565ef66e7dff9f98764da', 2, N'amobasser@ums.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (60, N'Shovra Das', N'dev', N'cfcd208495d565ef66e7dff9f98764da', 2, N'shovradas@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (61, N'John Doe', N'djohn', N'cfcd208495d565ef66e7dff9f98764da', 2, N'djohn@ums.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (62, N'Jane Doe', N'djane', N'cfcd208495d565ef66e7dff9f98764da', 2, N'djane@ums.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (63, N'Clark Kent', N'kclark', N'cfcd208495d565ef66e7dff9f98764da', 2, N'kclark@ums.com', 1)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (64, N'Klara Jones', N'jklara', N'cfcd208495d565ef66e7dff9f98764da', 1, N'jklara@ums.com', 0)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (65, N'Jonathon Goldfish', N'gjonathon', N'cfcd208495d565ef66e7dff9f98764da', 2, N'gjonathon@ums.com', 0)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (66, N'Sagar Kafle', N'ksagar', N'cfcd208495d565ef66e7dff9f98764da', 2, N'ksagar@ums.com', 0)
INSERT [dbo].[Users] ([Id], [Name], [UserName], [Password], [Type], [Email], [IsActive]) VALUES (67, N'Daniel Richter', N'rdan', N'cfcd208495d565ef66e7dff9f98764da', 1, N'rdaniel@ums.com', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Unique_Courses_Code]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Courses_Code] ON [dbo].[Courses]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Unique_Registrations_StudentId_CourseId]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Registrations_StudentId_CourseId] ON [dbo].[Registrations]
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Unique_Registrations_StudentId_SectionId]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Registrations_StudentId_SectionId] ON [dbo].[Registrations]
(
	[StudentId] ASC,
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Unique_Students_FormattedId]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Students_FormattedId] ON [dbo].[Students]
(
	[FormattedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Unique_Users_Email]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Unique_Users_UserName]    Script Date: 5/27/2019 9:15:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Registrations] ADD  CONSTRAINT [DF_CourseRegistrations_GradePoint]  DEFAULT ((0)) FOR [GradePoint]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_isActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [FK_Registrations_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [FK_Registrations_Courses]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [FK_Registrations_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [FK_Registrations_Sections]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [FK_Registrations_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [FK_Registrations_Students]
GO
ALTER TABLE [dbo].[Sections]  WITH CHECK ADD  CONSTRAINT [FK_Sections_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sections] CHECK CONSTRAINT [FK_Sections_Courses]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users]
GO
USE [master]
GO
ALTER DATABASE [umsdb] SET  READ_WRITE 
GO
