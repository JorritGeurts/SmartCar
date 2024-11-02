-- Drop the damage table if it exists
DROP TABLE IF EXISTS damage;

-- Drop the smartcar database if it exists
DROP DATABASE IF EXISTS smartcar;

-- Create the database
CREATE DATABASE smartcar;

-- Use the created database
USE smartcar;

-- Create the damage table
CREATE TABLE damage (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    tag CHAR(50),
    damageType CHAR(50),
    severity CHAR(20)
);

-- Insert one record into the damage table
INSERT INTO damage (tag, damageType, severity) 
VALUES ('Scratched Paint', 'Cosmetic', 'Moderate');

