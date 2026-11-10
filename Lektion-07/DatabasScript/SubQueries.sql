-- Simple SubQuery
SELECT
    order_id,
    product_id
FROM orderitems
WHERE price = (
    SELECT MAX(price) FROM orderitems
);

SELECT
    *
FROM orderitems
WHERE price > (
    SELECT CAST(AVG(price) AS INT) FROM orderitems
);

-- Convert to another type 
-- CAST => ANSI standard
-- :: Database specific
SELECT CAST(AVG(price) AS INTEGER) FROM orderitems;
SELECT AVG(price) :: INTEGER FROM orderitems

/* **************************************************** */

-- Correlated queries
-- 1. simple inner join
SELECT
    orderdate,
    ordernumber,
    customers.id,
    firstname,
    lastname,
    email
FROM salesorder INNER JOIN customers ON salesorder.customer_id = customers.id;

-- 2.
SELECT
    orderdate,
    customer_id
FROM salesorder AS o
WHERE EXISTS(
    SELECT * FROM customers AS c WHERE c.id = o.customer_id
);

-- Lista kunder som inte ännu lagt en beställning...
SELECT
    *
FROM customers AS c
WHERE NOT EXISTS(
    SELECT * FROM salesorder as o
    WHERE c.id = o.customer_id
);
