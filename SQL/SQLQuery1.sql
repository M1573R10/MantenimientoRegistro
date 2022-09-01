create database MantenimientoUsuarios

use MantenimientoUsuarios

create table Usuario(
	Nombre char(20) primary key,
	Apellido char(20) not null,
	Usuario char(20) not null,
	Clave varchar(20) not null,
)

create procedure Registro
@Nombre char(20),
@Apellido char(20),
@Usuario char(20),
@Clave varchar(20)
as
insert into Usuario values(@Nombre, @Apellido, @Usuario, @Clave)
go

create procedure vai_logueo
@Nombre char(20),
@Clave varchar(20)
as
select * from Usuario where Usuario = @Nombre and Clave = @Clave
go