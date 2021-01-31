Create Proc SP_Login
@username Nvarchar(255),
@password Nvarchar(255)
as begin
select * from tbl_nhanvien where sUsername = @username AND sPassword = @password
end

SP_Login "tien123","123456";


select idCayCanh as Id, sTenCayCanh as N'Tên cây',iLoaiCay as N'Loại cây', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả'  from tbl_caycanh



ALTER proc SP_addCay
@tencc nvarchar(255),
@iLoaiCay int,
@fGiaBan float,
@fGiaNhap float,
@iSoLuong int,
@sMoTa nvarchar(500)
as begin
INSERT INTO [dbo].[tbl_caycanh]
           ([sTenCayCanh]
           ,[iLoaiCay]
           ,[fGiaBan]
           ,[fGiaNhap]
           ,[iSoLuong]
           ,[sMoTa])
     VALUES
           (@tencc
           ,@iLoaiCay
           ,@fGiaBan
           ,@fGiaNhap
           ,@iSoLuong
           ,@sMoTa)
end



create proc SP_fixCay
@tencc nvarchar(255),
@iLoaiCay int,
@fGiaBan float,
@fGiaNhap float,
@iSoLuong int,
@sMoTa nvarchar(500),
@id int
as begin
UPDATE [dbo].[tbl_caycanh]
   SET [sTenCayCanh] = @tencc
      ,[iLoaiCay] = @iLoaiCay 
      ,[fGiaBan] = @fGiaBan 
      ,[fGiaNhap] = @fGiaNhap 
      ,[iSoLuong] = @iSoLuong 
      ,[sMoTa] = @sMoTa
 WHERE idCayCanh = @id
 end