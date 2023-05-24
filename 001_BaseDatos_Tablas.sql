--TABLAS
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
codigo varchar(50),
documento varchar (25),
nombreCompleto varchar(100),
correo varchar(50),
telefono varchar(50),
idRol int references Rol(idRol),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
lugarVive varchar(100),
lugarTrabajo varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Ida(
idIda int primary key identity(1,1),
descripcion varchar(50),
Precio decimal (10,2),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

create table Retorno(
idRetorno int primary key identity(1,1),
descripcion varchar(50),
Precio decimal (10,2),
esActivo bit,
fechaRegistro datetime default getdate()
)
go

Create table Clientes(
idCliente int primary key identity(1,1),
documentoPasaporte varchar (25),
nombreCompleto varchar(100),
correo varchar(50),
telefono varchar(50),
nacionalidad varchar(100),
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

create table VentaBoleto(
idVentaBoleto int primary key identity(1,1),
numeroVenta varchar(6),
idTipoDocumentoVenta int references TipoDocumentoVenta(idTipoDocumentoVenta),
idUsuario int references Usuario(idUsuario),
documentoCliente varchar(10),
nombreCliente varchar(20),
subTotal decimal(10,2),
total decimal(10,2),
observaciones varchar(5000),
fechaRegistro datetime default getdate()
)
go

create table DetalleVenta(
idDetalleVenta int primary key identity(1,1),
idVentaBoleto int references VentaBoleto(idVentaBoleto),
NumeroBoleto int,
idIda int references Ida(idIda),
fechaIda datetime,
idRetorno int references Retorno(idRetorno),
fechaRetorno datetime,
precio decimal(10,2),
total decimal(10,2)
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
fechaRegistro datetime default getdate()
)
go

create table DetalleReserva(
idDetalleReserva int primary key identity(1,1),
idReserva int references Reserva(idReserva),
IdIda int references Ida(idIda),
FechaIda datetime,
IdRetorno int references Retorno(idRetorno),
FechaRetorno datetime
)
go

create table Pago(
idPago int primary key identity(1,1),
numeroPago varchar(6),
idUsuario int references Usuario(idUsuario),
documento varchar (20),
nombreCompleto varchar (100),
subTotal decimal(10,2),
total decimal(10,2),
fechaRegistro datetime default getdate()
)
go

create table DetallePago(
idDetallePago int primary key identity(1,1),
idPago int references Pago(idPago),
mesPago datetime,
pago decimal(10,2),
subTotal decimal(10,2),
total decimal(10,2)
)
go