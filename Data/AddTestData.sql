INSERT INTO Customers(
    firstName,
    lastName,
    email,
    phone,
    address,
    postalcode,
    city
)VALUES(
    'Michael',
    'Gustavsson',
    'michael@gmail.com',
    '0702-223344',
    'Lövgatan 30',
    '44446',
    'Byn'
),(
    'Pernilla',
    'Oskarsson',
    'pernilla@gmail.com',
    '0730-88776',
    'Bergskanten 8',
    '33322',
    'Berget'
),(
    'Per',
    'Morberg',
    'per@gmail.com',
    '070-188776',
    'Kålfjärilsvägen 1',
    '43143',
    'Storstaden'
);

INSERT INTO suppliers(
    name
)VALUES(
    'Asics'
),(
    'Nike'
),(
    'Puma'
),(
    'CLN Athletics'
),(
    'Swix'
)

INSERT INTO Products(
    itemnumber,
    name,
    description,
    imageurl,
    price,
    supplier_id
)VALUES(
    '1000',
    'Core 2000',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556514/shoe-1_qig4ut.jpg',
    1295,
    1
),(
    '1001',
    'GEL 27',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg',
    2295,
    1
),(
    '1002',
    'Jacket',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556497/jacket-1_rio6db.jpg',
    1495,
    4
),(
    '1003',
    'Limited Running t-shirt',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556531/t-shirt-2_gg3ags.jpg',
    385,
    2
),(
    '1004',
    'Road Black t-shirt',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556532/t-shirt-3_uqcb6b.jpg',
    495,
    2
),(
    '1005',
    'Road White t-shirt',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556531/t-shirt-1_p55bwy.jpg',
    495,
    4
),(
    '1006',
    'Sonoma 7GTX',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556531/shoe-4_lrv51e.jpg',
    2295,
    2
),(
    '1007',
    'Trail 25',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-2_alelr0.jpg',
    1895,
    3
),(
    '1008',
    'Vest pro',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556547/vest-1_e4qwig.jpg',
    895,
    5
),(
    '1009',
    'Vest unisex',
    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',
    'https://res.cloudinary.com/softtech-dev/image/upload/v1786556463/vest-2_rcrjyf.jpg',
    995,
    5
);
