
## SurveyShrike
This is the survey application which manages surveys. The admin have access to the survey create and management and the normal users will be able to take surveys.
 

## Readings  
**N-Tier Architecture** – Three tier architecture means the project divided into three main layers or we can also say our project developed and maintained in to three separate layers.

1. Presentation Layers or User Interface Layer
– Presentation layer is a user interface layer where we can design our web page or windows page. It is basically our .aspx page or Html page where we can make design with controls. UI is a intermediate between user and business logic layer. In other simple word we can say Presentation layers where user can give input and get some result as output.

2. Business logic layer (BLL)
– Business layer is intermediate or middle layer that communicate presentation layer and Data access layer.
Business layer used to validate input condition and correct the date before calling method from the data layer.
In Business layer we can write our business logic code and validation code as per the project requirements.

3. Data Access Layer (DAL)
– Data Access Layer used to make connection with database server. In data access layer we can write database query, stored procedure for insert, update, delete, select operation on database.This layer only communicate with Business logic layer.

![Architecture diagram](https://github.com/techno2mahi/SurveyShrike/blob/master/SS_Architecture-Diagram.png)


## Getting Started

Use these steps to get the project set up and running. These steps include for REST API backend applications and Angular 6 frontend application

### Prerequisites Backend Application(Tools and Technologies)
You will need the following tools:

Tools:
-   [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/)  (version 16.2 +)
-   [Node.js](https://nodejs.org/en/)  (version 10 or later) with npm (version 6.11.3 or later)
-   Postman

Technologies:
-   .NET framework 4.5
-   EntityFramework
-   SQL Server 2012 R2
-   InMemory Caching
-   Web API 2.0
-   OAuth 2.0 and OWIN 

### Prerequisites Frontend Application(Tools and Technologies)
You will need the following:

Tools: 
-  VS Code

Technologies:
-  Angular 6
-  Node.js V 10 +
-  Flexbox layout
-  Typescript
-  SCSS
-  Webpack
-  

## Setting up Back End Applications
We have two REST based Web API to set up 

### SurveyShrike-IdentityServer
1. Checkout the repo 
2. Goto the path /src/SurveyShrike-API/  and open the project in Visual Studio
3. Goto the path \Documents\SurveyShrike-Database-Backup.zip and unzip the same to get the database backup file. Restore it to a database.
4. open the web.config file and fix the connection string as per your SQL server instance
5. Right click on the EHRS.IdentityServer project and click on publish. The published artefacts can be deployed in IIS or can be directly deployed to Azure App service. in the development environment you can run this on IIS Express
6. Once the server is started, within the  navigate to ["http://localhost:44442/swagger](http://localhost:44442/swagger). You can see the REST API endpoints. The Account API is having a register endpoint in  /api/identity/v1/Register
    
### SurveyShrike-WebAPI
1. Checkout the repo 
2. Goto the path /src/SurveyShrike-API/  and open the project in Visual Studio
3. The database is the same that was being used for the IdentityServer API
4. Right click on the EHRS.WebAPI project and click on publish. The published artefacts can be deployed in IIS or can be directly deployed to Azure App service. in the development environment you can run this on IIS Express
5. Once the server is started, within the  navigate to ["http://localhost:44444/swagger](http://localhost:44444/swagger). You can see the REST API endpoints. The Account API is having a register endpoint in  /api/services/v1/SurveyAPI

 ## Setting up Frontend End Applications
We have one Angular 6 application to set up 

1. From the checked in codes vist to the path /src/SurveyShrike-Web/
2. Open the folder in Visual Studio code
3. Open the terminal by pressing CTRL+~
4. run the below command
  ```
  npm install
  ```
 5. Start the application by running the below command
 ```
 npm start
 ```
 6. It will open the UI and login to the application by the following credentials
    user name: admin@gmail.com
    password: password
  
 
 
## Project Code Outline

Youtube video URL explaining the architecture of the same.  https://youtu.be/7aZ9iw98p1c
