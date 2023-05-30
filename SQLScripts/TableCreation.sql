CREATE TABLE Counterparts(
	id INT IDENTITY(1,1),
	Name VARCHAR(64),
	PRIMARY KEY (id)
	)

CREATE TABLE Areas(
	id INT IDENTITY(1,1),
	name VARCHAR(64),
	PRIMARY KEY (id)
	)

CREATE TABLE AssetTypes(
	id INT IDENTITY(1,1),
	name VARCHAR(64),
	PRIMARY KEY (id)
	)

CREATE TABLE TechnologyTypes(
	id INT IDENTITY(1,1),
	name VARCHAR(64),
	PRIMARY KEY (id)
	)

CREATE TABLE States(
	id INT IDENTITY(1,1),
	name VARCHAR(64),
	PRIMARY KEY (id)
	)

CREATE TABLE Assets(
	id INT IDENTITY(1,1),
	name VARCHAR(64),
	notes VARCHAR(64),
	capacity DECIMAL(18,1),
	longitude DECIMAL(18,7),
	latitude DECIMAL(18,7),
	contractStart DATE,
	contractEnd DATE,
	approvedBy varchar(64),
	approvedAt DATETIME,
	modifiedBy VARCHAR(64),
	modifiedAt DATETIME,
	PRIMARY KEY (id),
	fk_Counterpart_ID INT FOREIGN KEY REFERENCES Counterparts(id),
	fk_Area_ID INT FOREIGN KEY REFERENCES Areas(id),
	fk_AssetType_ID INT FOREIGN KEY REFERENCES AssetTypes(id),
	fk_TechnologyType_ID INT FOREIGN KEY REFERENCES TechnologyTypes(id),
	fk_State_ID INT FOREIGN KEY REFERENCES States(id)
	)