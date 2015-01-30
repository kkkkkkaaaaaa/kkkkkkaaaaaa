CREATE TABLE [dbo].[Memberships] (
    [ID]   BIGINT          NOT NULL IDENTITY(1, 1),
    [Name]     NVARCHAR (1024) NOT NULL,
    [Password] NVARCHAR (128)  NOT NULL,
    [Enabled]  BIT             NOT NULL ,
    [CreatedOn] DATETIME2 NOT NULL , 
    [UpdatedOn] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_Memberships] PRIMARY KEY ([ID]), 
    CONSTRAINT [CK_Memberships_ID] CHECK (0 < [ID]), 
    CONSTRAINT [AK_Memberships_Name] UNIQUE ([Name]) 
);
GO

CREATE INDEX [IX_Memberships_Name] ON [dbo].[Memberships] ([Name])

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'あ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Memberships',
    @level2type = N'COLUMN',
    @level2name = N'ID'