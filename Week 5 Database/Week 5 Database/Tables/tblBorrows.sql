CREATE TABLE [dbo].[tblBorrows]
(
    [BorrowID] INT IDENTITY (1,1) NOT NULL, 
    [StudentID] NVARCHAR(10) NOT NULL, 
    [ISBN] NVARCHAR(17) NOT NULL, 
	[DateDue] DATE NULL,
    CONSTRAINT [FK_tblBorrows_ToTblBooks] FOREIGN KEY ([ISBN]) REFERENCES [tblBooks]([ISBN]), 
    CONSTRAINT [FK_tblBorrows_ToTblStudents] FOREIGN KEY ([StudentID]) REFERENCES [tblStudents]([StudentID]), 
    CONSTRAINT [PK_tblBorrows] PRIMARY KEY ([BorrowID]), 
    )