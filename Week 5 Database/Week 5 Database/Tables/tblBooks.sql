CREATE TABLE [dbo].[tblBooks]
(
	[ISBN] NVARCHAR(17) NOT NULL PRIMARY KEY, 
    [Title] NCHAR(100) NULL, 
    [YearPublished] INT NULL, 
    [AuthorID] NVARCHAR(5) NULL, 
    [AuthorFirstName] NVARCHAR(10) NULL, 
    [AuthorLastName] NVARCHAR(10) NULL, 
    [AuthorTFN] NVARCHAR(11) NULL
)


