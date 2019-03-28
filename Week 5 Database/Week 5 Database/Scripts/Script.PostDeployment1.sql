/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'

Begin

--Ensure There is no Data in the Tables Before Deploying Test Data
DELETE FROM tblStudents; 
DELETE FROM tblBorrows;
DELETE FROM tblBooks;

--Insert the Test Data
INSERT INTO tblStudents (StudentID, FirstName, Surname, Email, Mobile) VALUES
('s12345678', 'Fred', 'Flinstone', '12345678@student.swin.edu.au', '0400 555 111'),
('s23456789', 'Barney', 'Rubble', '23456789@student.swin.edu.au', '0400 555 222'),
('s34567890', 'Bam-Bam', 'Rubble', '34567890@student.swin.edu.au', '0400 555 333');

INSERT INTO tblBorrows (TitleID, ISBN, YearPublished) VALUES
('978-3-16148410-0 ', 'Relationships with Databases, the ins and outs', '1970'),
('978-3-16148410-1 ', 'Normalisation, how to make a database geek fit in.', '1973'),
('978-3-16148410-2 ', 'TCP/IP, the protocol for the masses.', '1983'),
('978-3-16148410-3 ', 'The Man, the Bombe, and the Enigma.', '1940');

INSERT INTO tblBooks (AuthorID, AuthorFirstName, AuthorLastName, AuthorTFN) VALUES
('32567', 'Edgar','Codd', '150 111 222'),
('32567', 'Edgar','Codd', '150 111 222'),
('76543', 'Vinton ','Cerf', '150 222 333'),
('12345', 'Alan','Turning', '150 333 444');

END;



