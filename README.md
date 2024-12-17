# Warehouse Management System  
**.NET Windows Forms Application**  

## Project Overview  
This project is a **CRUD-based application** built on the **.NET platform** using **C#** and **Windows Forms** (WinForms). It serves as a Warehouse Management System to efficiently handle data related to customers, employees, products, and invoices. The system integrates a **SQL Server** database to ensure secure and organized data storage.

---

## Key Features  
- **Customer Management**: Add, edit, delete, and view customer data.  
- **Product Management**: Manage inventory with CRUD operations for products.  
- **Employee Management**: Administer employee accounts, including login access.  
- **Invoice Management**: Generate and manage invoices, linking products and customers.  
- **Flexible Interface**: Centralized interface for managing records with dynamic modes for customers, products, employees, and orders.  

---

## Application Structure  
- **LoginForm.cs**: Secure login for employees.  
- **Menu.cs / MenuAdmin.cs**: Navigation menus for standard users and administrators.  
- **RecordManager.cs**: Unified module for performing CRUD operations across various datasets (customers, products, employees, invoices).  
- **CreateEdit Forms**: Dedicated forms for adding and updating:  
   - `Customers`  
   - `Employees`  
   - `Products`  
   - `Invoices`  
- **Hurtownia DataSet.xsd**: Defines data schemas and relationships for SQL Server integration.  

---

## Database Structure  
The database contains the following tables:  
1. **Customer**: Stores customer details.  
2. **Employee**: Manages employee accounts with credentials.  
3. **Product**: Handles product inventory.  
4. **Invoice**: Tracks orders and links customers to purchases.  
5. **Product_list**: Connects products to invoices.  

**Relationships**:  
- `Invoice` links to `Customer` via a foreign key.  
- `Product_list` links to both `Product` and `Invoice`.  

---

## Technology Stack  
- **C#** (.NET Framework - Windows Forms)  
- **SQL Server** (Relational Database Management System)  

---

## Additional Features  
- **PDF Generation**: The system generates PDF invoices for completed orders, providing a professional and easily shareable format for customers.  
