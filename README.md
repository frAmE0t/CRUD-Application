# CRUD Application

This is my pet-project. That web-application can perform basic CRUD operations (Create, Read, Update, Delete) wita data in the database. There is no any interface in this application. You have to use Postman, Swagger or any tool for testing API's you prefer to interract with the database.

## Tech Stack

- C#
- ASP.NET Web API
- Entity Framework
- MS SQL Server

## Installation

1. **Clone the Repository:** Begin by cloning this repository to your local machine.
2. **Database Setup:** Create a SQL Server database and replace the connection string (open the project -> move to the appsettings.json -> find `GamesMarketDb`) with your database connction string.
3. **Development Environment:** Open the project in Visual Studio or your preferred IDE.
4. **Run the Application:** Build and run the project to launch the web application.

## Usage

1. **Access the Application:** Open the web application in your preferred web browser.
2. **Add record:** Choose "POST" option to add a new record. Then fill the required fields with the apropriate information and click "Execute" if you use Swagger.
3. **Get record(s):** Choose "GET" option to get information about current game or developer with ID you have sent to. You also can get a list of the objects stored in your database.
4. **Update record's information:** Choose "PUT" option to update an existing record. Then write down the entity ID and new information you want to add.
5. **Delete record:** Choose "DELETE" option to delete an existing record. Then write down the entity ID click "Execute".

## Contributing

Contributions are welcome! If you encounter issues or have ideas for enhancements, please create a pull request.

## Feedback

Feel free to tailor this template to suit your project's specifics. Update installation steps, add real screenshots, and adapt the information to match your project's unique features and requirements.
