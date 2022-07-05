USE [master]
GO
/****** Object:  Database [SereDb]    Script Date: 7/4/2022 10:56:13 PM ******/
CREATE DATABASE [SereDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SereDb', FILENAME = N'C:\Users\Adolfo\SereDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SereDb_log', FILENAME = N'C:\Users\Adolfo\SereDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SereDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SereDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SereDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SereDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SereDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SereDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SereDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SereDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SereDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SereDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SereDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SereDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SereDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SereDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SereDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SereDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SereDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SereDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SereDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SereDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SereDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SereDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SereDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SereDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SereDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SereDb] SET  MULTI_USER 
GO
ALTER DATABASE [SereDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SereDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SereDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SereDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SereDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SereDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SereDb] SET QUERY_STORE = OFF
GO
USE [SereDb]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[NameArea] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[IdCountry] [int] IDENTITY(1,1) NOT NULL,
	[NameCountry] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[IdEvent] [int] NOT NULL,
	[NameEvent] [varchar](60) NOT NULL,
	[DateEvent] [date] NOT NULL,
	[DescriptionEvent] [varchar](255) NOT NULL,
	[ObjectiveEvent] [int] NOT NULL,
	[IdEventType] [int] NULL,
	[SizeEvent] [int] NULL,
	[CostEvent] [money] NOT NULL,
	[IdOrganization] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[IdEvent] [int] NOT NULL,
	[NameEventType] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objective]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objective](
	[IdObjective] [int] IDENTITY(1,1) NOT NULL,
	[NameObjective] [varchar](150) NULL,
	[IndicadorObjective] [varchar](max) NULL,
	[MetasObjective] [varchar](max) NULL,
	[ObjectiveObjective] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[IdOrganization] [int] IDENTITY(1,1) NOT NULL,
	[NameOrganization] [varchar](150) NULL,
	[DescriptionOrganization] [varchar](150) NULL,
	[EmailOrganization] [varchar](100) NULL,
	[Country] [int] NULL,
	[Phone] [varchar](150) NULL,
	[IdOrganizationType] [int] NULL,
	[IdOrganizationStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganization] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationObjective]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationObjective](
	[IdOrganizationObjective] [int] IDENTITY(1,1) NOT NULL,
	[IdOrganization] [int] NULL,
	[IdObjective] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationPerson]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationPerson](
	[IdOrganizationPerson] [int] IDENTITY(1,1) NOT NULL,
	[IdPerson] [int] NULL,
	[IdOrganization] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationProject]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationProject](
	[IdOrganizationProject] [int] IDENTITY(1,1) NOT NULL,
	[IdOrganization] [int] NULL,
	[IdProject] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationStatus]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationStatus](
	[IdOrganizationStatus] [int] IDENTITY(1,1) NOT NULL,
	[NameOrganizationStatus] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationType]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationType](
	[IdOrganizationType] [int] IDENTITY(1,1) NOT NULL,
	[NameOrganizationType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[IdPerson] [int] IDENTITY(1,1) NOT NULL,
	[NamePerson] [varchar](150) NULL,
	[SurnamePerson] [varchar](150) NULL,
	[EmailPerson] [varchar](150) NULL,
	[PhonePerson] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonEvent]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonEvent](
	[IdEvent] [int] NULL,
	[IdPerson] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonObjective]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonObjective](
	[IdPersonObjective] [int] IDENTITY(1,1) NOT NULL,
	[IdPerson] [int] NULL,
	[IdObjective] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPersonObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonProject]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonProject](
	[IdOrganizationProject] [int] IDENTITY(1,1) NOT NULL,
	[IdPerson] [int] NULL,
	[IdProject] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrganizationProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[IdProject] [int] IDENTITY(1,1) NOT NULL,
	[MontoProject] [int] NULL,
	[CreationDateProject] [date] NULL,
	[StartDateProject] [date] NULL,
	[EndDateProject] [date] NULL,
	[MonthsProject] [int] NULL,
	[DescriptionProject] [varchar](max) NULL,
	[KeyWordsProject] [varchar](max) NULL,
	[ObjectivesProject] [varchar](max) NULL,
	[IdArea] [int] NULL,
	[IdProjectStatus] [int] NULL,
	[IdObjectiveObjective] [int] NULL,
	[IdPersonResponsable] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectObjective]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectObjective](
	[IdProjectObjective] [int] IDENTITY(1,1) NOT NULL,
	[IdProject] [int] NULL,
	[IdObjective] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProjectObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectStatus]    Script Date: 7/4/2022 10:56:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStatus](
	[IdProjectStatus] [int] IDENTITY(1,1) NOT NULL,
	[NameProjectStatus] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProjectStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FkEventEventType] FOREIGN KEY([IdEventType])
REFERENCES [dbo].[EventType] ([IdEvent])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FkEventEventType]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FkEventObjective] FOREIGN KEY([ObjectiveEvent])
REFERENCES [dbo].[Objective] ([IdObjective])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FkEventObjective]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FkEventOrganization] FOREIGN KEY([IdOrganization])
REFERENCES [dbo].[Organization] ([IdOrganization])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FkEventOrganization]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FkOrganizationCountry] FOREIGN KEY([Country])
REFERENCES [dbo].[Country] ([IdCountry])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FkOrganizationCountry]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FkOrganizationOrganizationStatus] FOREIGN KEY([IdOrganizationStatus])
REFERENCES [dbo].[OrganizationStatus] ([IdOrganizationStatus])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FkOrganizationOrganizationStatus]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FkOrganizationOrganizationType] FOREIGN KEY([IdOrganizationType])
REFERENCES [dbo].[OrganizationType] ([IdOrganizationType])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FkOrganizationOrganizationType]
GO
ALTER TABLE [dbo].[OrganizationObjective]  WITH CHECK ADD  CONSTRAINT [FkObjectiveOrganization] FOREIGN KEY([IdObjective])
REFERENCES [dbo].[Objective] ([IdObjective])
GO
ALTER TABLE [dbo].[OrganizationObjective] CHECK CONSTRAINT [FkObjectiveOrganization]
GO
ALTER TABLE [dbo].[OrganizationObjective]  WITH CHECK ADD  CONSTRAINT [FkOrganizationObjective] FOREIGN KEY([IdOrganization])
REFERENCES [dbo].[Organization] ([IdOrganization])
GO
ALTER TABLE [dbo].[OrganizationObjective] CHECK CONSTRAINT [FkOrganizationObjective]
GO
ALTER TABLE [dbo].[OrganizationPerson]  WITH CHECK ADD  CONSTRAINT [FkOrganizationPerson] FOREIGN KEY([IdOrganization])
REFERENCES [dbo].[Organization] ([IdOrganization])
GO
ALTER TABLE [dbo].[OrganizationPerson] CHECK CONSTRAINT [FkOrganizationPerson]
GO
ALTER TABLE [dbo].[OrganizationPerson]  WITH CHECK ADD  CONSTRAINT [FkPersonOrganization] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[OrganizationPerson] CHECK CONSTRAINT [FkPersonOrganization]
GO
ALTER TABLE [dbo].[OrganizationProject]  WITH CHECK ADD  CONSTRAINT [FkOrganizationProject] FOREIGN KEY([IdOrganization])
REFERENCES [dbo].[Organization] ([IdOrganization])
GO
ALTER TABLE [dbo].[OrganizationProject] CHECK CONSTRAINT [FkOrganizationProject]
GO
ALTER TABLE [dbo].[OrganizationProject]  WITH CHECK ADD  CONSTRAINT [FkProjectOrganization] FOREIGN KEY([IdProject])
REFERENCES [dbo].[Project] ([IdProject])
GO
ALTER TABLE [dbo].[OrganizationProject] CHECK CONSTRAINT [FkProjectOrganization]
GO
ALTER TABLE [dbo].[PersonEvent]  WITH CHECK ADD  CONSTRAINT [FkEventEventEvent] FOREIGN KEY([IdEvent])
REFERENCES [dbo].[Event] ([IdEvent])
GO
ALTER TABLE [dbo].[PersonEvent] CHECK CONSTRAINT [FkEventEventEvent]
GO
ALTER TABLE [dbo].[PersonEvent]  WITH CHECK ADD  CONSTRAINT [FkPersonEventEvent] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[PersonEvent] CHECK CONSTRAINT [FkPersonEventEvent]
GO
ALTER TABLE [dbo].[PersonObjective]  WITH CHECK ADD  CONSTRAINT [FkObjectivePerson] FOREIGN KEY([IdObjective])
REFERENCES [dbo].[Objective] ([IdObjective])
GO
ALTER TABLE [dbo].[PersonObjective] CHECK CONSTRAINT [FkObjectivePerson]
GO
ALTER TABLE [dbo].[PersonObjective]  WITH CHECK ADD  CONSTRAINT [FkPersonObjective] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[PersonObjective] CHECK CONSTRAINT [FkPersonObjective]
GO
ALTER TABLE [dbo].[PersonProject]  WITH CHECK ADD  CONSTRAINT [FkPersonProject] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[PersonProject] CHECK CONSTRAINT [FkPersonProject]
GO
ALTER TABLE [dbo].[PersonProject]  WITH CHECK ADD  CONSTRAINT [FkProjectPerson] FOREIGN KEY([IdProject])
REFERENCES [dbo].[Project] ([IdProject])
GO
ALTER TABLE [dbo].[PersonProject] CHECK CONSTRAINT [FkProjectPerson]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FkProjectArea] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FkProjectArea]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FkProjectPersonResponsable] FOREIGN KEY([IdPersonResponsable])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FkProjectPersonResponsable]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FkProjectProjectStatus] FOREIGN KEY([IdProjectStatus])
REFERENCES [dbo].[ProjectStatus] ([IdProjectStatus])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FkProjectProjectStatus]
GO
ALTER TABLE [dbo].[ProjectObjective]  WITH CHECK ADD  CONSTRAINT [FkObjectiveProject] FOREIGN KEY([IdObjective])
REFERENCES [dbo].[Objective] ([IdObjective])
GO
ALTER TABLE [dbo].[ProjectObjective] CHECK CONSTRAINT [FkObjectiveProject]
GO
ALTER TABLE [dbo].[ProjectObjective]  WITH CHECK ADD  CONSTRAINT [FkProjectObjective] FOREIGN KEY([IdProject])
REFERENCES [dbo].[Project] ([IdProject])
GO
ALTER TABLE [dbo].[ProjectObjective] CHECK CONSTRAINT [FkProjectObjective]
GO
USE [master]
GO
ALTER DATABASE [SereDb] SET  READ_WRITE 
GO
