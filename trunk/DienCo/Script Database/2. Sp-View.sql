--- To Thay Dong Ho Nuoc
DROP VIEW V_DHN_BANGKE
GO

CREATE VIEW V_DHN_BANGKE
AS
	SELECT loai.TENBANGKE,kh.HOPDONG,kh.HOTEN,kh.SONHA,kh.TENDUONG,thay.*
	FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh
	WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK
GO

DROP VIEW V_TCTB_TKVATTUTHAY
GO

CREATE VIEW V_TCTB_TKVATTUTHAY
AS
	SELECT STT,MAVT,TENVT,DVT,SUM(SOLUONG) AS 'TONGSL'
	FROM TB_VATUTHAY_DHN 
	GROUP BY  STT,MAVT,TENVT,DVT
GO
