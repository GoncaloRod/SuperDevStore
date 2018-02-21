INSERT INTO admins(name, email, password) VALUES('Gonçalo Rodrigues', 'rodriguesgonalo604@gmail.com', HASHBYTES('SHA2_512', '1q2w3e4R'))

INSERT INTO users(name, email, password) VALUES('Gonçalo Rodrigues', 'rodriguesgonalo604@gmail.com', HASHBYTES('SHA2_512', '1q2w3e4R'))

INSERT INTO shipping_methods(name) VALUES('DHL Express')

INSERT INTO orders(user_id, date, shipping_address, shipping_method_id) VALUES(1, GETDATE(), 'Home', 1)

INSERT INTO products(name, price, description, stock) VALUES('Product 1', 10, 'Product 1', 50)

INSERT INTO products(name, price, description, stock) VALUES('Product 2', 10, 'Product 2', 10)

INSERT INTO products(name, price, description, stock) VALUES('Product 3', 10, 'Product 3', 3)

INSERT INTO products(name, price, description, stock) VALUES('Product 4', 10, 'Product 4', 0)

INSERT INTO order_details(order_id, product_id, quantity, unit_price) VALUES(2, 1, 1, 10)

INSERT INTO order_details(order_id, product_id, quantity, unit_price) VALUES(2, 2, 2, 10)