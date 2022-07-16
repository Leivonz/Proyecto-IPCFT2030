CREATE TABLE Country (
	IdCountry int IDENTITY(1,1) PRIMARY KEY,
	NameCountry varchar(150) NOT NULL
)
CREATE TABLE EventType (
	IdEvent int IDENTITY(1,1) PRIMARY KEY,
	NameEventType varchar(20)  NOT NULL,
)
CREATE TABLE Objective (
	IdObjective int IDENTITY(1,1) PRIMARY KEY,
	NameObjective varchar(150) ,
	IndicadorObjective varchar(MAX) ,
	MetasObjective varchar(MAX) ,
	ObjectiveObjective varchar(MAX) ,
)
CREATE TABLE OrganizationStatus (
	IdOrganizationStatus int IDENTITY(1,1) PRIMARY KEY,
	NameOrganizationStatus varchar(50) ,
)
CREATE TABLE OrganizationType (
	IdOrganizationType int IDENTITY(1,1) PRIMARY KEY,
	NameOrganizationType varchar(50) ,
)
CREATE TABLE ProjectStatus (
	IdProjectStatus int IDENTITY(1,1) PRIMARY KEY,
	NameProjectStatus varchar(150) ,
)
CREATE TABLE Organization (
	IdOrganization int IDENTITY(1,1) PRIMARY KEY,
	NameOrganization varchar(150)  NOT NULL,
	DescriptionOrganization varchar(150)  NOT NULL,
	EmailOrganization varchar(100)  NOT NULL,
	Country int NOT NULL,
	Phone varchar(30)  NOT NULL,
	IdOrganizationType int NOT NULL,
	IdOrganizationStatus int NOT NULL,
	CONSTRAINT FkOrganizationCountry FOREIGN KEY (Country) REFERENCES Country(IdCountry),
	CONSTRAINT FkOrganizationOrganizationStatus FOREIGN KEY (IdOrganizationStatus) REFERENCES OrganizationStatus(IdOrganizationStatus),
	CONSTRAINT FkOrganizationOrganizationType FOREIGN KEY (IdOrganizationType) REFERENCES OrganizationType(IdOrganizationType)
)
CREATE TABLE OrganizationObjective (
	IdOrganizationObjective int IDENTITY(1,1) PRIMARY KEY,
	IdOrganization int NULL,
	IdObjective int NULL,
	CONSTRAINT FkObjectiveOrganization FOREIGN KEY (IdObjective) REFERENCES Objective(IdObjective),
	CONSTRAINT FkOrganizationObjective FOREIGN KEY (IdOrganization) REFERENCES Organization(IdOrganization)
)
CREATE TABLE Person (
	IdPerson int IDENTITY(1,1) PRIMARY KEY,
	NamePerson varchar(150)  NOT NULL,
	SurnamePerson varchar(150)  NOT NULL,
	EmailPerson varchar(150)  NOT NULL,
	PhonePerson varchar(150)  NOT NULL,
	PasswordPerson varchar(MAX)  NOT NULL,
	OrganizationName varchar(20) NOT NULL,
	CountryPerson int NOT NULL,
	CONSTRAINT FK__Person__Country FOREIGN KEY (CountryPerson) REFERENCES Country(IdCountry),
)
CREATE TABLE PersonObjective (
	IdPersonObjective int IDENTITY(1,1) PRIMARY KEY,
	IdPerson int NULL,
	IdObjective int NULL,
	CONSTRAINT FkObjectivePerson FOREIGN KEY (IdObjective) REFERENCES Objective(IdObjective),
	CONSTRAINT FkPersonObjective FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson)
)
CREATE TABLE Project (
	IdProject int IDENTITY(1,1) PRIMARY KEY,
	CreationDateProject date NULL,
	StartDateProject date NULL,
	EndDateProject date NULL,
	MonthsProject int NULL,
	DescriptionProject varchar(MAX) ,
	KeyWordsProject varchar(MAX) ,
	ObjectivesProject varchar(MAX) ,
	IdArea int NULL,
	IdProjectStatus int NULL,
	IdObjectiveObjective int NULL,
	IdPersonResponsable int NULL,
	CONSTRAINT FkProjectPersonResponsable FOREIGN KEY (IdPersonResponsable) REFERENCES Person(IdPerson),
	CONSTRAINT FkProjectProjectStatus FOREIGN KEY (IdProjectStatus) REFERENCES ProjectStatus(IdProjectStatus)
)
CREATE TABLE ProjectObjective (
	IdProjectObjective int IDENTITY(1,1) PRIMARY KEY,
	IdProject int NULL,
	IdObjective int NULL,
	CONSTRAINT FkObjectiveProject FOREIGN KEY (IdObjective) REFERENCES Objective(IdObjective),
	CONSTRAINT FkProjectObjective FOREIGN KEY (IdProject) REFERENCES Project(IdProject)
)
CREATE TABLE Event (
	IdEvent int IDENTITY(1,1) PRIMARY KEY,
	NameEvent varchar(60)  NOT NULL,
	DateEvent date NOT NULL,
	DescriptionEvent varchar(255)  NOT NULL,
	ObjectiveEvent int NOT NULL,
	IdEventType int NULL,
	SizeEvent int NULL,
	IdOrganization int NOT NULL,
	CONSTRAINT FkEventEventType FOREIGN KEY (IdEventType) REFERENCES EventType(IdEvent),
	CONSTRAINT FkEventObjective FOREIGN KEY (ObjectiveEvent) REFERENCES Objective(IdObjective),
	CONSTRAINT FkEventOrganization FOREIGN KEY (IdOrganization) REFERENCES Organization(IdOrganization)
)
CREATE TABLE OrganizationPerson (
	IdOrganizationPerson int IDENTITY(1,1) PRIMARY KEY,
	IdPerson int NULL,
	IdOrganization int NULL,
	CONSTRAINT FkOrganizationPerson FOREIGN KEY (IdOrganization) REFERENCES Organization(IdOrganization),
	CONSTRAINT FkPersonOrganization FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson)
)
CREATE TABLE OrganizationProject (
	IdOrganizationProject int IDENTITY(1,1) PRIMARY KEY,
	IdOrganization int NULL,
	IdProject int NULL,
	CONSTRAINT FkOrganizationProject FOREIGN KEY (IdOrganization) REFERENCES Organization(IdOrganization),
	CONSTRAINT FkProjectOrganization FOREIGN KEY (IdProject) REFERENCES Project(IdProject)
)
CREATE TABLE PersonEvent (
	IdPersonEvent int IDENTITY(1,1) PRIMARY KEY,
	IdEvent int NOT NULL,
	IdPerson int NOT NULL,
	CONSTRAINT FkPersonEventEvent FOREIGN KEY (IdEvent) REFERENCES Event(IdEvent),
	CONSTRAINT FkPersonEventPerson FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson)
)
CREATE TABLE PersonProject (
	IdPersonProject int IDENTITY(1,1) PRIMARY KEY,
	IdPerson int NOT NULL,
	IdProject int NOT NULL,
	CONSTRAINT FkPersonProject FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson),
	CONSTRAINT FkProjectPerson FOREIGN KEY (IdProject) REFERENCES Project(IdProject)
)
CREATE TABLE WebProject(
IdWebProject int IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(MAX),
title VARCHAR(MAX),
description VARCHAR(MAX),
status varchar(11) not null check(status ='Activo' AND status = 'Desactivado'), 
img VARCHAR(MAX)
)
CREATE TABLE WebProjectPerson(
IdWebProjectPerson int IDENTITY(1,1) PRIMARY KEY,
IdPerson int,
IdWebProject int
CONSTRAINT FkPersonWebProject FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson),	
CONSTRAINT FkWebProject FOREIGN KEY (IdWebProject) REFERENCES WebProject(IdWebProject),
)
CREATE TABLE EmailList(
IdEmail int IDENTITY(1,1) PRIMARY KEY,
Email varchar(max) ,
)