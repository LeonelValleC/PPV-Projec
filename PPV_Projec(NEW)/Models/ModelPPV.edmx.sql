
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/06/2021 10:15:16
-- Generated from EDMX file: C:\Users\leonel.valle\source\repos\PPV-Projec\PPV_Projec(NEW)\Models\ModelPPV.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PPVdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__PPV__buyer__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK__PPV__buyer__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__PPV__first_auth__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK__PPV__first_auth__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__PPV__last_auth__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK__PPV__last_auth__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK__PPV_Fail__buyer__29221CFB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK__PPV_Fail__buyer__29221CFB];
GO
IF OBJECT_ID(N'[dbo].[FK__PPV_Fail__first___2A164134]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK__PPV_Fail__first___2A164134];
GO
IF OBJECT_ID(N'[dbo].[FK__PPV_Fail__last_a__2B0A656D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK__PPV_Fail__last_a__2B0A656D];
GO
IF OBJECT_ID(N'[dbo].[FK__users__id_level__1273C1CD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK__users__id_level__1273C1CD];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK_PPV_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Fail_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK_PPV_Fail_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Fail_MFG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK_PPV_Fail_MFG];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Fail_PN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK_PPV_Fail_PN];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Fail_Vendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV_Fail] DROP CONSTRAINT [FK_PPV_Fail_Vendor];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_MFG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK_PPV_MFG];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_PN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK_PPV_PN];
GO
IF OBJECT_ID(N'[dbo].[FK_PPV_Vendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PPV] DROP CONSTRAINT [FK_PPV_Vendor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[level]', 'U') IS NOT NULL
    DROP TABLE [dbo].[level];
GO
IF OBJECT_ID(N'[dbo].[MFG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MFG];
GO
IF OBJECT_ID(N'[dbo].[PN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PN];
GO
IF OBJECT_ID(N'[dbo].[PPV]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PPV];
GO
IF OBJECT_ID(N'[dbo].[PPV_Fail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PPV_Fail];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO
IF OBJECT_ID(N'[dbo].[Vendor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vendor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [id_client] int IDENTITY(1,1) NOT NULL,
    [clientID] varchar(50)  NULL,
    [client1] varchar(50)  NULL
);
GO

-- Creating table 'levels'
CREATE TABLE [dbo].[levels] (
    [id_level] int IDENTITY(1,1) NOT NULL,
    [level1] varchar(100)  NULL
);
GO

-- Creating table 'MFGs'
CREATE TABLE [dbo].[MFGs] (
    [id_mfg] int IDENTITY(1,1) NOT NULL,
    [mfg1] varchar(50)  NULL,
    [mfg_desc] varchar(150)  NULL
);
GO

-- Creating table 'PNs'
CREATE TABLE [dbo].[PNs] (
    [id_pn] int IDENTITY(1,1) NOT NULL,
    [pn1] varchar(50)  NULL,
    [pnDesc] varchar(100)  NULL
);
GO

-- Creating table 'PPVs'
CREATE TABLE [dbo].[PPVs] (
    [id_ppv] int IDENTITY(1,1) NOT NULL,
    [wo] varchar(100)  NULL,
    [po] varchar(100)  NULL,
    [qty] int  NULL,
    [av_price] decimal(19,4)  NULL,
    [new_price] decimal(19,4)  NULL,
    [buyer] int  NULL,
    [reason] varchar(100)  NULL,
    [times] varchar(50)  NULL,
    [OtherChange] int  NULL,
    [elaborate] varchar(255)  NULL,
    [leadtime] varchar(10)  NULL,
    [explanation] varchar(1700)  NULL,
    [change_unit] decimal(19,4)  NULL,
    [change_unit_perc] float  NULL,
    [current_total] decimal(19,4)  NULL,
    [new_total] decimal(19,4)  NULL,
    [total_increase] decimal(19,4)  NULL,
    [first_auth] int  NULL,
    [last_auth] int  NULL,
    [date_ppv] datetime  NULL,
    [first_date] datetime  NULL,
    [last_date] datetime  NULL,
    [first_approval] bit  NULL,
    [last_approval] bit  NULL,
    [pn] int  NULL,
    [client] int  NULL,
    [vendor] int  NULL,
    [first_note] varchar(255)  NULL,
    [last_note] varchar(255)  NULL,
    [salesOrder] bit  NULL,
    [salesOrder_num] varchar(50)  NULL,
    [note] varchar(255)  NULL,
    [void] bit  NULL,
    [id_mfg] int  NULL
);
GO

-- Creating table 'PPV_Fail'
CREATE TABLE [dbo].[PPV_Fail] (
    [id_ppv] int IDENTITY(1,1) NOT NULL,
    [wo] varchar(100)  NULL,
    [po] varchar(100)  NULL,
    [qty] int  NULL,
    [av_price] decimal(19,4)  NULL,
    [new_price] decimal(19,4)  NULL,
    [buyer] int  NULL,
    [reason] varchar(100)  NULL,
    [times] varchar(50)  NULL,
    [OtherChange] int  NULL,
    [elaborate] varchar(255)  NULL,
    [leadtime] varchar(10)  NULL,
    [explanation] varchar(1700)  NULL,
    [change_unit] decimal(19,4)  NULL,
    [change_unit_perc] float  NULL,
    [current_total] decimal(19,4)  NULL,
    [new_total] decimal(19,4)  NULL,
    [total_increase] decimal(19,4)  NULL,
    [first_auth] int  NULL,
    [last_auth] int  NULL,
    [date_ppv] datetime  NULL,
    [first_date] datetime  NULL,
    [last_date] datetime  NULL,
    [first_approval] bit  NULL,
    [last_approval] bit  NULL,
    [pn] int  NULL,
    [client] int  NULL,
    [vendor] int  NULL,
    [first_note] varchar(255)  NULL,
    [last_note] varchar(255)  NULL,
    [salesOrder] bit  NULL,
    [salesOrder_num] varchar(20)  NULL,
    [note] varchar(255)  NULL,
    [void] bit  NULL,
    [id_mfg] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id_user] int IDENTITY(1,1) NOT NULL,
    [name] varchar(255)  NULL,
    [email] varchar(100)  NULL,
    [username] varchar(50)  NULL,
    [password] varchar(50)  NULL,
    [id] int  NULL,
    [id_level] int  NULL,
    [code] varchar(5)  NULL
);
GO

-- Creating table 'Vendors'
CREATE TABLE [dbo].[Vendors] (
    [id_vendor] int IDENTITY(1,1) NOT NULL,
    [vendorID] varchar(50)  NULL,
    [vendor1] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_client] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([id_client] ASC);
GO

-- Creating primary key on [id_level] in table 'levels'
ALTER TABLE [dbo].[levels]
ADD CONSTRAINT [PK_levels]
    PRIMARY KEY CLUSTERED ([id_level] ASC);
GO

-- Creating primary key on [id_mfg] in table 'MFGs'
ALTER TABLE [dbo].[MFGs]
ADD CONSTRAINT [PK_MFGs]
    PRIMARY KEY CLUSTERED ([id_mfg] ASC);
GO

-- Creating primary key on [id_pn] in table 'PNs'
ALTER TABLE [dbo].[PNs]
ADD CONSTRAINT [PK_PNs]
    PRIMARY KEY CLUSTERED ([id_pn] ASC);
GO

-- Creating primary key on [id_ppv] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [PK_PPVs]
    PRIMARY KEY CLUSTERED ([id_ppv] ASC);
GO

-- Creating primary key on [id_ppv] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [PK_PPV_Fail]
    PRIMARY KEY CLUSTERED ([id_ppv] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id_user] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id_user] ASC);
GO

-- Creating primary key on [id_vendor] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [PK_Vendors]
    PRIMARY KEY CLUSTERED ([id_vendor] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [client] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK_PPV_Client]
    FOREIGN KEY ([client])
    REFERENCES [dbo].[Clients]
        ([id_client])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Client'
CREATE INDEX [IX_FK_PPV_Client]
ON [dbo].[PPVs]
    ([client]);
GO

-- Creating foreign key on [client] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK_PPV_Fail_Client]
    FOREIGN KEY ([client])
    REFERENCES [dbo].[Clients]
        ([id_client])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Fail_Client'
CREATE INDEX [IX_FK_PPV_Fail_Client]
ON [dbo].[PPV_Fail]
    ([client]);
GO

-- Creating foreign key on [id_level] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [FK__users__id_level__1273C1CD]
    FOREIGN KEY ([id_level])
    REFERENCES [dbo].[levels]
        ([id_level])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__users__id_level__1273C1CD'
CREATE INDEX [IX_FK__users__id_level__1273C1CD]
ON [dbo].[users]
    ([id_level]);
GO

-- Creating foreign key on [id_mfg] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK_PPV_Fail_MFG]
    FOREIGN KEY ([id_mfg])
    REFERENCES [dbo].[MFGs]
        ([id_mfg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Fail_MFG'
CREATE INDEX [IX_FK_PPV_Fail_MFG]
ON [dbo].[PPV_Fail]
    ([id_mfg]);
GO

-- Creating foreign key on [id_mfg] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK_PPV_MFG]
    FOREIGN KEY ([id_mfg])
    REFERENCES [dbo].[MFGs]
        ([id_mfg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_MFG'
CREATE INDEX [IX_FK_PPV_MFG]
ON [dbo].[PPVs]
    ([id_mfg]);
GO

-- Creating foreign key on [pn] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK_PPV_Fail_PN]
    FOREIGN KEY ([pn])
    REFERENCES [dbo].[PNs]
        ([id_pn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Fail_PN'
CREATE INDEX [IX_FK_PPV_Fail_PN]
ON [dbo].[PPV_Fail]
    ([pn]);
GO

-- Creating foreign key on [pn] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK_PPV_PN]
    FOREIGN KEY ([pn])
    REFERENCES [dbo].[PNs]
        ([id_pn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_PN'
CREATE INDEX [IX_FK_PPV_PN]
ON [dbo].[PPVs]
    ([pn]);
GO

-- Creating foreign key on [buyer] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK__PPV__buyer__49C3F6B7]
    FOREIGN KEY ([buyer])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV__buyer__49C3F6B7'
CREATE INDEX [IX_FK__PPV__buyer__49C3F6B7]
ON [dbo].[PPVs]
    ([buyer]);
GO

-- Creating foreign key on [first_auth] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK__PPV__first_auth__4AB81AF0]
    FOREIGN KEY ([first_auth])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV__first_auth__4AB81AF0'
CREATE INDEX [IX_FK__PPV__first_auth__4AB81AF0]
ON [dbo].[PPVs]
    ([first_auth]);
GO

-- Creating foreign key on [last_auth] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK__PPV__last_auth__4BAC3F29]
    FOREIGN KEY ([last_auth])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV__last_auth__4BAC3F29'
CREATE INDEX [IX_FK__PPV__last_auth__4BAC3F29]
ON [dbo].[PPVs]
    ([last_auth]);
GO

-- Creating foreign key on [vendor] in table 'PPVs'
ALTER TABLE [dbo].[PPVs]
ADD CONSTRAINT [FK_PPV_Vendor]
    FOREIGN KEY ([vendor])
    REFERENCES [dbo].[Vendors]
        ([id_vendor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Vendor'
CREATE INDEX [IX_FK_PPV_Vendor]
ON [dbo].[PPVs]
    ([vendor]);
GO

-- Creating foreign key on [buyer] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK__PPV_Fail__buyer__29221CFB]
    FOREIGN KEY ([buyer])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV_Fail__buyer__29221CFB'
CREATE INDEX [IX_FK__PPV_Fail__buyer__29221CFB]
ON [dbo].[PPV_Fail]
    ([buyer]);
GO

-- Creating foreign key on [first_auth] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK__PPV_Fail__first___2A164134]
    FOREIGN KEY ([first_auth])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV_Fail__first___2A164134'
CREATE INDEX [IX_FK__PPV_Fail__first___2A164134]
ON [dbo].[PPV_Fail]
    ([first_auth]);
GO

-- Creating foreign key on [last_auth] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK__PPV_Fail__last_a__2B0A656D]
    FOREIGN KEY ([last_auth])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PPV_Fail__last_a__2B0A656D'
CREATE INDEX [IX_FK__PPV_Fail__last_a__2B0A656D]
ON [dbo].[PPV_Fail]
    ([last_auth]);
GO

-- Creating foreign key on [vendor] in table 'PPV_Fail'
ALTER TABLE [dbo].[PPV_Fail]
ADD CONSTRAINT [FK_PPV_Fail_Vendor]
    FOREIGN KEY ([vendor])
    REFERENCES [dbo].[Vendors]
        ([id_vendor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PPV_Fail_Vendor'
CREATE INDEX [IX_FK_PPV_Fail_Vendor]
ON [dbo].[PPV_Fail]
    ([vendor]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------