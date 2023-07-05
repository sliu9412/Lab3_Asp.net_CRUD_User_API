# About the App

This is the project for the Lab3 for Conestoga College PROG8185-23S-Sec1-Web Technologies.



## Run the App

Move to the root folder of the project, use the command below to run the App.

```powershell
dotnet watch run
```

![](doc/screenshot/2023-07-05-19-00-06-image.png)

Then the Swagger will be displayed with the APIs 

![](doc/screenshot/2023-07-05-19-04-23-image.png)



### Create a new user

Select the Post API in Swagger, click "try out", add a new user's information (The id of user is unecessary, because the new one will be generated automatically).

![](doc/screenshot/2023-07-05-19-07-11-image.png)



### Retrieve all users

Select the get API without param, it will response the list of all users in the database.

![](doc/screenshot/2023-07-05-19-09-08-image.png)



### Retrieve User by ID

Copy a user id, for instance, <mark>80d5ca0a-ce85-4cee-afa8-751db265f31e</mark> from the screen below.

Select the get API with param (UserId), then paste the id, and the program will only return the User with valid id.

![](doc/screenshot/2023-07-05-19-13-36-image.png)



### Update User by Id

Select the put API, fill the JSON data of a user info needs to be updated (id should not be modified forever), then execute and check the result.

![](doc/screenshot/2023-07-05-19-17-22-image.png)

![](doc/screenshot/2023-07-05-19-17-56-image.png)
