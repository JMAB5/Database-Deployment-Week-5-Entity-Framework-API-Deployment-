CREATE TABLE [dbo].[tblBorrows]
(
	[StudentID] INT NOT NULL PRIMARY KEY, 
    [ISBN] NVARCHAR(30) NULL, 
	Constraint PK_tblBorrows PRIMARY KEY (StudentID),
	Constraint FK_tblBorrows_Student FOREIGN KEY (StudentID) REFERENCES tblStudents(StudentID),
	Constraint FK_tblBorrows_Books FOREIGN KEY (ISBN) REFERENCES Books(tblAuthorID),
	)