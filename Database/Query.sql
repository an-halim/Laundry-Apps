create database LDB
use LDB
go

create table Tabel_user(
Username varchar(10) primary key not null, 
User_password varchar(255) not null,
Nama varchar(20) not null,
Alamat varchar(255) not null,
No_hp varchar(13) not null,
date date not null,
Is_admin char(1) not null
)
go

drop table Tabel_user

insert into Tabel_user values('anhalim','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','12/12/2000', '1' )
insert into Tabel_user values('heker','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','11/12/2000', '1' )
insert into Tabel_user values('anhalima','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','2000/12/18', '1' )
insert into Tabel_user values('asddsad','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','2000/12/31', '1' )
select * from Tabel_user

create table Tabel_order(
Id_layanan char(6) primary key not null,
Id_user char(6) foreign key references Tabel_user(Id_user),
Tanggal_transaksi datetime,
Jumlah_produk varchar(),
Total_harga numeric
)
go

create table Data_harga_layanan(
Id_layanan char(6) foreign key references Tabel_order(Id_layanan),
Harga numeric,
Detail_layanan varchar(30)
)
go
