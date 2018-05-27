
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2018 00:18:03
-- Generated from EDMX file: F:\vs2012输出\FFeat.Note\FFeat.Note.Model\NoteModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FFeat.Note];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(32)  NOT NULL,
    [Pwd] nvarchar(32)  NOT NULL,
    [LoginTime] datetime  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(32)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActionName] nvarchar(32)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'R_UsreInfo_ActionInfo'
CREATE TABLE [dbo].[R_UsreInfo_ActionInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HasPermission] bit  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [UserInfoId] int  NOT NULL,
    [ActionInfoId] int  NOT NULL
);
GO

-- Creating table 'NoteInfo'
CREATE TABLE [dbo].[NoteInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NoteName] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubContent] nvarchar(max)  NOT NULL,
    [NoteType] int  NOT NULL,
    [UserInfoId] int  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_Id] int  NOT NULL,
    [RoleInfo_Id] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_Id] int  NOT NULL,
    [ActionInfo_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'R_UsreInfo_ActionInfo'
ALTER TABLE [dbo].[R_UsreInfo_ActionInfo]
ADD CONSTRAINT [PK_R_UsreInfo_ActionInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NoteInfo'
ALTER TABLE [dbo].[NoteInfo]
ADD CONSTRAINT [PK_NoteInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserInfo_Id], [RoleInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY CLUSTERED ([UserInfo_Id], [RoleInfo_Id] ASC);
GO

-- Creating primary key on [RoleInfo_Id], [ActionInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([RoleInfo_Id], [ActionInfo_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_Id])
    REFERENCES [dbo].[RoleInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_Id]);
GO

-- Creating foreign key on [RoleInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_Id])
    REFERENCES [dbo].[RoleInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_Id])
    REFERENCES [dbo].[ActionInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_Id]);
GO

-- Creating foreign key on [UserInfoId] in table 'R_UsreInfo_ActionInfo'
ALTER TABLE [dbo].[R_UsreInfo_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_UsreInfo_ActionInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UsreInfo_ActionInfo'
CREATE INDEX [IX_FK_UserInfoR_UsreInfo_ActionInfo]
ON [dbo].[R_UsreInfo_ActionInfo]
    ([UserInfoId]);
GO

-- Creating foreign key on [ActionInfoId] in table 'R_UsreInfo_ActionInfo'
ALTER TABLE [dbo].[R_UsreInfo_ActionInfo]
ADD CONSTRAINT [FK_ActionInfoR_UsreInfo_ActionInfo]
    FOREIGN KEY ([ActionInfoId])
    REFERENCES [dbo].[ActionInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_UsreInfo_ActionInfo'
CREATE INDEX [IX_FK_ActionInfoR_UsreInfo_ActionInfo]
ON [dbo].[R_UsreInfo_ActionInfo]
    ([ActionInfoId]);
GO

-- Creating foreign key on [UserInfoId] in table 'NoteInfo'
ALTER TABLE [dbo].[NoteInfo]
ADD CONSTRAINT [FK_UserInfoNoteInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoNoteInfo'
CREATE INDEX [IX_FK_UserInfoNoteInfo]
ON [dbo].[NoteInfo]
    ([UserInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------