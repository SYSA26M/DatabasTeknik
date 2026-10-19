SELECT * FROM Customers;

SELECT firstName,lastName FROM Customers;

SELECT firstName,lastName FROM Customers
WHERE id = 2;

-- UPDATE...
UPDATE Customers SET firstName = 'Olle';

UPDATE Customers SET firstName = 'Eva'
WHERE id = 2;

UPDATE Customers SET Email = 'eva@mail.com'
WHERE id = 2;

DELETE FROM Customers WHERE id = 1;