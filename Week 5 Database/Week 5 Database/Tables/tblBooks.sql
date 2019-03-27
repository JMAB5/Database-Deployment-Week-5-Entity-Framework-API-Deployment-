CREATE TABLE [dbo].[tblBooks]
(
	[AuthorID] INT NOT NULL PRIMARY KEY, 
    [AuthorFirstName] NCHAR(30) NULL, 
    [AuthorLastName] NCHAR(30) NULL, 
    [AuthorTFN] NCHAR(30) NULL,
	Constraint PK_tblBooks Primary Key (AuthorID, AuthorFirstName, AuthorLastName, AuthorTFN) 
)
