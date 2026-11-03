SELECT * FROM cities;
SELECT * FROM postalcodes;
SELECT * FROM addresses;
SELECT * FROM addresstypes;
SELECT * FROM customeraddresses;
SELECT * FROM customers;
SELECT * FROM productcategories;
SELECT * FROM products;
SELECT * FROM suppliers;

SELECT * FROM addresses INNER JOIN postalcodes 
    ON postalcode_id = postalcodes.id INNER JOIN cities
    ON city_id = cities.id;

SELECT
    firstname,
    lastname,
    email,
    addressline,
    postalcode,
    city,
    at.name AS address_type
FROM customers AS c INNER JOIN customeraddresses AS ca
    ON c.id = ca.customer_id INNER JOIN addresses AS a
    ON ca.address_id = a.id INNER JOIN postalcodes AS p
    ON a.postalcode_id = p.id INNER JOIN cities AS cty
    ON p.city_id = cty.id INNER JOIN addresstypes AS at
    ON ca.addresstype_id = at.id;

SELECT * FROM products INNER JOIN suppliers 
    ON supplier_id = suppliers.id INNER JOIN productcategories as pc
    ON category_id = pc.id;
SELECT * FROM addresstypes;

SELECT * FROM salesorder;
SELECT * FROM orderitems

SELECT 
    so.id,
    ordernumber,
    orderdate,
    firstname || ' ' || lastname AS customer,
    a.addressline || ' ' || pc.postalcode || ' ' || cty.city AS address,
    p.itemnumber,
    p.name,
    s.name,
    oi.quantity,
    oi.price,
    oi.discount,
    oi.quantity * oi.price AS linesum
FROM orderitems AS oi INNER JOIN salesorder as so
    ON oi.order_id = so.id INNER JOIN customers as c 
    ON so.customer_id = c.id INNER JOIN products as p 
    ON oi.product_id = p.id INNER JOIN customeraddresses as ca 
    ON c.id = ca.customer_id INNER JOIN addresses as a 
    ON ca.address_id = a.id INNER JOIN postalcodes as pc 
    ON a.postalcode_id = pc.id INNER JOIN cities as cty 
    ON pc.city_id = cty.id INNER JOIN suppliers as s
    ON p.supplier_id = s.id INNER JOIN addresstypes as at
    ON ca.addresstype_id = at.id
WHERE at.id = 2; 

SELECT 
    so.id,
    ordernumber,
    orderdate,
    firstname || ' ' || lastname AS customer,
    a.addressline || ' ' || pc.postalcode || ' ' || cty.city AS address,
    SUM(oi.quantity * oi.price) AS ordervalue
FROM orderitems AS oi INNER JOIN salesorder as so
    ON oi.order_id = so.id INNER JOIN customers as c 
    ON so.customer_id = c.id INNER JOIN products as p 
    ON oi.product_id = p.id INNER JOIN customeraddresses as ca 
    ON c.id = ca.customer_id INNER JOIN addresses as a 
    ON ca.address_id = a.id INNER JOIN postalcodes as pc 
    ON a.postalcode_id = pc.id INNER JOIN cities as cty 
    ON pc.city_id = cty.id INNER JOIN suppliers as s
    ON p.supplier_id = s.id INNER JOIN addresstypes as at
    ON ca.addresstype_id = at.id
GROUP BY so.id,ordernumber,orderdate, customer, address;

SELECT 
    so.id,
    ordernumber,
    orderdate,
    firstname, 
    lastname,
    email,
    a.addressline, 
    pc.postalcode,
    cty.city,
    SUM(oi.quantity * oi.price) AS ordervalue
FROM orderitems AS oi INNER JOIN salesorder as so
    ON oi.order_id = so.id INNER JOIN customers as c 
    ON so.customer_id = c.id INNER JOIN products as p 
    ON oi.product_id = p.id INNER JOIN customeraddresses as ca 
    ON c.id = ca.customer_id INNER JOIN addresses as a 
    ON ca.address_id = a.id INNER JOIN postalcodes as pc 
    ON a.postalcode_id = pc.id INNER JOIN cities as cty 
    ON pc.city_id = cty.id INNER JOIN suppliers as s
    ON p.supplier_id = s.id INNER JOIN addresstypes as at
    ON ca.addresstype_id = at.id
GROUP BY so.id,ordernumber,orderdate, firstname, lastname, email, addressline, postalcode, city;

SELECT order_id, quantity, price, quantity * price AS LineSum FROM orderitems;

SELECT
    order_id,
    orderdate,
    ordernumber,
    firstname,
    lastname,
    email,
    SUM(quantity * price) AS ordervalue
FROM salesorder AS s INNER JOIN orderitems as oi
    ON s.id = oi.order_id INNER JOIN customers AS c
    ON s.customer_id = c.id
GROUP BY order_id,orderdate,ordernumber,firstname,lastname,email;

SELECT AVG(price) FROM products;
SELECT MIN(price) FROM products;
SELECT MAX(price) FROM products;