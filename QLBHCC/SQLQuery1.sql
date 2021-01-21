Create Proc SP_Login
@username Nvarchar(255),
@password Nvarchar(255)
as begin
select * from tbl_nhanvien where sUsername = @username AND sPassword = @password
end

SP_Login "tien123","123456"
