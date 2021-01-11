CREATE DATABASE RI1
go
USE RI1


Create Table Users 
(
 UserID int identity (1,1) primary key,
 LoginName nvarchar (100) unique not null,
 Password nvarchar (100) unique not null,
 Nombre nvarchar(100) not null,
 Apellido nvarchar (100) not null,
 Cargo nvarchar (100) not null,
 Email nvarchar (100) not null
)

Create Table Reservaciones
(
FOLIO int identity (1,1) primary key,
NombreCliente varchar (30) not null ,
Fecha date not null,
Hora time not null,
CantidadPersonas int not null,
NoTelefono bigint not null 
)
SELECT * FROM Reservaciones


select * from Users
 
  Insert into Users values ('Alex','alex','Alex','Lopez','Administrador','alexwolfs997@gmail.com')
  Insert into Users values ('Bryan','Bryan','Bryan','Lopez','Recepcionista','alexwolfs997@gmail.com')
  Insert into Users values ('Alejandro','asdwerzw','Alejandro','Lopez','Recepcionista','alexwolfs997@gmail.com')

select * from Users where LoginName = 'Alex' and Password = 'alex'


declare @user nvarchar(100)='Alex'
declare @pass nvarchar(100)='alex'
select * from Users where LoginName = @user and Password=  @pass


select * from Reservaciones
Insert into Reservaciones values ('Ethan Lopez','2019-03-21','9:00',10,6648087070)

--------------------------MOSTRAR 
create proc MostrarProductos
as
select *from Reservaciones
go

--------------------------INSERTAR 
create proc InsetarProductos
@nombre varchar (30),
@fecha date,
@hora time,
@cantidad int,
@Notele bigint
as
insert into Reservaciones values (@nombre,@fecha,@hora,@cantidad,@Notele)
go


------------------EDITAR

create proc EditarProductos
@nombre varchar (30),
@fecha date,
@hora time,
@cantidad int,
@Notele bigint,
@folio int
as
update Reservaciones set NombreCliente=@nombre, Fecha=@fecha, Hora=@hora, CantidadPersonas=@cantidad, NoTelefono=@Notele where FOLIO=@folio
go
------------------------ELIMINAR
create proc EliminarProducto
@foliopro int
as
delete from Reservaciones where FOLIO=@foliopro
go

exec InsetarProductos 'eso','2019-02-21','9:00',10,664485
exec MostrarProductos
exec EditarProductos 'apoco','2019-03-24','1:34',42,668524,2 

exec EliminarProducto 4