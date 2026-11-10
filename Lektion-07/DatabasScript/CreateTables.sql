-- DELETE ALL TABLES IF EXISTS...
DROP TABLE IF EXISTS productcategories;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS suppliers;
DROP TABLE IF EXISTS orderitems;
DROP TABLE IF EXISTS salesorder;
DROP TABLE IF EXISTS customeraddresses;
DROP TABLE IF EXISTS addresstypes;
DROP TABLE IF EXISTS cities;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS addresses;
DROP TABLE IF EXISTS postalcodes;
DROP TABLE IF EXISTS salesorder;

-- Address tables...
CREATE TABLE cities(
    id SERIAL PRIMARY KEY,
    city VARCHAR(20) NOT NULL
);
CREATE TABLE postalcodes(
    id SERIAL PRIMARY KEY,
    postalcode CHAR(5) NOT NULL,
    city_id INTEGER NOT NULL,
    CONSTRAINT fk_city FOREIGN KEY(city_id) REFERENCES cities(id)
);
CREATE TABLE addresses(
    id SERIAL PRIMARY KEY,
    addressline VARCHAR(80) NOT NULL,
    postalcode_id INTEGER NOT NULL,
    CONSTRAINT fk_postalcode FOREIGN KEY(postalcode_id) REFERENCES postalcodes(id)
);
CREATE TABLE addresstypes(
    id SERIAL PRIMARY KEY,
    name VARCHAR(20) NOT NULL
)

-- Customers tables...
CREATE TABLE customers(
    id SERIAL PRIMARY KEY,
    firstname VARCHAR(20) NOT NULL,
    lastname VARCHAR(30) NOT NULL,
    email VARCHAR(128) NOT NULL,
    phone VARCHAR(15) NULL
);

CREATE TABLE customeraddresses(
    customer_id INTEGER NOT NULL,
    address_id INTEGER NOT NULL,
    addresstype_id INTEGER NOT NULL,
    CONSTRAINT pk_custaddr PRIMARY KEY(customer_id,address_id,addresstype_id),
    CONSTRAINT fk_customer FOREIGN KEY(customer_id) REFERENCES customers(id),
    CONSTRAINT fk_address FOREIGN KEY(address_id) REFERENCES addresses(id),
    CONSTRAINT fk_addresstype FOREIGN KEY(addresstype_id) REFERENCES addresstypes(id)
);

-- Supplier table...
CREATE TABLE suppliers(
    id SERIAL PRIMARY KEY,
    name VARCHAR(40) NOT NULL
);

-- Products table...
CREATE TABLE productcategories(
    id SERIAL PRIMARY KEY,
    name VARCHAR(60) NOT NULL
);
CREATE TABLE products(
    id SERIAL PRIMARY KEY,
    itemnumber VARCHAR(10) NOT NULL,
    name VARCHAR(80) NOT NULL,
    description VARCHAR(1024) NULL,
    imageurl VARCHAR(256) NULL,
    price FLOAT NOT NULL,
    supplier_id INTEGER NOT NULL,
    category_id INTEGER NOT NULL,
    CONSTRAINT fk_supplier FOREIGN KEY(supplier_id) REFERENCES suppliers(id),
    CONSTRAINT fk_category FOREIGN KEY(category_id) REFERENCES productcategories(id)
);

-- SalesOrders tables...
CREATE TABLE salesorder(
    id SERIAL PRIMARY KEY,
    ordernumber UUID NOT NULL DEFAULT uuidv4(),
    orderdate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    customer_id INTEGER NOT NULL,
    CONSTRAINT fk_customer FOREIGN KEY(customer_id) REFERENCES customers(id)
);

CREATE TABLE orderitems(
    order_id INTEGER NOT NULL,
    product_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    price INTEGER NOT NULL,
    discount FLOAT NULL,
    CONSTRAINT pk_orderitems PRIMARY KEY(order_id,product_id),
    CONSTRAINT fk_order FOREIGN KEY(order_id) REFERENCES salesorder(id),
    CONSTRAINT fk_product FOREIGN KEY(product_id) REFERENCES products(id)
);