-- Customer Table
CREATE TABLE IF NOT EXISTS Customer (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    phone_number TEXT NOT NULL,
    mail TEXT NOT NULL,
    nip TEXT,
    country TEXT NOT NULL,
    city TEXT NOT NULL,
    postal_code TEXT NOT NULL,
    address_row1 TEXT NOT NULL,
    address_row2 TEXT NOT NULL
);

-- Employee Table
CREATE TABLE IF NOT EXISTS Employee (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    surname TEXT NOT NULL,
    pesel INTEGER NOT NULL,
    phone_number TEXT NOT NULL,
    password TEXT NOT NULL,
    login TEXT NOT NULL
);

-- Invoice Table (with Order_id as foreign key)
CREATE TABLE IF NOT EXISTS Invoice (
    id INTEGER PRIMARY KEY,
    status INTEGER NOT NULL,  -- SQLite uses INTEGER for boolean-like fields
    invoice_date DATETIME NOT NULL,
    total_amount REAL NOT NULL,
    Order_id INTEGER NOT NULL,
    FOREIGN KEY (Order_id) REFERENCES "Order"(id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Order Table
CREATE TABLE IF NOT EXISTS "Order" (
    id INTEGER PRIMARY KEY,
    status INTEGER NOT NULL,
    date DATETIME NOT NULL,
    Customer_id INTEGER NOT NULL,
    Employee_id INTEGER NOT NULL,
    FOREIGN KEY (Customer_id) REFERENCES Customer(id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Employee_id) REFERENCES Employee(id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Product Table
CREATE TABLE IF NOT EXISTS Product (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    sku INTEGER NOT NULL,
    category TEXT NOT NULL,
    net_price REAL NOT NULL,
    vat REAL NOT NULL,
    stock INTEGER NOT NULL,
    Vendor_id INTEGER NOT NULL,
    FOREIGN KEY (Vendor_id) REFERENCES Vendor(id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Product_list Table
CREATE TABLE IF NOT EXISTS Product_list (
    id INTEGER PRIMARY KEY,
    Product_id INTEGER NOT NULL,
    Order_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    unit_price REAL NOT NULL,
    total_price REAL NOT NULL,
    FOREIGN KEY (Product_id) REFERENCES Product(id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (Order_id) REFERENCES "Order"(id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Vendor Table
CREATE TABLE IF NOT EXISTS Vendor (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    phone_number TEXT,
    mail TEXT,
    nip INTEGER
);
