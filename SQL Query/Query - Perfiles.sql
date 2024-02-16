

CREATE DATABASE DB_PERFILES;
GO

USE DB_PERFILES;
GO

CREATE TABLE DEPARTMENT(
	id INTEGER IDENTITY PRIMARY KEY NOT NULL,
	name VARCHAR(35) NOT NULL,
	description VARCHAR(255) NOT NULL
);
GO

CREATE TABLE EMPLOYEES(
	id INTEGER IDENTITY PRIMARY KEY NOT NULL,
	names VARCHAR(255) NOT NULL,
	DPI VARCHAR(13) NOT NULL,
	birthDate DATE NOT NULL,
	gender CHAR NOT NULL,
	admission DATE NOT NULL,
	age INTEGER NOT NULL,
	homeAddress VARCHAR(255),
	NIT VARCHAR(255),
	department INTEGER NOT NULL,
	FOREIGN KEY (department) REFERENCES DEPARTMENT(id)
	
);
GO

-- ************** CRUD DEPARTMENT **************

-- CREATE
CREATE PROCEDURE SP_CreateDepartment
	@name VARCHAR(35),
	@description VARCHAR(255)
AS 
BEGIN
	INSERT INTO DEPARTMENT(name, description)
	VALUES(@name, @description)
END
GO

exec SP_CreateDepartment 'Contabilidad', 'Departamento de contabilidad'
GO

exec SP_CreateDepartment 'Publicidad', 'Departamento de publicidad'
GO

-- READ ALL
CREATE PROCEDURE SP_ReadDepartments
AS
BEGIN
	SELECT * FROM DEPARTMENT
END;

GO

exec SP_ReadDepartments;
GO

-- READ ONE
CREATE PROCEDURE SP_ReadOneDepartment
	@id INTEGER
AS
BEGIN
	SELECT * FROM DEPARTMENT d
	WHERE d.id = @id
END;
GO

exec SP_ReadOneDepartment 1;
GO

-- READ ONE BY NAME

CREATE PROCEDURE SP_ReadOneByName
	@name VARCHAR(35)
AS 
BEGIN 
	SELECT * FROM DEPARTMENT d
	WHERE d.name = @name
END;
GO

exec SP_ReadOneByName 'Contabilidad'

-- UPDATE 
CREATE PROCEDURE SP_UpdateDepartment
	@id INTEGER,
	@name VARCHAR(35),
	@description VARCHAR(255)
AS
BEGIN
	UPDATE DEPARTMENT SET 
		name = @name, 
		description = @description
	WHERE id = @id
END
GO

exec SP_UpdateDepartment 2, 'Finanzas', 'Departamento de finanzas'
GO

exec SP_ReadDepartments
GO

-- DELETE

CREATE PROCEDURE SP_DeleteDepartment
	@id INTEGER
AS
BEGIN
	DELETE FROM DEPARTMENT 
	WHERE id = @id
END
GO

exec SP_DeleteDepartment 2
GO

exec SP_ReadDepartments
GO

-- ************** CRUD EMPLOYEES **************

-- CREATE
CREATE PROCEDURE SP_CreateEmployee
	@names VARCHAR(255),
	@DPI VARCHAR(13),
	@birthDate DATE,
	@gender CHAR,
	@admission DATE,
	@age INTEGER,
	@homeAddress VARCHAR(255),
	@NIT VARCHAR(255),
	@department INTEGER
AS
BEGIN
	
	INSERT INTO EMPLOYEES(names, DPI, birthDate, gender, admission, age, homeAddress, NIT, department)
	VALUES(@names, @DPI, @birthDate, @gender, @admission, @age, @homeAddress, @NIT, @department)

END;
GO

exec SP_CreateEmployee 'Diego Morales', '3016692440101', '2004-06-14', 'M', '2023-12-20', '20', 'Guatemala zona 6', '301669244', 1;
GO

exec SP_CreateEmployee 'Tomas Saquic', '2016692440102', '2000-06-14', 'M', '2023-12-20', '24', 'Guatemala zona 6', '201669242', 1;
GO

-- READ ALL

CREATE PROCEDURE SP_ReadEmployees
AS
BEGIN
	SELECT * FROM EMPLOYEES
END;

GO

exec SP_ReadEmployees

GO

-- READ ALL BY DEPARTMENT
CREATE PROCEDURE SP_ReadEmployeesByDepartment
	@idDepartment INTEGER
AS 
SELECT e.id, e.names, e.dpi, e.birthDate, e.gender, e.admission, e.age, e.homeAddress, e.NIT, 
		d.id as idDepartament, d.name as departmentName, d.description as departmentDescription
FROM EMPLOYEES e
INNER JOIN DEPARTMENT d on d.id = e.department
WHERE d.id = @idDepartment;
GO

exec SP_ReadEmployeesByDepartment 1

-- READ ONE

CREATE PROCEDURE SP_ReadOneEmployee
	@id INTEGER
AS
BEGIN
	SELECT e.id, e.names, e.dpi, e.birthDate, e.gender, e.admission, e.age, e.homeAddress, e.NIT, 
		d.id as idDepartament, d.name as departmentName, d.description as departmentDescription
	FROM EMPLOYEES e
	INNER JOIN DEPARTMENT d on d.id = e.department
	WHERE e.id = @id

END;
GO

exec SP_ReadOneEmployee 2
GO

-- UPDATE
CREATE PROCEDURE SP_UpdateEmployee
	@id INTEGER,
	@names VARCHAR(255),
	@DPI VARCHAR(13),
	@birthDate DATE,
	@gender CHAR,
	@admission DATE,
	@age INTEGER,
	@homeAddress VARCHAR(255),
	@NIT VARCHAR(255),
	@department INTEGER
AS
BEGIN
	
	UPDATE EMPLOYEES 
		SET names = @names,
		DPI = @DPI, 
		birthDate = @birthDate, 
		gender = @gender, 
		admission = @admission,
		age = @age, 
		homeAddress = @homeAddress, 
		NIT = @NIT, 
		department = @department
	WHERE id = @id

END;
GO

exec SP_UpdateEmployee 1, 'Diego Saquic', '3016692440101', '2004-06-14', 'M', '2024-12-20', '20', 'Guatemala zona 6', '301669244', 1;
GO

exec SP_ReadEmployees;
GO

-- DELETE 
CREATE PROCEDURE SP_DeleteEmployee
	@id INTEGER
AS
BEGIN
	DELETE FROM EMPLOYEES
	WHERE id = @id
END;
GO

exec SP_DeleteEmployee 1;
GO

exec SP_ReadEmployees;
GO

-- ************** Inner Join  

-- View Employes with all department information

CREATE VIEW viewEmployeesAndDepartment
AS 
SELECT e.id, e.names, e.dpi, e.birthDate, e.gender, e.admission, e.age, e.homeAddress, e.NIT, 
		d.id as idDepartament, d.name as departmentName, d.description as departmentDescription
FROM EMPLOYEES e
INNER JOIN DEPARTMENT d on d.id = e.department;
GO

SELECT * FROM viewEmployeesAndDepartment;
GO