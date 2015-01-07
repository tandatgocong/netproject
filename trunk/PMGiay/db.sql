USE MASTER
GO

IF EXISTS( SELECT * FROM  sys.databases WHERE NAME = 'QLHANG')
   DROP DATABASE QLHANG
USE MASTER
GO
CREATE DATABASE QLHANG
GO	
USE QLHANG
GO

CREATE TABLE USERS
(
	USERNAME VARCHAR(20) PRIMARY KEY NOT NULL,
	[PASSWORD] VARCHAR(50),
	FULLNAME NVARCHAR(50),
	ROLEID VARCHAR(5),
	ENABLED BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(50),
	MODIFYDATE DATETIME,
)
GO


INSERT INTO USERS VALUES('banhang','banhang',N'Lê Tấn Đạt','AD','True', null, null,null,null)
INSERT INTO USERS VALUES('admin','admin',N'Lê Tấn Đạt','BH','True', null, null,null,null)


CREATE TABLE NHAP_HANG
(
	MANHAP INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NGAYNHAP	DATETIME,
	CHUHANG		NVARCHAR(250),
	HOTEN		NVARCHAR(250),
	DIACHI		NVARCHAR(250),
	SODT		NVARCHAR(250),
	SOTK		NVARCHAR(250),
	NGANHANG	NVARCHAR(250),
	CHIETKHAU	FLOAT,
	MAHANG		VARCHAR(20),
	TENHANG		NVARCHAR(250),  
	SIZE		NVARCHAR(250),
	SLNHAP		INT,
	DONGIA		DECIMAL,
	THANHTIEN	DECIMAL,
	GHICHU		NVARCHAR(MAX),
	SLBAN		INT,
	THANHTOAN	DECIMAL,
	NGAYTHANHTOAN DATETIME,
	GHICHUTT	NVARCHAR(MAX),
	LOINHUAN	FLOAT,
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,
)
GO

CREATE TABLE CHUHANG
(
	MACHUHANG VARCHAR(50) PRIMARY KEY NOT NULL,	
	TENKH		NVARCHAR(250),
	DIACHI		NVARCHAR(250),
	SODT		NVARCHAR(250),
	SOTK		NVARCHAR(250),
	NGANHANG	NVARCHAR(250),
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,		
)
GO

CREATE TABLE HOADON
(	
	MAHD	VARCHAR(50) PRIMARY KEY,
	MAKH	VARCHAR(50),
	TENKH	NVARCHAR(250),
	DIACHI	NVARCHAR(250),
	SODT	NVARCHAR(250),
	TONGTIEN	DECIMAL,
	TRACHUHANG	DECIMAL,
	NHAPQUY		DECIMAL,
	GHICHU	NVARCHAR(250),
	NGAYLAP	 DATETIME,
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,
)
GO

CREATE TABLE CT_HOADON
(	
	MAHD 	VARCHAR(50),
	MANHAP VARCHAR(50), 
	MAHANG 	VARCHAR(50),
	TENHANG		NVARCHAR(250),  
	SIZE		NVARCHAR(250), 
	SOLUONG		INT,
	DONGIA		FLOAT,
	TONGTIEN	DECIMAL,
	TRACHUHANG	DECIMAL,
	NHAPQUY	DECIMAL,	
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,
	CONSTRAINT PK_CT_HOADON PRIMARY KEY (MAHD,MAHANG)
)
GO



CREATE TABLE TIENQUY
(

	TONGSOTIEN	DECIMAL,
	NGAYNHAP	DATETIME
)
GO

CREATE TABLE NHATKY_TIENQUY
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DUTRUOC		DECIMAL,
	NGAYDU	DATETIME,
	TIENNHAP	DECIMAL,
	QUYNHAP		DECIMAL,
	GHICHU		NVARCHAR(MAX),	
	NGAYNHAP	DATETIME,
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME
)
GO

CREATE TABLE CT_TIENQUY
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CHUNGTU	NVARCHAR(250),
	SOTIEN  DECIMAL,
	NGAYCT	DATETIME,
	LYDO	NVARCHAR(MAX),
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,
	
)
GO