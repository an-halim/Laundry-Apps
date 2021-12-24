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


insert into userdata values('anhalim','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','12/12/2000', '1' )
insert into userdata values('heker','123', 'Halim', 'jl kh marwan ah jragung karangawen demak', '085647847468','11/12/2000', '1' )
insert into userdata values('jani','123', 'M jani', 'jl kuncup yogyakarta', '085647847468','2000/12/18', '1' )
select * from userdata

create table orders(
order_id char(6) primary key not null,
user_id varchar(10) foreign key references userdata(username) not null,
trx_date datetime,
product_total varchar(255),
total_price numeric,
state varchar(10) check(state in ('Received', 'On Progres', 'Completed')) not null
)
go

insert into orders values('OD0001', 'jani', '11/12/2021', '4', 25000)

create table order_detail(
order_id char(6) foreign key references orders(order_id) not null,
service_id char(6) foreign key references service(service_id) not null,
user_id varchar(10) foreign key references userdata(username),
trx_date datetime,
Jumlah_produk varchar(255),
Total_harga numeric
)
go

insert into order_detail values('OD0001', 'DK0001', 'jani', '11/12/2021', '1', 6000)
insert into order_detail values('OD0001', 'DK0002', 'jani', '11/12/2021', '1', 6000)
insert into order_detail values('OD0001', 'DK0002', 'jani', '11/12/2021', '1', 7000)


create table service(
service_id char(6) primary key not null,
price numeric,
service_name varchar(45),
service_detail varchar(255)
)
go



insert into service values('DK0001', '6000', 'kaos', 'kaos pendek kiloan')
insert into service values('DK0002', '6000', 'celana', 'celana pendek kiloan')
insert into service values('DK0003', '7000', 'celana panjang', 'celana panjang kiloan')
insert into service values('DK0004', '6000', 'kaos', 'kaos pendek kiloan')
insert into service values('DK0005', '6000', 'kaos', 'kaos pendek kiloan')
insert into service values('DK0006', '8000', 'kaos', 'kemeja pendek kiloan')

select * from service

select order_detail.order_id, order_detail.service_id, order_detail.trx_date, order_detail.Jumlah_produk, order_detail.Total_harga from orders inner join order_detail on orders.order_id = order_detail.order_id

select count(*) as total from orders where orders.user_id='jani'

select count(*) as total from orders

//misc
insert into userdata values ('jambrud', 'jannisuani', 'jani sujono', 'jl kenari indah yogyakarta', '088215293123', '12/12/2001','0')


insert into orders values ('OD0004', 'anhalim', '2021/12/15', '2', '1200000', 'Completed')
insert into order_detail values('OD0004', 'DK0001', 'anhalim', '2021/12/15', '100', '6000000')
insert into order_detail values('OD0004', 'DK0002', 'anhalim', '2021/12/15', '100', '6000000')

select * from order_detail
select format(GETDATE(), 'dd-MM-yyyy')
update orders set state='Completed' where order_id='OD0002'

select order_id, user_id, format(trx_date, 'DD-MM-yyyy' ) as trx_date, format(total_price, 'c', 'id-ID') as total_price, state from orders 
select format(sum(total_price), 'c', 'id-ID') as total from orders 
select count(*) as total from orders


select count(*) as total from orders where state='Completed'


