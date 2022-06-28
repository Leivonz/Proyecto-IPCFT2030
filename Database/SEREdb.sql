create database SEREdb
use SEREdb

create table ods(
  id_ods int primary key identity(1, 1),
  nombre_ods varchar(150),
  indicador varchar(max),
  metas_ods varchar(max),
  objetivos_ods varchar(max)
) 

create table pais(
  id_pais int primary key identity(1, 1),
  nombre_pais varchar(150)
) 

create table area(
  id_area int primary key identity(1, 1),
  nombre_area varchar(150),
) 

create table estadoproyecto(
  id_estadoproyecto int primary key identity(1, 1),
  nombre_estadoproyecto varchar(150),
) 

create table persona(
  id_persona int primary key identity(1, 1),
  nombre varchar(150),
  apellido varchar(150),
  email varchar(150),
  fono varchar(150),
) 

create table proyecto(
  id_proyecto int primary key identity(1, 1),
  monto int,
  fecha_Creacion date,
  fecha_inico date,
  fecha_termino date,
  meses int,
  descripcion varchar (max),
  palabras_clave varchar (max),
  objetivos varchar (max),
  id_area int,
  id_estadoproyecto int,
  id_ods int,
  id_personaresponsable int,
  constraint FK_proyecto_area foreign key (id_area) references area(id_area),
  constraint FK_proyecto_estadoproyecto foreign key (id_estadoproyecto) references estadoproyecto(id_estadoproyecto),
  constraint FK_proyecto_personaresponsabe foreign key (id_personaresponsable) references persona(id_persona),
) 

create table estadoorganizacion(
  id_estadoorganizacion int primary key identity(1, 1),
  nombre_estado varchar(50),
) 

create table tipoorganizacion(
  id_tipoorganizacion int primary key identity(1, 1),
  nombre varchar(50)
) 

create table organizacion(
  id_organizacion int primary key identity(1, 1),
  nombre varchar(150),
  descripcion varchar(150),
  correo_organizacion varchar(100),
  pais int,
  telefono varchar(150),
  id_tipoorganizacion int,
  id_estadoorganizacion int,
  constraint FK_organizacion_pais foreign key (pais) references pais(id_pais),
  constraint FK_organizacion_estadoorganizacion foreign key (id_estadoorganizacion) references estadoorganizacion(id_estadoorganizacion),
  constraint FK_organizacion_tipoorganizacion foreign key (id_tipoorganizacion) references tipoorganizacion(id_tipoorganizacion),
) 

create table organizacion_persona(
  id_organizacion_persona int primary key identity(1, 1),
  id_persona int,
  id_organizacion int,
  constraint FK_organizacion_persona foreign key (id_organizacion) references organizacion(id_organizacion),
  constraint FK_persona_organizacion foreign key (id_persona) references persona(id_persona)
) 

create table persona_proyecto(
  id_organizacion_proyecto int primary key identity(1, 1),
  id_persona int,
  id_proyecto int,
  constraint FK_persona_proyecto foreign key (id_persona) references persona(id_persona),
  constraint FK_proyecto_persona foreign key (id_proyecto) references proyecto(id_proyecto)
) 

create table organizacion_proyecto(
  id_organizacion_proyecto int primary key identity(1, 1),
  id_organizacion int,
  id_proyecto int,
  constraint FK_organizacion_proyecto foreign key (id_organizacion) references organizacion(id_organizacion),
  constraint FK_proyecto_organizacion foreign key (id_proyecto) references proyecto(id_proyecto)
) 

create table proyecto_ods(
  id_proyecto_ods int primary key identity(1, 1),
  id_proyecto int,
  id_ods int,
  constraint FK_proyecto_ods foreign key (id_proyecto) references proyecto(id_proyecto),
  constraint FK_ods_proyecto foreign key (id_ods) references ods(id_ods)
) 

create table persona_ods(
  id_persona_ods int primary key identity(1, 1),
  id_persona int,
  id_ods int,
  constraint FK_persona_ods foreign key (id_persona) references persona(id_persona),
  constraint FK_ods_persona foreign key (id_ods) references ods(id_ods)
) 

create table organizacion_ods(
  ip_organizacion_ods int primary key identity(1, 1),
  id_organizacion int,
  id_ods int,
  constraint FK_organizacion_ods foreign key (id_organizacion) references organizacion(id_organizacion),
  constraint FK_ods_organizacion foreign key (id_ods) references ods(id_ods)
)

create table tipo_evento(
	id_evento int primary key,
	nombre_tipo varchar(20) not null
)

create table eventos(
 id_evento int primary key,
 nombre_evento varchar(60) not null,
 fecha_evento date not null,
 desc_evento varchar(255) not null,
 ods_evento int not null,
 id_tipo_evento int,
 cant_cupos int,
 costo_evento money not null,
 id_organizacion int not null,
 foreign key (id_tipo_evento) references tipo_evento(id_evento),
 foreign key (id_organizacion) references organizacion(id_organizacion),
 foreign key (ods_evento) references ods(id_ods)
)


create table Persona_eventos(
	id_evento int,
	id_persona int,
	foreign key (id_evento) references eventos(id_evento),
	foreign key (id_persona) references persona(id_persona) 
)