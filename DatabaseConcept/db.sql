CREATE TABLE Address 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    country VARCHAR(30) NOT NULL, 
    city VARCHAR(30) NOT NULL, 
    postal_code VARCHAR(30) NOT NULL, 
    street VARCHAR(30) NULL, 
    building_number VARCHAR(30) NULL, 
    Vendor_id INT NOT NULL, 
    Customer_id INT NOT NULL, 
    Employee_id INT NOT NULL,
    CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE Customer 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    name VARCHAR(80) NOT NULL, 
    phone_number VARCHAR(15) NOT NULL, 
    mail VARCHAR(50) NOT NULL, 
    nip VARCHAR(15) NULL,  -- Changed to VARCHAR for leading zeros
    CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE Employee 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    name VARCHAR(50) NOT NULL, 
    surname VARCHAR(50) NOT NULL, 
    pesel VARCHAR(20) NOT NULL, 
    phone_number VARCHAR(15) NOT NULL,
    login VARCHAR(30) NOT NULL,  -- Login field
    password VARCHAR(30) NOT NULL,  -- Password field
    account_type CHAR(1) NOT NULL CHECK (account_type IN ('a', 'm', 'e')),  -- Account type (admin, manager, employee)
    CONSTRAINT PK_Employee PRIMARY KEY CLUSTERED (id)
);
GO


CREATE TABLE Invoice 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    status BIT NOT NULL, 
    invoice_date DATETIME NOT NULL, 
    total_amount MONEY NOT NULL,
    CONSTRAINT PK_Invoice PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE Orders  -- Renamed to avoid reserved keyword
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    status BIT NOT NULL, 
    date DATETIME NOT NULL, 
    Customer_id INT NOT NULL, 
    Invoice_id INT NOT NULL,
    CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE Product 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    name VARCHAR(30) NOT NULL, 
    sku INT NOT NULL, 
    category VARCHAR(50) NOT NULL, 
    net_price MONEY NOT NULL, 
    vat MONEY NOT NULL, 
    stock INT NOT NULL, 
    Vendor_id INT NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE ProductList  -- Renamed for consistency
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    Product_id INT NOT NULL, 
    Order_id INT NOT NULL, 
    quantity INT NOT NULL, 
    unit_price MONEY NOT NULL, 
    total_price MONEY NOT NULL,
    CONSTRAINT PK_ProductList PRIMARY KEY CLUSTERED (id)
);
GO

CREATE TABLE Vendor 
(
    id INT NOT NULL IDENTITY(1,1),  -- Automatically incrementing ID
    name VARCHAR(50) NOT NULL, 
    phone_number VARCHAR(15) NULL, 
    mail VARCHAR(50) NULL, 
    nip VARCHAR(15) NULL,  -- Changed to VARCHAR for leading zeros
    CONSTRAINT PK_Vendor PRIMARY KEY CLUSTERED (id)
);
GO

-- Foreign Key Constraints

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Customer FOREIGN KEY (Customer_id) 
REFERENCES Customer (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Employee FOREIGN KEY (Employee_id) 
REFERENCES Employee (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Address 
ADD CONSTRAINT FK_Address_Vendor FOREIGN KEY (Vendor_id) 
REFERENCES Vendor (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Customer FOREIGN KEY (Customer_id) 
REFERENCES Customer (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Invoice FOREIGN KEY (Invoice_id) 
REFERENCES Invoice (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE ProductList 
ADD CONSTRAINT FK_ProductList_Order FOREIGN KEY (Order_id) 
REFERENCES Orders (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE ProductList 
ADD CONSTRAINT FK_ProductList_Product FOREIGN KEY (Product_id) 
REFERENCES Product (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Product 
ADD CONSTRAINT FK_Product_Vendor FOREIGN KEY (Vendor_id) 
REFERENCES Vendor (id) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO
