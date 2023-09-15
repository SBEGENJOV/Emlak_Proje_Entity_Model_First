
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2023 11:17:42
-- Generated from EDMX file: C:\Users\S_BEGENJOV\Desktop\wissen\Consol\ev_calısma\modalfirst_ornek\modalfirst_ornek\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [realEstate];
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

-- Creating table 'plotSet'
CREATE TABLE [dbo].[plotSet] (
    [plotID] int IDENTITY(1,1) NOT NULL,
    [plotName] nvarchar(max)  NOT NULL,
    [plotAdres] nvarchar(max)  NOT NULL,
    [plotPrice] int  NOT NULL,
    [plotM2] int  NOT NULL,
    [customer_customerID] int  NOT NULL
);
GO

-- Creating table 'homeSet'
CREATE TABLE [dbo].[homeSet] (
    [homeID] int IDENTITY(1,1) NOT NULL,
    [homeName] nvarchar(max)  NOT NULL,
    [homeAdres] nvarchar(max)  NOT NULL,
    [homePrice] int  NOT NULL,
    [homeM2] int  NOT NULL,
    [customer_customerID] int  NOT NULL
);
GO

-- Creating table 'customerSet'
CREATE TABLE [dbo].[customerSet] (
    [customerID] int IDENTITY(1,1) NOT NULL,
    [customerName] nvarchar(max)  NOT NULL,
    [customerAge] int  NOT NULL,
    [customerPhone] nvarchar(max)  NOT NULL,
    [customerPW] nvarchar(max)  NOT NULL,
    [employe_employeID] int  NOT NULL
);
GO

-- Creating table 'employeSet'
CREATE TABLE [dbo].[employeSet] (
    [employeID] int IDENTITY(1,1) NOT NULL,
    [employeName] nvarchar(max)  NOT NULL,
    [employeAge] int  NOT NULL,
    [employeWope] int  NOT NULL,
    [employePhone] nvarchar(max)  NOT NULL,
    [employePW] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [plotID] in table 'plotSet'
ALTER TABLE [dbo].[plotSet]
ADD CONSTRAINT [PK_plotSet]
    PRIMARY KEY CLUSTERED ([plotID] ASC);
GO

-- Creating primary key on [homeID] in table 'homeSet'
ALTER TABLE [dbo].[homeSet]
ADD CONSTRAINT [PK_homeSet]
    PRIMARY KEY CLUSTERED ([homeID] ASC);
GO

-- Creating primary key on [customerID] in table 'customerSet'
ALTER TABLE [dbo].[customerSet]
ADD CONSTRAINT [PK_customerSet]
    PRIMARY KEY CLUSTERED ([customerID] ASC);
GO

-- Creating primary key on [employeID] in table 'employeSet'
ALTER TABLE [dbo].[employeSet]
ADD CONSTRAINT [PK_employeSet]
    PRIMARY KEY CLUSTERED ([employeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [employe_employeID] in table 'customerSet'
ALTER TABLE [dbo].[customerSet]
ADD CONSTRAINT [FK_employecustomer]
    FOREIGN KEY ([employe_employeID])
    REFERENCES [dbo].[employeSet]
        ([employeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_employecustomer'
CREATE INDEX [IX_FK_employecustomer]
ON [dbo].[customerSet]
    ([employe_employeID]);
GO

-- Creating foreign key on [customer_customerID] in table 'homeSet'
ALTER TABLE [dbo].[homeSet]
ADD CONSTRAINT [FK_customerhome]
    FOREIGN KEY ([customer_customerID])
    REFERENCES [dbo].[customerSet]
        ([customerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_customerhome'
CREATE INDEX [IX_FK_customerhome]
ON [dbo].[homeSet]
    ([customer_customerID]);
GO

-- Creating foreign key on [customer_customerID] in table 'plotSet'
ALTER TABLE [dbo].[plotSet]
ADD CONSTRAINT [FK_customerplot]
    FOREIGN KEY ([customer_customerID])
    REFERENCES [dbo].[customerSet]
        ([customerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_customerplot'
CREATE INDEX [IX_FK_customerplot]
ON [dbo].[plotSet]
    ([customer_customerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------