# MyContactsApp Documentation

This README outlines the libraries, classes and methods descriptions, as well as the process of compiling the project.

## Libraries and frameworks used in the project

### General Frameworks and Libraries
- .NET 6.0

### Authentication and Security
- Microsoft.AspNetCore.Authentication.JwtBearer
- System.IdentityModel.Tokens.Jwt
- BCrypt.Net-Next

### Entity Framework Core and Database
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql
- Npgsql.EntityFrameworkCore.PostgreSQL

### AutoMapper
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection

### MediatR (Mediator Pattern Implementation)
- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection

### API Documentation
- Swashbuckle.AspNetCore

## Classes and methods descriptions

### Controllers

#### CategoriesController
- **GetCategoryById(int id)**
  - Retrieves a single category by its ID.
- **GetAllCategories()**
  - Fetches all categories.

#### ContactsController
- **CreateContact(ContactDTO contactDto)**
  - Creates a new contact.
- **UpdateContact(int id, ContactDTO contactDto)**
  - Updates an existing contact.
- **DeleteContact(int id)**
  - Deletes a contact.
- **GetAllContacts()**
  - Retrieves all contacts.
- **GetContactByEmail(string email)**
  - Finds a contact by email.

#### SubcategoriesController
- **CreateSubcategory(SubcategoryDTO subcategoryDTO)**
  - Creates a new subcategory.
- **GetAllSubcategories()**
  - Fetches all subcategories.

#### UsersController
- **Register(UserDTO userDto)**
  - Handles user registration.
- **Login(LoginDTO loginDto)**
  - Manages user login.



### Commands

#### Categories
- **GetAllCategoriesQuery**
  - Fetches all categories from the database.
- **GetCategoryByIdQuery**
  - Retrieves a specific category by its ID.

#### Contacts
- **CreateContactCommand**
  - Creates a new contact in the database.
- **DeleteContactCommand**
  - Deletes a contact from the database.
- **GetAllContactsQuery**
  - Retrieves all contacts from the database.
- **GetContactByEmailQuery**
  - Fetches a contact by email.
- **UpdateContactCommand**
  - Updates a contact's information.

#### Subcategories
- **CreateSubcategoryCommand**
  - Creates a new subcategory in the database.
- **GetAllSubcategoriesQuery**
  - Retrieves all subcategories from the database.

#### Users
- **LoginUserCommand**
  - Handles the user login process.
- **RegisterUserCommand**
  - Manages user registration.

### DatabaseContext
- **MyContactsContext**
  - The primary class that coordinates Entity Framework functionality for the data model. This class is responsible for connecting to the database and mapping the entities to database tables.

### Data Transfer Objects (DTOs)
- DTOs are used to transfer data between the application and the database, ensuring that only necessary data is exposed.

#### Categories
- **CategoryDTO**
  - Data structure for transferring category data.

#### Contacts
- **ContactDTO**
  - Data structure for transferring contact data.

#### Subcategories
- **SubcategoryDTO**
  - Data structure for transferring subcategory data.

#### Users
- **UserDTO**
  - Data structure for transferring user data.
- **LoginDTO**
  - Data structure used for user login.

### Exceptions
Custom exceptions are defined to handle specific error scenarios within the application.

#### [CategoryNotFoundException](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Exceptions/CategoryNotFoundException.cs)
- Thrown when a requested category is not found in the database.

#### [ContactNotFoundException](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Exceptions/ContactNotFoundException.cs)
- Thrown when a requested contact is not found.

#### SubcategoryNotFoundException
- Thrown when a requested subcategory is not found.

#### UserNotFoundException
- Thrown when a user is not found during authentication or other user-related operations.

### JWT (JSON Web Token)
The JWT folder contains classes for managing JWT-based authentication.

#### JwtAuthenticationManager
- Manages the creation and validation of JWTs for authenticated users.

#### JwtConfig
- Contains configuration settings for JWT, such as secret keys and expiration times.

### Mapping
Mapping configurations are used to map data transfer objects (DTOs) to domain models and vice versa, simplifying data transformation processes.

#### CategoryProfile
- Defines mapping rules for `Category` objects.

#### ContactProfile
- Defines mapping rules for `Contact` objects.

#### SubcategoryProfile
- Defines mapping rules for `Subcategory` objects.

#### UserProfile
- Defines mapping rules for `User` objects.

### Models
Models represent the data structures used in the application.

#### [Category](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Models/Category.cs)
- Represents a category with properties `Id` and `Name`.

#### [Contact](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Models/Contact.cs)
- Represents a contact with properties `Id`, `FirstName`, `LastName`, `Email`, `CategoryId`, `SubcategoryId`, `PhoneNumber`, `Birthdate`, and a `Category` object.

#### [Subcategory](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Models/Subcategory.cs)
- Represents a subcategory with properties `Id` and `Name`.

#### [User](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Models/User.cs)
- Represents a user with properties `Id`, `FirstName`, `LastName`, `Email`, and `PasswordHash`.

### Repositories
Repositories handle the data operations with the database, abstracting the complexities of direct database access.

#### [CategoriesRepository](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Repositories/CategoriesRepository.cs)
- Manages CRUD operations for categories, including fetching a category by ID and retrieving all categories.

#### [ContactsRepository](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Repositories/ContactsRepository.cs)
- Handles CRUD operations for contacts, including adding, updating, deleting, and fetching contacts by ID, email, or all contacts.

#### [SubcategoriesRepository](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Repositories/SubcategoriesRepository.cs)
- Manages operations for subcategories, including adding subcategories and retrieving all subcategories.

#### [UsersRepository](https://github.com/gugucharm/MyContactsApp/blob/master/MyContactsApp.DAL/Repositories/UsersRepository.cs)
- Handles user-related operations, including adding users and fetching users by email.

## The process of compiling and running the project