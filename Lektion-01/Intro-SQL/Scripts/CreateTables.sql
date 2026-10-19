-- SQLite
CREATE TABLE Customers(
    id INTEGER PRIMARY KEY,
    firstName VARCHAR(20),
    lastName VARCHAR(30)
);
/*

*/
ALTER TABLE Customers ADD COLUMN Email VARCHAR(128);

-- DROP TABLE Customers;

-- ALTER TABLE Customers
-- ALTER COLUMN firstName VARCHAR(20) NOT NULL;

ALTER TABLE Customers
ADD CONSTRAINT UC_Email UNIQUE(Email);