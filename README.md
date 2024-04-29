This is an ASP.NET Web API project for managing student records and marks using "DATABASE FIRST APPROACH".


Technologies Used

- ASP.NET Web API: The project is built using ASP.NET Web API, a framework for building RESTful web services.
- SSMS (SQL Server Management Studio): The database used in this project is managed using SQL Server Management Studio.
- Entity Framework Core: The project employs Entity Framework Core as the Object-Relational Mapping (ORM) tool, which provides an abstraction over the database and simplifies data access.
- AutoMapper: AutoMapper is utilized for mapping between entities and data transfer objects (DTOs), facilitating object-to-object mapping.
- Three-tier Architecture: The project follows a three-tier architecture pattern, separating concerns into the Presentation Layer (Web API), Business Logic Layer (Services), and Data Access Layer (Repository).

Project Structure

The project is organized into the following layers:

1. Presentation Layer (API): This layer contains the ASP.NET Web API controllers responsible for handling HTTP requests and responses.
2. Business Logic Layer (Services): This layer encapsulates the business logic and rules of the application.
3. Data Access Layer (Repository): This layer handles the interaction with the database using Entity Framework Core.
