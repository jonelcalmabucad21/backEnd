-- "Server=(localdb)\\mssqllocaldb;Database=Quon;Trusted_Connection=True;MultipleActiveResultSets=true"
-- "Data Source=sql.freeasphost.net\MSSQL2016;Initial Catalog=planning214_SampleDB;Persist Security Info=True;User ID=planning214_SampleDB;Password=DBSamplePW" 
-- "workstation id=Quon214.mssql.somee.com;packet size=4096;user id=JonelBucad21_SQLLogin_1;pwd=d41qrrvf2x;data source=Quon214.mssql.somee.com;persist security info=False;initial catalog=Quon214"

SELECT * FROM SYS.tables;

SELECT * FROM SYS.Persons;
SELECT * FROM Employees;
SELECT * FROM Stations;
SELECT * FROM Positions;
SELECT * FROM Designations;
SELECT * FROM Advisers;
SELECT * FROM PrefectOfDisciplines;
SELECT * FROM Principals;
SELECT * FROM EmployeeStations;
SELECT * FROM SectionAdvisers;
SELECT * FROM LevelSections;
SELECT * FROM Levels;
SELECT * FROM Sections;

DELETE FROM Persons WHERE Id = 21;
INSERT INTO PErsons (FirstName,LastName,MiddleName) VALUES('Jhed','Bucad','C.');





DELETE FROM Persons WHERE Id = 7;

UPDATE Persons SET SuffixName = 'Jr.' WHERE Id = 8;

INSERT INTO Stations (Name,StationNumber) VALUES('Apalit ES',096);
INSERT INTO Positions (Name) VALUES('Administrative Assistant III');
INSERT INTO Designations (Name) VALUES('Principal');
INSERT INTO Levels (Name) VALUES('Grade 7');
INSERT INTO Sections (Name) VALUES('St. Joseph');
