USE [master]
GO
/****** Object:  Database [OBS_Proje]    Script Date: 13.01.2023 16:05:58 ******/
CREATE DATABASE [OBS_Proje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OBS_Proje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OBS_Proje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OBS_Proje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OBS_Proje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OBS_Proje] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OBS_Proje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OBS_Proje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OBS_Proje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OBS_Proje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OBS_Proje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OBS_Proje] SET ARITHABORT OFF 
GO
ALTER DATABASE [OBS_Proje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OBS_Proje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OBS_Proje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OBS_Proje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OBS_Proje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OBS_Proje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OBS_Proje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OBS_Proje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OBS_Proje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OBS_Proje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OBS_Proje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OBS_Proje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OBS_Proje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OBS_Proje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OBS_Proje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OBS_Proje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OBS_Proje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OBS_Proje] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OBS_Proje] SET  MULTI_USER 
GO
ALTER DATABASE [OBS_Proje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OBS_Proje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OBS_Proje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OBS_Proje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OBS_Proje] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OBS_Proje] SET QUERY_STORE = OFF
GO
USE [OBS_Proje]
GO
/****** Object:  Table [dbo].[KayıtOlTbl]    Script Date: 13.01.2023 16:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KayıtOlTbl](
	[KullanıcıAdı] [nvarchar](30) NULL,
	[Sifre] [nvarchar](30) NULL,
	[KullanıcıTipi] [nchar](10) NULL,
	[Ad] [nvarchar](30) NULL,
	[Soyad] [nvarchar](30) NULL,
	[Telefon] [nchar](20) NULL,
	[TcKimlik] [nchar](11) NULL,
	[FirmaAdı] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtobüsİslemTbl]    Script Date: 13.01.2023 16:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtobüsİslemTbl](
	[OtobüsID] [nvarchar](50) NULL,
	[OtobüsAdı] [nvarchar](30) NULL,
	[KoltukDüzeni] [nvarchar](10) NULL,
	[BagajHacmi] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatılanBiletlerTbl]    Script Date: 13.01.2023 16:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatılanBiletlerTbl](
	[MüşteriAdı] [nvarchar](30) NULL,
	[MüşteriSoyadı] [nvarchar](30) NULL,
	[Cinsiyet] [nvarchar](10) NULL,
	[TelefonNo] [nvarchar](50) NULL,
	[T.C.KimlikNo] [nvarchar](11) NULL,
	[SeferNo] [nvarchar](10) NULL,
	[KoltukNo] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeferİslemTbl]    Script Date: 13.01.2023 16:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeferİslemTbl](
	[Nereden] [nvarchar](50) NULL,
	[Nereye] [nvarchar](50) NULL,
	[SeferNo] [nvarchar](10) NULL,
	[SeferTarihi] [nvarchar](10) NULL,
	[SeferSaati] [nvarchar](10) NULL,
	[OtobüsAdı] [nvarchar](10) NULL,
	[PeronNo] [nvarchar](10) NULL,
	[SeferÜcreti] [nvarchar](10) NULL,
	[KoltukNo] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[KayıtOlTbl] ([KullanıcıAdı], [Sifre], [KullanıcıTipi], [Ad], [Soyad], [Telefon], [TcKimlik], [FirmaAdı]) VALUES (N'DidarYılmaz', N'1234', N'müsteri   ', N'Didar', N'Yılmaz', N'(545) 467-6457      ', N'12345678901', NULL)
INSERT [dbo].[KayıtOlTbl] ([KullanıcıAdı], [Sifre], [KullanıcıTipi], [Ad], [Soyad], [Telefon], [TcKimlik], [FirmaAdı]) VALUES (N'Didar', N'12345', N'müsteri   ', N'Didar', N'Yılmaz', N'(583) 749-1949      ', N'98765434567', NULL)
INSERT [dbo].[KayıtOlTbl] ([KullanıcıAdı], [Sifre], [KullanıcıTipi], [Ad], [Soyad], [Telefon], [TcKimlik], [FirmaAdı]) VALUES (N'metro', N'12345', N'admin     ', NULL, NULL, N'(547) 567-8909      ', NULL, N'metro')
INSERT [dbo].[KayıtOlTbl] ([KullanıcıAdı], [Sifre], [KullanıcıTipi], [Ad], [Soyad], [Telefon], [TcKimlik], [FirmaAdı]) VALUES (N'didary', N'12345', N'müsteri   ', N'didar', N'yılmaz', N'(563) 229-7384      ', N'12345654323', NULL)
INSERT [dbo].[KayıtOlTbl] ([KullanıcıAdı], [Sifre], [KullanıcıTipi], [Ad], [Soyad], [Telefon], [TcKimlik], [FirmaAdı]) VALUES (N'admin', N'1234', N'müsteri   ', N'admin', N'admin', N'(545) 345-6789      ', N'45356878278', NULL)
GO
INSERT [dbo].[OtobüsİslemTbl] ([OtobüsID], [OtobüsAdı], [KoltukDüzeni], [BagajHacmi]) VALUES (N'1', N'VIP', N'2 + 2', N'15 Kg')
INSERT [dbo].[OtobüsİslemTbl] ([OtobüsID], [OtobüsAdı], [KoltukDüzeni], [BagajHacmi]) VALUES (N'2', N'Class', N'2 +1', N'10 Kg')
INSERT [dbo].[OtobüsİslemTbl] ([OtobüsID], [OtobüsAdı], [KoltukDüzeni], [BagajHacmi]) VALUES (N'3', N'Mini', N'2 +1', N'5 Kg')
INSERT [dbo].[OtobüsİslemTbl] ([OtobüsID], [OtobüsAdı], [KoltukDüzeni], [BagajHacmi]) VALUES (N'4', N'Suit', N'2 +1', N'10 Kg')
GO
INSERT [dbo].[SatılanBiletlerTbl] ([MüşteriAdı], [MüşteriSoyadı], [Cinsiyet], [TelefonNo], [T.C.KimlikNo], [SeferNo], [KoltukNo]) VALUES (N'Melike', N'Açıkel', N'Kadın', N'(507) 345-6789', N'34565433456', N'312465', N'21')
INSERT [dbo].[SatılanBiletlerTbl] ([MüşteriAdı], [MüşteriSoyadı], [Cinsiyet], [TelefonNo], [T.C.KimlikNo], [SeferNo], [KoltukNo]) VALUES (N'', N'', N'', N'(   )    -', N'', N'', N'')
INSERT [dbo].[SatılanBiletlerTbl] ([MüşteriAdı], [MüşteriSoyadı], [Cinsiyet], [TelefonNo], [T.C.KimlikNo], [SeferNo], [KoltukNo]) VALUES (N'Didar', N'Yılmaz', N'Kadın', N'(505) 123-456', N'12345678987', N'312465', N'32')
INSERT [dbo].[SatılanBiletlerTbl] ([MüşteriAdı], [MüşteriSoyadı], [Cinsiyet], [TelefonNo], [T.C.KimlikNo], [SeferNo], [KoltukNo]) VALUES (N'Kenan', N'Badem', N'Erkek', N'(505) 368-7129', N'52163728139', N'216542', N'26')
GO
INSERT [dbo].[SeferİslemTbl] ([Nereden], [Nereye], [SeferNo], [SeferTarihi], [SeferSaati], [OtobüsAdı], [PeronNo], [SeferÜcreti], [KoltukNo]) VALUES (N'Bolu', N'Nevşehir', N'215541', N'31.12.2022', N'12:30', N'Class', N'5', N'550 TL', NULL)
INSERT [dbo].[SeferİslemTbl] ([Nereden], [Nereye], [SeferNo], [SeferTarihi], [SeferSaati], [OtobüsAdı], [PeronNo], [SeferÜcreti], [KoltukNo]) VALUES (N'Ankara', N'Adana', N'312465', N'12.02.2023', N'16:30', N'VIP', N'3', N'330 TL', NULL)
INSERT [dbo].[SeferİslemTbl] ([Nereden], [Nereye], [SeferNo], [SeferTarihi], [SeferSaati], [OtobüsAdı], [PeronNo], [SeferÜcreti], [KoltukNo]) VALUES (N'İstanbul', N'Eskişehir', N'316441', N'13.01.2023', N'16:45', N'Suit', N'7', N'450 TL', NULL)
INSERT [dbo].[SeferİslemTbl] ([Nereden], [Nereye], [SeferNo], [SeferTarihi], [SeferSaati], [OtobüsAdı], [PeronNo], [SeferÜcreti], [KoltukNo]) VALUES (N'Denizli', N'İzmir', N'541289', N'18.02.2023', N'18:30', N'VIP', N'7', N'300 TL', NULL)
INSERT [dbo].[SeferİslemTbl] ([Nereden], [Nereye], [SeferNo], [SeferTarihi], [SeferSaati], [OtobüsAdı], [PeronNo], [SeferÜcreti], [KoltukNo]) VALUES (N'Erzincan', N'İzmir', N'216542', N'04.01.2023', N'01:30', N'Class', N'4', N'630 TL', NULL)
GO
USE [master]
GO
ALTER DATABASE [OBS_Proje] SET  READ_WRITE 
GO
