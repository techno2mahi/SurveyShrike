﻿CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [FirstName]            NVARCHAR (MAX) NULL,
    [LastName]             NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [MobileNo]             NVARCHAR (MAX) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [AddressLine1]         NVARCHAR (255) NULL,
    [AddressLine2]         NVARCHAR (255) NULL,
    [CityId]               INT            NULL,
    [AreaId]               NVARCHAR (255) NULL,
    [PinCode]              INT            NULL,
    [CreatedDate]          DATETIME       NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

