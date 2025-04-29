# ACCI WinForms Application

## Overview

ACCI WinForms is a Windows Forms application developed using .NET 9, designed to manage the operations of an examination certification center. It facilitates various administrative tasks related to the certification process.

Key functionalities include:

* Student registration management
* Exam scheduling and coordination
* Test result recording and management
* Invoice generation and payment processing
* Discount application and management
* Handling of certificate extension fees

## Features

* **Role-Based Access Control:** Provides distinct user interfaces and permissions tailored for different staff roles (Reception, Accountant, Data Entry).
* **Registration Management:** Allows staff to create new student registration forms and efficiently search existing records.
* **Invoice Handling:** Enables the creation and management of invoices for certification services rendered.
* **Test Results:** Facilitates recording test scores and updating certification statuses for students.
* **Discount Management:** Supports the application and tracking of special offers and discounts on services.

## Technical Stack

* **Frontend:** C# Windows Forms (.NET 9)
* **Backend:** C# (.NET 9)
* **Database:** MySQL
* **Data Access:** Direct ADO.NET using `MySqlConnector`

## Prerequisites

* .NET 9 SDK
* Visual Studio 2022 (or later compatible version)
* Docker Desktop (for database setup using the provided instructions)
* `databaseinit.sql` file (required for database schema initialization)

## Database Setup

### Using Docker

1.  Ensure Docker Desktop is installed and running.
2.  Run the following command in your terminal to start a MySQL container named `pttkhttt`:

    ```bash
    docker run -d --name pttkhttt `
      -p 33306:3306 `
      -e MYSQL_ROOT_PASSWORD=root `
      -e MYSQL_DATABASE=ACCI `
      mysql:latest
    ```

    *Note: The backticks (` `) are for line continuation in PowerShell. For bash/zsh, use backslashes (` \`). Or simply run the command as a single line.*

    Single line command:
    ```bash
    docker run -d --name pttkhttt -p 33306:3306 -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=ACCI mysql:latest
    ```

3.  Initialize the database schema using the `databaseinit.sql` script. Place the script in the directory where you run the command.

    * **For Windows PowerShell:**
        ```powershell
        cat databaseinit.sql | docker exec -i pttkhttt mysql -uroot -proot ACCI
        ```

    * **For Linux/Mac (bash/zsh):**
        ```bash
        cat databaseinit.sql | docker exec -i pttkhttt mysql -uroot -proot ACCI
        ```

## Running the Application

1.  Clone the repository (if applicable).
2.  Open the solution file (`.sln`) in Visual Studio 2022.
3.  Build the solution (Build > Build Solution or `Ctrl+Shift+B`).
4.  Run the application (Debug > Start Debugging or `F5`).

## Project Structure

The project follows a standard structure for WinForms applications:

* `DataAccess/`: Contains Data Access Objects (DAOs) responsible for all database interactions.
* `Forms/`: Holds all the Windows Forms (`.cs` files) that constitute the user interface.
* `Models/`: Defines the data models (classes) that represent database entities.
* `Utils/`: Includes utility classes, potentially containing database connection helpers, session management logic, etc.

## Database Configuration

The application connects to the MySQL database using the following connection string format. Ensure your database server is configured accordingly.