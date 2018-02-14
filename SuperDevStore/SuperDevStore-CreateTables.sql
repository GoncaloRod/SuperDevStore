CREATE TABLE [admins] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[email] VARCHAR(100) CHECK([email] LIKE '%@%.%') NOT NULL,
	[password] VARCHAR(100) NOT NULL,
	[active] BIT DEFAULT(1) NOT NULL,
)

CREATE TABLE [users] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[email] VARCHAR(100) CHECK([email] LIKE '%@%.%') UNIQUE NOT NULL,
	[password] VARCHAR(100) NOT NULL,
	[active] BIT DEFAULT(1) NOT NULL,
)

CREATE TABLE [products] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[price] MONEY NOT NULL,
	[description] TEXT NOT NULL,
	[stock] INT DEFAULT(0) NOT NULL,
	[active] BIT DEFAULT(1) NOT NULL,
)

CREATE TABLE [product_images] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[image] VARCHAR(100) NOT NULL,
	[active] BIT DEFAULT(1) NOT NULL,
	[product_id] INT REFERENCES [products]([id]),
)

CREATE TABLE [products_visits] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[product_id] INT REFERENCES [products]([id]) NOT NULL,
	[user_id] INT REFERENCES [users]([id]) NOT NULL,
)

CREATE TABLE [shipping_methods] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[active] BIT DEFAULT(1) NOT NULL,
)

CREATE TABLE [orders] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[user_id] INT REFERENCES [users]([id]) NOT NULL,
	[date] DATETIME	NOT NULL,
	[shipping_address] VARCHAR(100) NOT NULL,
	[done] BIT DEFAULT(0) NOT NULL,
	[shipping_method_id] INT REFERENCES [shipping_methods]([id]) NOT NULL,
)

CREATE TABLE [order_details] (
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[order_id] INT REFERENCES [orders]([id]) NOT NULL,
	[product_id] INT REFERENCES [products]([id]) NOT NULL,
	[quantity] INT NOT NULL,
	[unit_price] MONEY NOT NULL,
)