USE [master]
GO
/****** Object:  Database [WorkFlowDB]    Script Date: 10/20/2018 4:45:40 PM ******/
CREATE DATABASE [WorkFlowDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkFlowDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WorkFlowDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WorkFlowDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WorkFlowDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WorkFlowDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkFlowDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkFlowDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkFlowDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkFlowDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkFlowDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkFlowDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkFlowDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkFlowDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkFlowDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkFlowDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkFlowDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkFlowDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkFlowDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkFlowDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkFlowDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkFlowDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkFlowDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkFlowDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkFlowDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkFlowDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkFlowDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkFlowDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkFlowDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkFlowDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WorkFlowDB] SET  MULTI_USER 
GO
ALTER DATABASE [WorkFlowDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkFlowDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkFlowDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkFlowDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WorkFlowDB]
GO
/****** Object:  Table [dbo].[tbl_empoyee]    Script Date: 10/20/2018 4:45:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empoyee](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_name] [varchar](50) NULL,
	[emp_role] [int] NULL,
	[status] [int] NULL,
	[nic] [varchar](10) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](15) NULL,
	[created_date] [date] NULL,
 CONSTRAINT [PK_tbl_empoyee] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_entity]    Script Date: 10/20/2018 4:45:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_entity](
	[entity_id] [int] IDENTITY(1,1) NOT NULL,
	[entity_name] [varchar](35) NULL,
	[action_name] [nchar](10) NULL,
	[action_description] [varchar](50) NULL,
	[entry_criteria] [varchar](25) NULL,
	[exit_criteria] [varchar](25) NULL,
	[entity_owner] [int] NULL,
	[entity_status] [int] NULL,
	[change_status] [int] NULL,
	[workflow_id] [int] NULL,
 CONSTRAINT [PK_tbl_entity] PRIMARY KEY CLUSTERED 
(
	[entity_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_role]    Script Date: 10/20/2018 4:45:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](35) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tbl_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_flow_tbl]    Script Date: 10/20/2018 4:45:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_flow_tbl](
	[work_flow_id] [int] IDENTITY(1,1) NOT NULL,
	[work_flow_name] [varchar](20) NULL,
	[work_flow_description] [varchar](50) NULL,
	[work_flow_status] [int] NULL,
	[work_flow_created_date] [date] NULL,
	[work_flow_owner] [int] NULL,
	[work_flow_created_user] [int] NULL,
	[entry_criteria] [nchar](10) NULL,
 CONSTRAINT [PK_Work_flow_tbl] PRIMARY KEY CLUSTERED 
(
	[work_flow_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_empoyee]  WITH CHECK ADD  CONSTRAINT [FK_tbl_empoyee_tbl_role] FOREIGN KEY([emp_role])
REFERENCES [dbo].[tbl_role] ([role_id])
GO
ALTER TABLE [dbo].[tbl_empoyee] CHECK CONSTRAINT [FK_tbl_empoyee_tbl_role]
GO
ALTER TABLE [dbo].[tbl_entity]  WITH CHECK ADD  CONSTRAINT [FK_tbl_entity_tbl_empoyee] FOREIGN KEY([entity_owner])
REFERENCES [dbo].[tbl_empoyee] ([emp_id])
GO
ALTER TABLE [dbo].[tbl_entity] CHECK CONSTRAINT [FK_tbl_entity_tbl_empoyee]
GO
ALTER TABLE [dbo].[tbl_entity]  WITH CHECK ADD  CONSTRAINT [FK_tbl_entity_Work_flow_tbl] FOREIGN KEY([workflow_id])
REFERENCES [dbo].[Work_flow_tbl] ([work_flow_id])
GO
ALTER TABLE [dbo].[tbl_entity] CHECK CONSTRAINT [FK_tbl_entity_Work_flow_tbl]
GO
USE [master]
GO
ALTER DATABASE [WorkFlowDB] SET  READ_WRITE 
GO
