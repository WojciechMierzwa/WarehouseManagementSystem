-- Enabling foreign keys
PRAGMA foreign_keys = ON;

CREATE TABLE Address (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    country TEXT NOT NULL, 
    city TEXT NOT NULL, 
    postal_code TEXT NOT NULL, 
    street TEXT, 
    building_number TEXT, 
    Vendor_id INTEGER NOT NULL, 
    Customer_id INTEGER NOT NULL, 
    Employee_id INTEGER NOT NULL
);

CREATE TABLE Customer (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    name TEXT NOT NULL, 
    phone_number TEXT NOT NULL, 
    mail TEXT NOT NULL, 
    nip TEXT
);

CREATE TABLE Employee (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    name TEXT NOT NULL, 
    surname TEXT NOT NULL, 
    pesel TEXT NOT NULL, 
    phone_number TEXT NOT NULL,
    login TEXT NOT NULL,  
    password TEXT NOT NULL,  
    account_type TEXT NOT NULL CHECK (account_type IN ('a', 'm', 'e'))  -- Account type constraint
);

CREATE TABLE Invoice (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    status INTEGER NOT NULL,               -- BIT equivalent; use 0 or 1
    invoice_date TEXT NOT NULL,            -- Use TEXT to store date in ISO format (YYYY-MM-DD)
    total_amount REAL NOT NULL             -- MONEY equivalent
);

CREATE TABLE Orders (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    status INTEGER NOT NULL,               -- BIT equivalent; use 0 or 1
    date TEXT NOT NULL,                    -- Use TEXT for date in ISO format
    Customer_id INTEGER NOT NULL, 
    Invoice_id INTEGER NOT NULL
);

CREATE TABLE Product (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    name TEXT NOT NULL, 
    sku INTEGER NOT NULL, 
    category TEXT NOT NULL, 
    net_price REAL NOT NULL,               -- MONEY equivalent
    vat REAL NOT NULL, 
    stock INTEGER NOT NULL, 
    Vendor_id INTEGER NOT NULL
);

CREATE TABLE ProductList (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    Product_id INTEGER NOT NULL, 
    Order_id INTEGER NOT NULL, 
    quantity INTEGER NOT NULL, 
    unit_price REAL NOT NULL, 
    total_price REAL NOT NULL
);

CREATE TABLE Vendor (
    id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-incrementing primary key
    name TEXT NOT NULL, 
    phone_number TEXT, 
    mail TEXT, 
    nip TEXT
);

-- Adding Foreign Key Constraints

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Customer FOREIGN KEY (Customer_id) 
REFERENCES Customer (id) 
ON DELETE NO ACTION;

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Employee FOREIGN KEY (Employee_id) 
REFERENCES Employee (id) 
ON DELETE NO ACTION;

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Vendor FOREIGN KEY (Vendor_id) 
REFERENCES Vendor (id) 
ON DELETE NO ACTION;

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Customer FOREIGN KEY (Customer_id) 
REFERENCES Customer (id) 
ON DELETE NO ACTION;

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Invoice FOREIGN KEY (Invoice_id) 
REFERENCES Invoice (id) 
ON DELETE NO ACTION;

ALTER TABLE ProductList 
ADD CONSTRAINT FK_ProductList_Order FOREIGN KEY (Order_id) 
REFERENCES Orders (id) 
ON DELETE NO ACTION;

ALTER TABLE ProductList 
ADD CONSTRAINT FK_ProductList_Product FOREIGN KEY (Product_id) 
REFERENCES Product (id) 
ON DELETE NO ACTION;

ALTER TABLE Product 
ADD CONSTRAINT FK_Product_Vendor FOREIGN KEY (Vendor_id) 
REFERENCES Vendor (id) 
ON DELETE NO ACTION;
