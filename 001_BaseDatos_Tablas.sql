
create database DBVENTABOLETOS
go

use DBVENTABOLETOS
go

create table Menu(
idMenu int primary key identity(1,1),
descripcion varchar(30),
idMenuPadre int references Menu(idMenu),
icono varchar(30),
controlador varchar(30),
paginaAccion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Rol(
idRol int primary key identity(1,1),
descripcion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)
go
 
 create table RolMenu(
 idRolMenu int primary key identity(1,1),
 idRol int references Rol(idRol),
 idMenu int references Menu(idMenu),
 esActivo bit,
 fechaRegistro datetime default getdate()
 )
 go

create table Usuario(
idUsuario int primary key identity(1,1),
Codigo varchar(50),
NomcbreCompleto varchar(50),
correo varchar(50),
telefono varchar(50),
idRol int references Rol(idRol),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
Lugar varchar(100),
LugarTrabajo varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Ida(
idIda int primary key identity(1,1),
descripcion varchar(50),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Retorno(
idRetorno int primary key identity(1,1),
descripcion varchar(50),
esActivo bit,
fechaRegistro datetime default getdate()
)
go


create table NumeroCorrelativo(
idNumeroCorrelativo int primary key identity(1,1),
ultimoNumero int,
cantidadDigitos int,
gestion varchar(100),
fechaActualizacion datetime
)
go

create table TipoDocumentoVenta(
idTipoDocumentoVenta int primary key identity(1,1),
descripcion varchar(50),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Venta(
idVenta int primary key identity(1,1),
numeroVenta varchar(6),
idTipoDocumentoVenta int references TipoDocumentoVenta(idTipoDocumentoVenta),
idUsuario int references Usuario(idUsuario),
documentoCliente varchar(10),
nombreCliente varchar(20),
Observaciones varchar(5000),
subTotal decimal(10,2),
impuestoTotal decimal(10,2),
Total decimal(10,2),
fechaRegistro datetime default getdate()
)
go

create table DetalleVenta(
idDetalleVenta int primary key identity(1,1),
idVenta int references Venta(idVenta),
IdIda int references Ida(idIda),
FechaIda datetime,
IdRetorno int references Retorno(idRetorno),
FechaRetorno datetime,
NumeroBoleto int,
precio decimal(10,2),
total decimal(10,2)
fechaRegistro datetime default getdate()
)
go

create table Negocio(
idNegocio int primary key,
urlLogo varchar(500),
nombreLogo varchar(100),
numeroDocumento varchar(50),
nombre varchar(50),
correo varchar(50),
direccion varchar(50),
telefono varchar(50),
porcentajeImpuesto decimal(10,2),
simboloMoneda varchar(5)
)
go

create table Configuracion(
recurso varchar(50),
propiedad varchar(50),
valor varchar(60)
)
go

--VentaBoletosAgentes

create table Reserva(
idReserva int primary key identity(1,1),
numeroReserva varchar(6),
idTipoDocumentoVenta int references TipoDocumentoVenta(idTipoDocumentoVenta),
idUsuario int references Usuario(idUsuario),
documentoCliente varchar(10),
nombreCliente varchar(20),
Observaciones varchar(5000),
)
go

create table DetalleReserva(
idDetalleReserva int primary key identity(1,1),
idReserva int references Reserva(idReserva),
IdIda int references Ida(idIda),
FechaIda datetime,
IdRetorno int references Retorno(idRetorno),
FechaRetorno datetime,
NumeroBoleto int,
)
go