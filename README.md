# School API

- The Project is an Api solution designed to manage various operations within a school system.
- This API supports multilingual localization (Arabic, English) and is implemented in Clean Architecture 
* Technolgy : .Net 8 

## Features
- **Mediator**  
- **CQRS (Command Query Responsibility Segregation):**
-  **Pagination**
     - There is a pagiantion while retriving All The Students And Department with it's Student  
-  **Searching**
     - Searching for specific Student using his name or address 
-  **Ordering**
    - u can order the Students list based on Name or Department Name or Id    
- **Clean Architecture:**
  
  - The layers include:
    - **API Layer:** Conatians Controllers ,Routing Handling, 
    - **Core Layer:** Provides CQRS Pattern, General Response Handling, Error Handling, validation, mappings, Error Handling, Localiazation , Pagination Handling.
    - **Service Layer:** Contains business logic.
    - **Infrastructure Layer:** Contains Repository Pattern, Migrations,Data Contexts 
    - **Data Layer:** Provides Entities.

- **Validation:**
  - Implements validation mechanisms using FluentValidation And Data Annotation to According to the business rules.  
     For Example u can't add Student with same Full name added before 

- **Localization:**
  - Supports both Arabic and English languages, allowing dynamic switching between languages based on user preferences.

- **Repository Pattern**
  
- **Mapping:**
  - Utilizes AutoMapper to seamlessly map between entities and DTOs (Data Transfer Objects).

- **General Response Handler:**
  - Provides a standardized format for API responses, including metadata, success indicators, and error messages.

## Getting Started

### Prerequisites

- .NET SDK 8.0+
- SQL Server or other supported databases

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/school-api.git
    ```

2. Navigate to the project directory:
    ```bash
    cd school-api
    ```

3. Install dependencies:
    ```bash
    dotnet restore
    ```

4. Set up the database connection string in `appsettings.json`.

5. Apply migrations to the database:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any features, bug fixes, or enhancements.

