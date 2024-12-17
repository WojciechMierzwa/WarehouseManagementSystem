CREATE TABLE Customer 
    (
     id INTEGER IDENTITY(1,1) NOT NULL, 
     name VARCHAR(80) NOT NULL, 
     phone_number VARCHAR(15) NOT NULL, 
     mail VARCHAR(50) NOT NULL, 
     nip VARCHAR(20), 
     country VARCHAR(30) NOT NULL, 
     city VARCHAR(30) NOT NULL, 
     postal_code VARCHAR(12) NOT NULL, 
     address_row1 VARCHAR(50) NOT NULL, 
     address_row2 VARCHAR(50) NOT NULL 
    )
GO

ALTER TABLE Customer ADD CONSTRAINT Customer_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON, 
     ALLOW_ROW_LOCKS = ON)
GO

CREATE TABLE Employee 
    (
     id INTEGER IDENTITY(1,1) NOT NULL, 
     name VARCHAR(50) NOT NULL, 
     surname VARCHAR(50) NOT NULL, 
     login VARCHAR(30) NOT NULL, 
     password VARCHAR(30) NOT NULL 
    )
GO

CREATE TABLE Invoice 
    (
     id INTEGER IDENTITY(1,1) NOT NULL, 
     status BIT NOT NULL, 
     date DATETIME NOT NULL, 
     Customer_id INTEGER NOT NULL, 
     invoice VARCHAR(100) 
    )
GO

ALTER TABLE Invoice ADD CONSTRAINT Invoice_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON, 
     ALLOW_ROW_LOCKS = ON)
GO

CREATE TABLE Product 
    (
     id INTEGER IDENTITY(1,1) NOT NULL, 
     name VARCHAR(30) NOT NULL, 
     sku INTEGER NOT NULL, 
     category VARCHAR(50) NOT NULL, 
     net_price MONEY NOT NULL, 
     vat MONEY NOT NULL, 
     stock INTEGER NOT NULL, 
     vendor VARCHAR(50) NOT NULL 
    )
GO

ALTER TABLE Product ADD CONSTRAINT Product_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON, 
     ALLOW_ROW_LOCKS = ON)
GO

CREATE TABLE Product_list 
    (
     id INTEGER IDENTITY(1,1) NOT NULL, 
     Product_id INTEGER NOT NULL, 
     Invoice_id INTEGER NOT NULL, 
     quantity INTEGER NOT NULL
    )
GO

ALTER TABLE Product_list ADD CONSTRAINT Product_list_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON, 
     ALLOW_ROW_LOCKS = ON)
GO

-- Add foreign key constraint between Invoice and Customer
ALTER TABLE Invoice 
    ADD CONSTRAINT Invoice_Customer_FK FOREIGN KEY (Customer_id)
    REFERENCES Customer(id)
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO

-- Add foreign key constraint between Product_list and Invoice
ALTER TABLE Product_list 
    ADD CONSTRAINT Product_list_Invoice_FK FOREIGN KEY (Invoice_id)
    REFERENCES Invoice(id)
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO

-- Add foreign key constraint between Product_list and Product
ALTER TABLE Product_list 
    ADD CONSTRAINT Product_list_Product_FK FOREIGN KEY (Product_id)
    REFERENCES Product(id)
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
