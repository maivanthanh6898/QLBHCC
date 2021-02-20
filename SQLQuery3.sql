alter proc sp_fixdetails
@i int,
@id int,
@sl int,
@gia float
as begin 
update tbl_chitiethoadon set fGiaBan = @gia, iSoluong= @sl,idCayCanh = @id,fTongTien = @gia * @sl where idChiTiet = @i
end