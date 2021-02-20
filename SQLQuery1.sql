select idHoaDon as Id, sTenKh as N'Khách hàng', sTenNv as N'Nhân viên', dNgayTao as N'Ngày tạo', fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien;
select idCayCanh as Id, sTenCayCanh as N'Tên cây',iLoaiCay as N'Loại cây', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả'  from tbl_caycanh;
select * from tbl_khachhang;
alter procedure SP_CREATEHD
@IDNV int,
@IDKH int,
@date datetime,
@tt float
AS BEGIN
INSERT INTO [dbo].[tbl_hoadon] ([idNhanVien], [idKhachHang], [dNgayTao], [fTongTien]) VALUES ( @IDNV, @IDKH,@date, @tt);
SELECT CAST(scope_identity() AS int)
END;


alter proc SP_INSERTDETAILS
@IDHD INT,
@IDCC INT,
@SL INT,
@GIA FLOAT,
@TONGTIEN FLOAT
AS BEGIN
INSERT INTO [dbo].[tbl_chitiethoadon] ( [idHoaDon], [idCayCanh], [iSoluong], [fGiaBan], [fTongTien]) VALUES (@IDHD, @IDCC, @SL, @GIA, @TONGTIEN)
END;

SP_INSERTDETAILS 1,2,1,10,10