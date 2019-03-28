CREATE TABLE [dbo].[tblBorrows]
(
	[TitleID] INT NOT NULL PRIMARY KEY, 
    [ISBN] NVARCHAR(30) NULL, 
	[YearPublished] NCHAR(30) NULL, 
    Constraint PK_tblBorrows PRIMARY KEY ([TitleID]),
	Constraint FK_tblBorrows_Student FOREIGN KEY ([TitleID]) REFERENCES tblStudents(StudentID),
	)