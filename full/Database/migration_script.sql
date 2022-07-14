IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Area] (
        [IdArea] int NOT NULL IDENTITY,
        [NameArea] varchar(150) NULL,
        CONSTRAINT [PK__Area__2FC141AAEF044606] PRIMARY KEY ([IdArea])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Country] (
        [IdCountry] int NOT NULL IDENTITY,
        [NameCountry] varchar(150) NULL,
        CONSTRAINT [PK__Country__F99F104DBB92DEC1] PRIMARY KEY ([IdCountry])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [EventType] (
        [IdEvent] int NOT NULL IDENTITY,
        [NameEventType] varchar(20) NOT NULL,
        CONSTRAINT [PK__EventTyp__E0B2AF3997755298] PRIMARY KEY ([IdEvent])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Objective] (
        [IdObjective] int NOT NULL IDENTITY,
        [NameObjective] varchar(150) NULL,
        [IndicadorObjective] varchar(max) NULL,
        [MetasObjective] varchar(max) NULL,
        [ObjectiveObjective] varchar(max) NULL,
        CONSTRAINT [PK__Objectiv__76514F972A885A7E] PRIMARY KEY ([IdObjective])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [OrganizationStatus] (
        [IdOrganizationStatus] int NOT NULL IDENTITY,
        [NameOrganizationStatus] varchar(50) NULL,
        CONSTRAINT [PK__Organiza__EF65CC7F6C80E7B8] PRIMARY KEY ([IdOrganizationStatus])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [OrganizationType] (
        [IdOrganizationType] int NOT NULL IDENTITY,
        [NameOrganizationType] varchar(50) NULL,
        CONSTRAINT [PK__Organiza__4D4A4C69CDAE7A2A] PRIMARY KEY ([IdOrganizationType])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Person] (
        [IdPerson] int NOT NULL IDENTITY,
        [NamePerson] varchar(150) NULL,
        [SurnamePerson] varchar(150) NULL,
        [EmailPerson] varchar(150) NULL,
        [PhonePerson] varchar(150) NULL,
        CONSTRAINT [PK__Person__A5D4E15B84CD3DA8] PRIMARY KEY ([IdPerson])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [ProjectStatus] (
        [IdProjectStatus] int NOT NULL IDENTITY,
        [NameProjectStatus] varchar(150) NULL,
        CONSTRAINT [PK__ProjectS__E0824C87AB6CACAD] PRIMARY KEY ([IdProjectStatus])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Organization] (
        [IdOrganization] int NOT NULL IDENTITY,
        [NameOrganization] varchar(150) NULL,
        [DescriptionOrganization] varchar(150) NULL,
        [EmailOrganization] varchar(100) NULL,
        [Country] int NULL,
        [Phone] varchar(150) NULL,
        [IdOrganizationType] int NULL,
        [IdOrganizationStatus] int NULL,
        CONSTRAINT [PK__Organiza__C14A1C272D546BFB] PRIMARY KEY ([IdOrganization]),
        CONSTRAINT [FkOrganizationCountry] FOREIGN KEY ([Country]) REFERENCES [Country] ([IdCountry]),
        CONSTRAINT [FkOrganizationOrganizationStatus] FOREIGN KEY ([IdOrganizationStatus]) REFERENCES [OrganizationStatus] ([IdOrganizationStatus]),
        CONSTRAINT [FkOrganizationOrganizationType] FOREIGN KEY ([IdOrganizationType]) REFERENCES [OrganizationType] ([IdOrganizationType])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [PersonObjective] (
        [IdPersonObjective] int NOT NULL IDENTITY,
        [IdPerson] int NULL,
        [IdObjective] int NULL,
        CONSTRAINT [PK__PersonOb__E2F376D70A3142B9] PRIMARY KEY ([IdPersonObjective]),
        CONSTRAINT [FkObjectivePerson] FOREIGN KEY ([IdObjective]) REFERENCES [Objective] ([IdObjective]),
        CONSTRAINT [FkPersonObjective] FOREIGN KEY ([IdPerson]) REFERENCES [Person] ([IdPerson])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Project] (
        [IdProject] int NOT NULL IDENTITY,
        [MontoProject] int NULL,
        [CreationDateProject] date NULL,
        [StartDateProject] date NULL,
        [EndDateProject] date NULL,
        [MonthsProject] int NULL,
        [DescriptionProject] varchar(max) NULL,
        [KeyWordsProject] varchar(max) NULL,
        [ObjectivesProject] varchar(max) NULL,
        [IdArea] int NULL,
        [IdProjectStatus] int NULL,
        [IdObjectiveObjective] int NULL,
        [IdPersonResponsable] int NULL,
        CONSTRAINT [PK__Project__B9E13D24B9508CF8] PRIMARY KEY ([IdProject]),
        CONSTRAINT [FkProjectArea] FOREIGN KEY ([IdArea]) REFERENCES [Area] ([IdArea]),
        CONSTRAINT [FkProjectPersonResponsable] FOREIGN KEY ([IdPersonResponsable]) REFERENCES [Person] ([IdPerson]),
        CONSTRAINT [FkProjectProjectStatus] FOREIGN KEY ([IdProjectStatus]) REFERENCES [ProjectStatus] ([IdProjectStatus])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [Event] (
        [IdEvent] int NOT NULL IDENTITY,
        [NameEvent] varchar(60) NOT NULL,
        [DateEvent] date NOT NULL,
        [DescriptionEvent] varchar(255) NOT NULL,
        [ObjectiveEvent] int NOT NULL,
        [IdEventType] int NULL,
        [SizeEvent] int NULL,
        [CostEvent] money NOT NULL,
        [IdOrganization] int NOT NULL,
        CONSTRAINT [PK__Event__E0B2AF39A124F1D6] PRIMARY KEY ([IdEvent]),
        CONSTRAINT [FkEventEventType] FOREIGN KEY ([IdEventType]) REFERENCES [EventType] ([IdEvent]),
        CONSTRAINT [FkEventObjective] FOREIGN KEY ([ObjectiveEvent]) REFERENCES [Objective] ([IdObjective]),
        CONSTRAINT [FkEventOrganization] FOREIGN KEY ([IdOrganization]) REFERENCES [Organization] ([IdOrganization])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [OrganizationObjective] (
        [IdOrganizationObjective] int NOT NULL IDENTITY,
        [IdOrganization] int NULL,
        [IdObjective] int NULL,
        CONSTRAINT [PK__Organiza__4D7C5147A927FDCC] PRIMARY KEY ([IdOrganizationObjective]),
        CONSTRAINT [FkObjectiveOrganization] FOREIGN KEY ([IdObjective]) REFERENCES [Objective] ([IdObjective]),
        CONSTRAINT [FkOrganizationObjective] FOREIGN KEY ([IdOrganization]) REFERENCES [Organization] ([IdOrganization])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [OrganizationPerson] (
        [IdOrganizationPerson] int NOT NULL IDENTITY,
        [IdPerson] int NULL,
        [IdOrganization] int NULL,
        CONSTRAINT [PK__Organiza__573676C95D1F2260] PRIMARY KEY ([IdOrganizationPerson]),
        CONSTRAINT [FkOrganizationPerson] FOREIGN KEY ([IdOrganization]) REFERENCES [Organization] ([IdOrganization]),
        CONSTRAINT [FkPersonOrganization] FOREIGN KEY ([IdPerson]) REFERENCES [Person] ([IdPerson])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [OrganizationProject] (
        [IdOrganizationProject] int NOT NULL IDENTITY,
        [IdOrganization] int NULL,
        [IdProject] int NULL,
        CONSTRAINT [PK__Organiza__171D148FD6B00AAF] PRIMARY KEY ([IdOrganizationProject]),
        CONSTRAINT [FkOrganizationProject] FOREIGN KEY ([IdOrganization]) REFERENCES [Organization] ([IdOrganization]),
        CONSTRAINT [FkProjectOrganization] FOREIGN KEY ([IdProject]) REFERENCES [Project] ([IdProject])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [PersonProject] (
        [IdPersonProject] int NOT NULL IDENTITY,
        [IdPerson] int NULL,
        [IdProject] int NULL,
        CONSTRAINT [PK__PersonPr__8D705DB6991C390F] PRIMARY KEY ([IdPersonProject]),
        CONSTRAINT [FkPersonProject] FOREIGN KEY ([IdPerson]) REFERENCES [Person] ([IdPerson]),
        CONSTRAINT [FkProjectPerson] FOREIGN KEY ([IdProject]) REFERENCES [Project] ([IdProject])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [ProjectObjective] (
        [IdProjectObjective] int NOT NULL IDENTITY,
        [IdProject] int NULL,
        [IdObjective] int NULL,
        CONSTRAINT [PK__ProjectO__A2C5D3BE860140F1] PRIMARY KEY ([IdProjectObjective]),
        CONSTRAINT [FkObjectiveProject] FOREIGN KEY ([IdObjective]) REFERENCES [Objective] ([IdObjective]),
        CONSTRAINT [FkProjectObjective] FOREIGN KEY ([IdProject]) REFERENCES [Project] ([IdProject])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE TABLE [PersonEvent] (
        [IdPersonEvent] int NOT NULL IDENTITY,
        [IdEvent] int NULL,
        [IdPerson] int NULL,
        CONSTRAINT [PK__PersonEv__7E6E2035A4F07BCC] PRIMARY KEY ([IdPersonEvent]),
        CONSTRAINT [FkEventEventEvent] FOREIGN KEY ([IdEvent]) REFERENCES [Event] ([IdEvent]),
        CONSTRAINT [FkPersonEventEvent] FOREIGN KEY ([IdPerson]) REFERENCES [Person] ([IdPerson])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Event_IdEventType] ON [Event] ([IdEventType]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Event_IdOrganization] ON [Event] ([IdOrganization]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Event_ObjectiveEvent] ON [Event] ([ObjectiveEvent]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Organization_Country] ON [Organization] ([Country]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Organization_IdOrganizationStatus] ON [Organization] ([IdOrganizationStatus]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Organization_IdOrganizationType] ON [Organization] ([IdOrganizationType]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationObjective_IdObjective] ON [OrganizationObjective] ([IdObjective]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationObjective_IdOrganization] ON [OrganizationObjective] ([IdOrganization]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationPerson_IdOrganization] ON [OrganizationPerson] ([IdOrganization]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationPerson_IdPerson] ON [OrganizationPerson] ([IdPerson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationProject_IdOrganization] ON [OrganizationProject] ([IdOrganization]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_OrganizationProject_IdProject] ON [OrganizationProject] ([IdProject]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonEvent_IdEvent] ON [PersonEvent] ([IdEvent]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonEvent_IdPerson] ON [PersonEvent] ([IdPerson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonObjective_IdObjective] ON [PersonObjective] ([IdObjective]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonObjective_IdPerson] ON [PersonObjective] ([IdPerson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonProject_IdPerson] ON [PersonProject] ([IdPerson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_PersonProject_IdProject] ON [PersonProject] ([IdProject]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Project_IdArea] ON [Project] ([IdArea]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Project_IdPersonResponsable] ON [Project] ([IdPersonResponsable]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_Project_IdProjectStatus] ON [Project] ([IdProjectStatus]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_ProjectObjective_IdObjective] ON [ProjectObjective] ([IdObjective]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    CREATE INDEX [IX_ProjectObjective_IdProject] ON [ProjectObjective] ([IdProject]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220705005130_mssql.onprem_migration_410')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220705005130_mssql.onprem_migration_410', N'6.0.5');
END;
GO

COMMIT;
GO

