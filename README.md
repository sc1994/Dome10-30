# Dome10-30
会员登陆代码演示

#### 描述
- 项目分成接口部分和前端部分
- 密码加密
- 接口部分使用的是Web API ,前端部分是普通的 HTML 页面
- 接口和前端运行在不同的端口中 所以需要在 API 的web.config 中修改 ACAO 配置所配置的地址
- 前端部分也需要在 common.js  的 ajax 方法中修改 API 所在的地址

#### 功能
- 会员的注册/登陆,个人信息查看/登出
- 做了权限拦截, 部分 API 需要登陆权限之后才能访问(个人信息/登出)

#### 更新
- 加入redis
- 为 Users 表的 UName 添加唯一约束, 以及索引
- 已登陆用户进入 /login.html 自动登入

生成库脚本
```
USE [master]
GO

/****** Object:  Database [Dome]    Script Date: 2017/11/2 15:49:02 ******/
CREATE DATABASE [Dome]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dome10-30', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dome10-30.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dome10-30_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dome10-30_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Dome] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dome].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Dome] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Dome] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Dome] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Dome] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Dome] SET ARITHABORT OFF 
GO

ALTER DATABASE [Dome] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Dome] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Dome] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Dome] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Dome] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Dome] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Dome] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Dome] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Dome] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Dome] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Dome] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Dome] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Dome] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Dome] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Dome] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Dome] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Dome] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Dome] SET RECOVERY FULL 
GO

ALTER DATABASE [Dome] SET  MULTI_USER 
GO

ALTER DATABASE [Dome] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Dome] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Dome] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Dome] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Dome] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Dome] SET  READ_WRITE 
GO

USE [Dome]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2017/11/2 15:49:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[Users](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[UName] [nvarchar](200) NOT NULL,
	[UPhone] [nvarchar](20) NULL,
	[USex] [int] NOT NULL,
	[UPassword] [varchar](200) NOT NULL,
	[UEmail] [varchar](200) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Name_Users] UNIQUE NONCLUSTERED 
(
	[UName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
```
