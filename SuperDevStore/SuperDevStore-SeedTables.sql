INSERT INTO admins(name, email, password) VALUES('Gonçalo Rodrigues', 'rodriguesgonalo604@gmail.com', HASHBYTES('SHA2_512', '1q2w3e4R'))

INSERT INTO users(name, email, password) VALUES('Gonçalo Rodrigues', 'rodriguesgonalo604@gmail.com', HASHBYTES('SHA2_512', '1q2w3e4R'))

INSERT INTO shipping_methods(name) VALUES('DHL Express')

INSERT INTO orders(user_id, date, shipping_address, shipping_method_id) VALUES(1, GETDATE(), 'Home', 1)