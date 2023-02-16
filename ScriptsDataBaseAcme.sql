create database DataBaseAcme;

use DataBaseAcme;

create table usuarios
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	usuario VARCHAR(50) NOT NULL,
	password VARCHAR(256) NOT NULL,
	nombre VARCHAR(50) NOT NULL
);

create table Respuesta_Encuesta
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	Id_resulta_encuesta VARCHAR(50),
	nombre_person VARCHAR(50),
	id_Detalle_Encuesta VARCHAR(50),
	respuesta VARCHAR(250)
);

create table Detalle_Encuesta
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	id_Detalle VARCHAR(50) NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	Titulo VARCHAR(50) NOT NULL,
	Requerido INT NOT NULL,
	Resultado VARCHAR(50),
	Estado_Registro INT NOT NULL
);

create table Encuesta
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	Titulo VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	detalle_encuesta VARCHAR(50) NOT NULL,
	Usuario_registro INT NOT NULL,
	Estado_Registro INT NOT NULL
);

