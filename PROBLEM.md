## Problem Statement

AbsoluteRobo is a start-up focused on human productivity. The company is building an innovative platform to redefine how human productivity can be increased with the help of technology.
As part of the system design, AbsoluteRobo have researched that in an eight-hour day, the average human is only productive for approximately three hours. 
The problem to solve is to increase the average productive hour of a human by 60%.


## Proposed Solution

As part of the AbsoluteRobo platform, TaskRobo will be a Web application that allows a user to manage daily tasks.
For the initial release, TaskRobo will come with the basic management features to help view and manage tasks of a user. A user will be able to view pending tasks, add new tasks, and mark the status of a task. Application will use FormsAuthentication.

**Milestones**
Milestone 1: SBA: Pre-req Jr-FSE TaskRobo (Approx. 5 hours)

    • Step 1: Add required dependencies for the project 
    • Step 2: Implement Database design using Entity Framework Code-First.
    • Step 3: Implement Data Access for all entities.
    • Step 4: Implement desired Controllers and use Forms Authentication.
    • Step 5: Write test cases using Nunit to perform unit testing with positive and negative scenarios.
    • Step 6: Create the responsive UI for all the features.
    • Step 7: Implement javascript methods.

    
 ### Complete the following classes as per the requirement. These classes represent the database Entities.

**class AppUser**
 
 Define the following properties.
        
        -Email- string (primary key)
        -Password : string  

 **class Category**
 
 Define the following properties.
        
        -CategoryId- int (primary key)
        -CategoryTitle : string
        -UserId- string (foreign key)

**class UserTask**
 
 Define the following properties. 
 
        -TaskId : int (primary key)
        -TaskTitle : string
        -TaskContent : string
        -TaskStatus : string
        -UserId- string (foreign key) -- mapped to Email of AppUser Table
        -CategoryId- int (foreign key)

### Complete the following classes as per the requirement. These classes represent the database operations on entitites.

**class TaskRepository**
 
Implement ITaskRepository to define the Task Operations 
 
 **class CategoryRepository**
 
 Implement ICategoryRepository to define the Category Operations 
        
 **class UserRepository**

 Implement IUserRepository to define the User Operations 

### Complete this JavaScript file to implement custom validation. 

 **Scripts/customValidation.js**
 
 Implement the following methods:
  
         +validateTitle()
         +validateContent()
         +validateStatus()
         +validateForm()


### Design the responsive UI as per below guidelines:

- Task Add View should be designed using plain HTML controls and validation must happen through JavaScript (Scripts/customValidation.js). Also all Categories should be displayed in a drop down.
- Task List view should display all the tasks in bootstrap card layout.
- All remaining views should be generated using Razor scaffolding.

          
 ### Instructions
 - Avoid printing unnecessary values other than expected output as given in sample
 - Take care of whitespace/trailing whitespace
 - Do not change the provided class/method names unless instructed
 - Follow best practices while coding
  
