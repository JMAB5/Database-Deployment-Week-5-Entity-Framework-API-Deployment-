CREATE TABLE [dbo].[tblStudents]
(
	[StudentID] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(30) NULL, 
    [Surname] NCHAR(30) NULL, 
    [Email] NCHAR(30) NULL, 
    [Mobile] NCHAR(30) NULL,
	Constraint PK_tblStudents_StudentID Primary KEY (StudentID)

)
