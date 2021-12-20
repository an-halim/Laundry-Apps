create database db_laundry
use db_laundry
go

create table user(
username varchar(10) primary key not null, 
password varchar(255) not null,
name varchar(20) not null,
address varchar(255) not null,
number varchar(13) not null,
birth_date date not null,
is_admin char(1) not null
)
go


insert into Tabel_user values('anhalim','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','12/12/2000', '1' )
insert into Tabel_user values('heker','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','11/12/2000', '1' )
insert into Tabel_user values('anhalima','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','2000/12/18', '1' )
insert into Tabel_user values('asddsad','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','2000/12/31', '1' )
select * from Tabel_user

create table order(
service_id char(6) primary key not null,
user_id char(6) foreign key references user(user_id),
trx_date datetime,
product_total varchar(255),
total_price numeric
)
go

create table Order_detail(
Id_order char char(6) primary key not null,
Id_layanan char(6) foreign key references order(Id_layanan),
Id_user char(6) foreign key references user(Id_user),
Tanggal_transaksi datetime,
Jumlah_produk varchar(255),
Total_harga numeric
)
go

create table layanan(
service_id char(6) foreign key references order(service_id),
price numeric,
service_detail varchar(30)
)
go
