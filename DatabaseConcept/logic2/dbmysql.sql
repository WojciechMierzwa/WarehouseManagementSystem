
CREATE TABLE Customer 
    (
     id INTEGER NOT NULL , 
     name VARCHAR (80) NOT NULL , 
     phone_number VARCHAR (15) NOT NULL , 
     mail VARCHAR (50) NOT NULL , 
     nip VARCHAR (20) , 
     country VARCHAR (30) NOT NULL , 
     city VARCHAR (30) NOT NULL , 
     postal_code VARCHAR (12) NOT NULL , 
     address_row1 VARCHAR (50) NOT NULL , 
     address_row2 VARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE Customer ADD CONSTRAINT Customer_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Employee 
    (
     id INTEGER NOT NULL , 
     name VARCHAR (50) NOT NULL , 
     surname VARCHAR (50) NOT NULL , 
     pesel INTEGER NOT NULL , 
     phone_number VARCHAR (15) NOT NULL , 
     password VARCHAR (30) NOT NULL , 
     login VARCHAR (30) NOT NULL 
    )
GO

ALTER TABLE Employee ADD CONSTRAINT Employee_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Invoice 
    (
     id INTEGER NOT NULL , 
     status BIT NOT NULL , 
     invoice_date DATETIME NOT NULL , 
     total_amount MONEY NOT NULL 
    )
GO

ALTER TABLE Invoice ADD CONSTRAINT Invoice_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "Order" 
    (
     id INTEGER NOT NULL , 
     status BIT NOT NULL , 
     date DATETIME NOT NULL , 
     Customer_id INTEGER NOT NULL , 
     Invoice_id INTEGER NOT NULL , 
     Employee_id INTEGER NOT NULL 
    )
GO

ALTER TABLE "Order" ADD CONSTRAINT Order_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Product 
    (
     id INTEGER NOT NULL , 
     name VARCHAR (30) NOT NULL , 
     sku INTEGER NOT NULL , 
     category VARCHAR (50) NOT NULL , 
     net_price MONEY NOT NULL , 
     vat MONEY NOT NULL , 
     stock INTEGER NOT NULL , 
     Vendor_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Product ADD CONSTRAINT Product_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Product_list 
    (
     id INTEGER NOT NULL , 
     Product_id INTEGER NOT NULL , 
     Order_id INTEGER NOT NULL , 
     quantity INTEGER NOT NULL , 
     unit_price MONEY NOT NULL , 
     total_price MONEY NOT NULL 
    )
GO

ALTER TABLE Product_list ADD CONSTRAINT Product_list_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Vendor 
    (
     id INTEGER NOT NULL , 
     name VARCHAR (50) NOT NULL , 
     phone_number VARCHAR (15) , 
     mail VARCHAR (50) , 
     nip INTEGER 
    )
GO

ALTER TABLE Vendor ADD CONSTRAINT Vendor_PK PRIMARY KEY CLUSTERED (id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Customer_FK FOREIGN KEY 
    ( 
     Customer_id
    ) 
    REFERENCES Customer 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Employee_FK FOREIGN KEY 
    ( 
     Employee_id
    ) 
    REFERENCES Employee 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Invoice_FK FOREIGN KEY 
    ( 
     Invoice_id
    ) 
    REFERENCES Invoice 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Product_list 
    ADD CONSTRAINT Product_list_Order_FK FOREIGN KEY 
    ( 
     Order_id
    ) 
    REFERENCES ""Order"" 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Product_list 
    ADD CONSTRAINT Product_list_Product_FK FOREIGN KEY 
    ( 
     Product_id
    ) 
    REFERENCES Product 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Product 
    ADD CONSTRAINT Product_Vendor_FK FOREIGN KEY 
    ( 
     Vendor_id
    ) 
    REFERENCES Vendor 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

