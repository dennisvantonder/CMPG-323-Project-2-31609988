# API Project

## Overview:
This project is to develop an web application using and API and how API's work. The basis of the project is that we have a database with 3 tables (Categories, Zones and Devices), these 3 tables contains information on Internet-of-Thing devices. A web application is then used to access the 3 tables on the database, this web application will be used to monitor the devices, zones and categories. With this web app you can create, read, update and delete records. All this is done through an API.

The database is hosted in the Cloud on Azure and I have developed an API that will also be hosted on Azure to access the data on the database through a RESTful API. The API is developed using .NET EntityFrameworkCore. To test that the API works and that it can access the database I have used swagger to be the interface to the API to test that we can Create, Read, Update and Delete data in the database.
## How to use API:
1. Navigate to the following website: [Project 2 API](https://iot-connectedofficeproject.azurewebsites.net/swagger/index.html) 
2. Then the following screen will be displayed:![image](https://user-images.githubusercontent.com/90188915/188458513-e6cd0484-a383-489e-a787-75a4f72889ef.png)
3. From this screen you can read, create, update and delete records of the Categories, Devices and Zone tables, but before you can do any of that you will have to log in first.
4. To log in go to the Authenticate section, there you will see 3 Http post methods, 1 to login and the other 2 is to register new users (normal user and admin user) currently both admin and a normal user has the same rights.![image](https://user-images.githubusercontent.com/90188915/188459544-c21de9e3-9129-45c1-8d55-b1d7620d0a0d.png)
5. Select the /login method to log in, then click on the Try it out button and enter the username and password and then click on execute.![image](https://user-images.githubusercontent.com/90188915/188460036-3316592b-f7b4-444e-b643-0f73172e8437.png)
6. After a successful login you will get a response with a token, copy that token. ![image](https://user-images.githubusercontent.com/90188915/188868792-9a88bcfe-d241-47c4-9f4c-4828127a962c.png)
Navigate to the Authorize button.
![image](https://user-images.githubusercontent.com/90188915/188460414-26405262-8d1f-4b0c-8d90-f9fb773c42e8.png) 
7. The following window will open where you need to type "Bearer" and then paste your token in after the word Bearer.![image](https://user-images.githubusercontent.com/90188915/188460718-a2f99c0d-aad5-4028-ad9b-2c970913f909.png)
8. Once you are logged in you will see a closed lock icon next to each endpoint. You will be able to access all the methods from the Category, device and zone tables. ![image](https://user-images.githubusercontent.com/90188915/188869419-2e11aeb1-30ac-4f19-b49a-1f0afa557224.png)
9. Click on the try it out button to test the endpoint. You will then see an execute button to run the method. ![image](https://user-images.githubusercontent.com/90188915/188869788-80a705a5-9687-4ea8-9a01-31c2448fb0bf.png)
After you have executed an endpoint you will get a response like the following: ![image](https://user-images.githubusercontent.com/90188915/188870069-e79fd665-1ca8-45c9-9937-ffe7e2d30450.png)
10. If a method requires an ID, first run the get method to retrieve all the records and then copy and paste the Id you are interested in, into the id field. Then execute the method to view te results. 
![image](https://user-images.githubusercontent.com/90188915/188870161-4eca2cbb-d0e9-4b92-af51-01c306751bd7.png)

### How the ID's work for each table:
The Id's of each table is a uniqueIdentifier value. The Id's looks like this: 3fa85f64-5000-4500-d301-2c963f66afa6,
- The first 4 digit number indicates the category ID
- The second 4 digit number indicates the zone ID
- The third value is a d with 3 numbers to show the device ID

When adding a new table you can just increment the value for the table you are working with. A new category id would be 3fa85f64-5001-4562-d301-2c963f66afa6 and so on.
## Reference list:
- [Document containing references](https://github.com/dennisvantonder/CMPG-323-Project-2-31609988/blob/main/Reference%20list.docx)
