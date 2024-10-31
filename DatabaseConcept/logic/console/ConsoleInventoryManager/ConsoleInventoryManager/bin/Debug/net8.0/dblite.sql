-- Enabling foreign keys
PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Vendor (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL, 
    phone_number TEXT, 
    mail TEXT, 
    nip TEXT
);

CREATE TABLE IF NOT EXISTS Customer (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL, 
    phone_number TEXT NOT NULL, 
    mail TEXT NOT NULL, 
    nip TEXT
);

CREATE TABLE IF NOT EXISTS Employee (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL, 
    surname TEXT NOT NULL, 
    pesel TEXT NOT NULL, 
    phone_number TEXT NOT NULL,
    login TEXT NOT NULL,  
    password TEXT NOT NULL,  
    account_type TEXT NOT NULL CHECK (account_type IN ('a', 'm', 'e'))
);

CREATE TABLE IF NOT EXISTS Invoice (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    status INTEGER NOT NULL,
    invoice_date TEXT NOT NULL,
    total_amount REAL NOT NULL
);

CREATE TABLE IF NOT EXISTS Address (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    country TEXT NOT NULL, 
    city TEXT NOT NULL, 
    postal_code TEXT NOT NULL, 
    street TEXT, 
    building_number TEXT, 
    Vendor_id INTEGER NOT NULL REFERENCES Vendor(id) ON DELETE NO ACTION,
    Customer_id INTEGER NOT NULL REFERENCES Customer(id) ON DELETE NO ACTION, 
    Employee_id INTEGER NOT NULL REFERENCES Employee(id) ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS Orders (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    status INTEGER NOT NULL,
    date TEXT NOT NULL,
    Customer_id INTEGER NOT NULL REFERENCES Customer(id) ON DELETE NO ACTION, 
    Invoice_id INTEGER NOT NULL REFERENCES Invoice(id) ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS Product (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL, 
    sku INTEGER NOT NULL, 
    category TEXT NOT NULL, 
    net_price REAL NOT NULL,
    vat REAL NOT NULL, 
    stock INTEGER NOT NULL, 
    Vendor_id INTEGER NOT NULL REFERENCES Vendor(id) ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS ProductList (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    Product_id INTEGER NOT NULL REFERENCES Product(id) ON DELETE NO ACTION, 
    Order_id INTEGER NOT NULL REFERENCES Orders(id) ON DELETE NO ACTION, 
    quantity INTEGER NOT NULL, 
    unit_price REAL NOT NULL, 
    total_price REAL NOT NULL
);
