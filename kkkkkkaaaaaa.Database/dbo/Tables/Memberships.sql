CREATE TABLE [dbo].[Memberships] (
    [UserID]   BIGINT          NOT NULL,
    [Name]     NVARCHAR (1024) NOT NULL,
    [Password] NVARCHAR (MAX)  NOT NULL,
    [Enabled]  BIT             NOT NULL,
    CONSTRAINT [PK_Authentications] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

