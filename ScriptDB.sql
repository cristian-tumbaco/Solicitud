--Creacion de DB
create database Solicitudes
go

use Solicitudes
go

--Creacion de Tabla
create table Usuarios(
id int primary key identity(1,1),
nombre nvarchar(20),
cola int,
atendido bit
)
go