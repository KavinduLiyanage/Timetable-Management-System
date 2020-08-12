USE [TimetableManageSystemDB]
GO

/****** Object: Table [dbo].[Persons] Script Date: 11/08/2020 21:12:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons] (
    [PersonID]  INT           NULL,
    [LastName]  VARCHAR (255) NULL,
    [FirstName] VARCHAR (255) NULL,
    [Address]   VARCHAR (255) NULL,
    [City]      VARCHAR (255) NULL
);


select * from Persons