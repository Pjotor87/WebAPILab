USE [master]
GO

IF EXISTS(select * from sys.databases where name='WebAPILab')
DROP DATABASE WebAPILab
GO

CREATE DATABASE WebAPILab;
GO

USE [WebAPILab]
GO

CREATE TABLE Customers (
    [Id] [int] NOT NULL IDENTITY,
    [CustomerId] [int] NOT NULL,
    [CustomerName] [nvarchar](30),
    [CustomerEmail] [nvarchar](25),
    [MobileNo] [float] NOT NULL,
    [TransactionIds] [nvarchar](max),
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE Transactions (
    [Id] [int] NOT NULL IDENTITY,
    [TransactionId] [int] NOT NULL,
    [TransactionDateTime] [datetime] NOT NULL,
    [Amount] [float] NOT NULL,
    [CurrencyCode] [nvarchar](3),
    [Status] [int] NOT NULL,
    [Customer_Id] [int],
    CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Customer_Id] ON [dbo].[Transactions]([Customer_Id])
GO

ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [FK_dbo.Transactions_dbo.Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([Id])
GO