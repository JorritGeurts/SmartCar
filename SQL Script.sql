-- Drop the damage table if it exists
DROP TABLE IF EXISTS carSeverity;
DROP TABLE IF EXISTS car;
DROP TABLE IF EXISTS severity;
Drop Table if exists damage;

-- Drop the smartcar database if it exists
DROP DATABASE IF EXISTS smartcar;

-- Create the database
CREATE DATABASE smartcar;

-- Use the created database
USE smartcar;

-- Create the damage table
CREATE TABLE car (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    tag CHAR(50),
	oldPrice int,
    newPrice int,
    Photo char(255)
);

CREATE TABLE severity(
	Id int auto_increment Primary Key,
    name char(50),
    amount double);
    
CREATE TABLE damage(
	Id int auto_increment Primary Key,
    name char(50));
    
CREATE TABLE carSeverity (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    carId INT,
    severityId INT,
    damageId INT,
    FOREIGN KEY (carId) REFERENCES car(Id),
    FOREIGN KEY (severityId) REFERENCES severity(Id),
    FOREIGN KEY (damageId) REFERENCES damage(Id)
);

-- Insert data
Insert Into car (tag, oldPrice, newPrice, photo)
values("A1", 19000, 18000, "Foto van de Wezel in een zwembroek");

INSERT INTO severity (name, amount) 
VALUES ('Minor', '0.95'), ('Moderate', '0.90'), ('Severe', '0.85'), ('Critical', '0.80');

INSERT INTO damage (name) 
VALUES ('Scratch'), ('Dent'), ('Crack');

Insert Into carSeverity (carId, severityId, damageId)
Values (1, 1, 1);


