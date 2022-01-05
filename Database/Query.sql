create database db_laundry
use db_laundry
go

create table userdata (
username varchar(10) primary key not null, 
password varchar(255) not null,
name varchar(20) not null,
address varchar(255) not null,
number varchar(13) not null,
birth_date date not null,
is_admin char(1) not null
)
go

create table service(
service_id char(6) primary key not null,
price numeric,
service_name varchar(45),
service_detail varchar(255)
)
go

create table orders(
order_id char(6) primary key not null,
user_id varchar(10) foreign key references userdata(username) not null,
trx_date date,
product_total int,
total_price int,
state varchar(20) check(state in ('Received', 'On Progres', 'Completed', 'Canceled', 'Waiting Payment')) not null,
payment_method varchar(15) check (payment_method in ('Cash' , 'Bank Transfer' , 'E-Wallet' , 'Credit Card')),
note varchar(30)
)
go

create table order_detail(
order_id char(6) foreign key references orders(order_id) not null,
service_id char(6) foreign key references service(service_id) not null,
user_id varchar(10) foreign key references userdata(username),
trx_date date,
Jumlah_produk varchar(255),
Total_harga numeric
)
go


insert into userdata values('anhalim','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','12/12/2000', '1' )
insert into userdata values('jamal','123', 'jamalaudin', 'jl kh marwan ah jragung karangawen demak', '085647847468','11/12/2000', '1' )
insert into userdata values('jani','123', 'M jani', 'jl kuncup yogyakarta', '085647847468','2000/12/18', '1' )
insert into userdata values ('jambrud', 'jannisuani', 'jani sujono', 'jl kenari indah yogyakarta', '088215293123', '12/12/2001','0')

insert into userdata values ('satrioz', 'wibiganteng', 'Satrio Wibisono', 'jl ir soetami lampung timur', '082222222222', '12/12/2001','1')


insert into service values('DK0001', '7000', 'Kaos', 'cuci kering 48 jam selesai kiloan')
insert into service values('DK0002', '12000', 'Kaos premium', 'cuci kering 24 jam selesai + strika kiloan')
insert into service values('DK0003', '8000', 'Kemeja', 'cuci kering 48 jam selesai kiloan')
insert into service values('DK0004', '13000', 'Kemeja premium', 'cuci kering 24 jam selesai kiloan')
insert into service values('DK0005', '8000', 'Jaket', 'cuci kering 48 jam selesai sattuan')
insert into service values('DK0006', '13000', 'Jaket premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0007', '30000', 'Jas', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0008', '40000', 'Jas premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0009', '9000', 'Blouse', 'cuci kering 48 jaln selesai satuan')
insert into service values('DK0010', '14000', 'Blouse premium', 'cuci kering 24 jaln selesai satuan')
insert into service values('DK0011', '6000', 'pakaian dalam', 'cuci kering 48 jam selesai kiloan')
insert into service values('DK0012', '12000', 'pakaian dalam premium', 'cuci kering 24 jam selesai kiloan')
insert into service values('DK0013', '7000', 'celana', 'cuci kering 48 jam selesai kiloan pendek/panjang')
insert into service values('DK0014', '1400', 'celana premium', 'cuci kering 24 jam selesai kiloan pendek/panjang')
insert into service values('DK0015', '8000', 'celana jeans', 'cuci kering 48 jam selesai kiloan')
insert into service values('DK0016', '8000', 'celana jeans premium', 'cuci kering 24 jam selesai kiloan')
insert into service values('DK0017', '25000', 'Bed Cover', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0018', '35000', 'bed cover premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0019', '12000', 'sprei', 'cuci kering 48 jam selesai satuan sprei single/double')
insert into service values('DK0020', '24000', 'sprei premium', 'cuci kering 24 jam selesai satuan sprei single/double')
insert into service values('DK0021', '20000', 'Selimut', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0022', '30000', 'Selimut premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0023', '12000', 'sepatu kain', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0024', '20000', 'sepatu kain premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0025', '15000', 'sepatu kulit', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0026', '25000', 'sepatu kulit premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0027', '20000', 'gorden', 'cuci kering 48 jam selesai permeter satuan')
insert into service values('DK0028', '29000', 'gorden premium', 'cuci kering 24 jam selesai permetar satuan')
insert into service values('DK0029', '20000', 'karpet rumah', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0030', '29000', 'karpet rumah premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0031', '25000', 'karpet masjid', 'cuci kering 48 jam selesai satuan')
insert into service values('DK0032', '35000', 'karpet masjid premium', 'cuci kering 24 jam selesai satuan')
insert into service values('DK0033', '30000', 'parfum premium', 'Parfum premium beraroma sakura blossom')
insert into service values('DK0033', '15000', 'jasa strika', 'jasa strika perkilo')

insert into orders values('OD0001', 'jani', '11/12/2021', '2', 19000, 'Received', 'Cash', '')
insert into order_detail values('OD0001', 'DK0001', 'jani', '11/12/2021', '1', 6000)
insert into order_detail values('OD0001', 'DK0002', 'jani', '11/12/2021', '1', 6000)
insert into order_detail values('OD0001', 'DK0002', 'jani', '11/12/2021', '1', 7000)

insert into orders values ('OD0004', 'anhalim', '2021/12/15', '2', '1200000', 'Completed', 'Credit Card', '')
insert into order_detail values('OD0004', 'DK0001', 'anhalim', '2021/12/15', '100', '6000000')
insert into order_detail values('OD0004', 'DK0002', 'anhalim', '2021/12/15', '100', '6000000')

select * from service




