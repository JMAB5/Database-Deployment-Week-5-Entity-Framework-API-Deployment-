CREATE TABLE [dbo].[tblStudents]
(
	[StudentID] NVARCHAR(9) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(20) NULL, 
    [Surname] NVARCHAR(20) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Mobile] NVARCHAR(20) NULL
)
