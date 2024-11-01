PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Address 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    country VARCHAR(30) NOT NULL, 
    city VARCHAR(30) NOT NULL, 
    postal_code VARCHAR(30) NOT NULL, 
    street VARCHAR(30), 
    building_number VARCHAR(30), 
    Vendor_id INTEGER NOT NULL, 
    Customer_id INTEGER NOT NULL, 
    Employee_id INTEGER NOT NULL,
    FOREIGN KEY (Customer_id) REFERENCES Customer (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Employee_id) REFERENCES Employee (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Vendor_id) REFERENCES Vendor (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS Customer 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    name VARCHAR(80) NOT NULL, 
    phone_number VARCHAR(15) NOT NULL, 
    mail VARCHAR(50) NOT NULL, 
    nip VARCHAR(15)  -- Allows leading zeros
);

CREATE TABLE IF NOT EXISTS Employee 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    name VARCHAR(50) NOT NULL, 
    surname VARCHAR(50) NOT NULL, 
    pesel VARCHAR(20) NOT NULL, 
    phone_number VARCHAR(15) NOT NULL,
    login VARCHAR(30) NOT NULL,  -- Login field
    password VARCHAR(30) NOT NULL,  -- Password field
    account_type CHAR(1) NOT NULL CHECK (account_type IN ('a', 'm', 'e'))  -- Account type
);

CREATE TABLE IF NOT EXISTS Invoice 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    status INTEGER NOT NULL,  -- Using INTEGER as SQLite does not have BIT
    invoice_date DATETIME NOT NULL, 
    total_amount NUMERIC NOT NULL
);

CREATE TABLE IF NOT EXISTS Orders  -- Avoiding reserved keyword
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    status INTEGER NOT NULL,  -- Using INTEGER for BIT equivalent
    date DATETIME NOT NULL, 
    Customer_id INTEGER NOT NULL, 
    Invoice_id INTEGER NOT NULL,
    FOREIGN KEY (Customer_id) REFERENCES Customer (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Invoice_id) REFERENCES Invoice (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS Product 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    name VARCHAR(30) NOT NULL, 
    sku INTEGER NOT NULL, 
    category VARCHAR(50) NOT NULL, 
    net_price NUMERIC NOT NULL, 
    vat NUMERIC NOT NULL, 
    stock INTEGER NOT NULL, 
    Vendor_id INTEGER NOT NULL,
    FOREIGN KEY (Vendor_id) REFERENCES Vendor (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS ProductList  -- Renamed for consistency
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    Product_id INTEGER NOT NULL, 
    Order_id INTEGER NOT NULL, 
    quantity INTEGER NOT NULL, 
    unit_price NUMERIC NOT NULL, 
    total_price NUMERIC NOT NULL,
    FOREIGN KEY (Order_id) REFERENCES Orders (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Product_id) REFERENCES Product (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS Vendor 
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Automatically incrementing ID
    name VARCHAR(50) NOT NULL, 
    phone_number VARCHAR(15), 
    mail VARCHAR(50), 
    nip VARCHAR(15)  -- Allows leading zeros
);
