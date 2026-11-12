SELECT * FROM products;

-- Begränsa antalet rader som returneras...
SELECT * FROM products ORDER BY price ASC LIMIT 1; -- ASCENDING
SELECT * FROM products ORDER BY price DESC LIMIT 1; -- ASCENDING

-- Wildcard sökningar...
SELECT * FROM products WHERE itemnumber = '1000'; -- = Exakt matchning
SELECT * FROM products WHERE name LIKE 'Sko%';
SELECT * FROM products WHERE name LIKE '%ko%1';
SELECT * FROM products WHERE name LIKE '_ko%2';

-- Kombinerade villkor
-- AND = både eller alla uttryck i WHERE måste returnera sant
SELECT * FROM products WHERE name LIKE '%2' AND price < 2000;

-- OR något av uttrycket behöver vara sant
SELECT * FROM products WHERE name LIKE '%2' OR price < 2000; 
SELECT * FROM products WHERE name LIKE '%2' OR price > 2000; 

SELECT * FROM products WHERE itemnumber = '1000' OR itemnumber = '1001';

-- Variant av flera OR villkor...
SELECT * FROM products WHERE itemnumber IN('1000','1001');

-- Range queries...
SELECT * FROM products WHERE price BETWEEN 1500 AND 2000;
SELECT * FROM products WHERE price >= 1500 AND price <= 2000;

-- Räkna ut varje orderrads summa
SELECT
    itemnumber,
    quantity,
    orderitems.price,
    products.price,
    quantity * orderitems.price AS linesum
FROM orderitems INNER JOIN products
    ON orderitems.product_id = products.id;

SELECT
    orderdate,
    SUM(quantity * orderitems.price) AS OrderValue
FROM salesorder INNER JOIN orderitems
    ON salesorder.id = orderitems.order_id
GROUP BY orderdate