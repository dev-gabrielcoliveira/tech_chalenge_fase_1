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

CREATE TABLE [usuario] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [Senha] VARCHAR(32) NOT NULL,
    [VARCHAR(10)] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_usuario] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260415184204_primeira-migracao', N'8.0.0');
GO

COMMIT;
GO

