# API Project

## Overview:
This project is to develop an web application using and API and how API's work. The basis of the project is that we have a database with 3 tables (Categories, Zones and Devices), these 3 tables contains information on Internet-of-Thing devices. A web application is then used to access the 3 tables on the database, this web application will be used to monitor the devices, zones and categories. With this web app you can create, read, update and delete records. All this is done through an API.

The database is hosted in the Cloud on Azure and I have developed an API that will also be hosted on Azure to access the data on the database through a RESTful API. The API is developed using .NET EntityFrameworkCore. To test that the API works and that it can access the database I have used swagger to be the interface to the API to test that we can Create, Read, Update and Delete data in the database.
## How to use API:
1. Navigate to the following website: ... 
2. Then the following screen will be displayed:![image](https://user-images.githubusercontent.com/90188915/188458513-e6cd0484-a383-489e-a787-75a4f72889ef.png)
3. From this screen you can read, create, update and delete records of the Categories, Devices and Zone tables, but before you can do any of that you will have to log in first.
4. To log in go to the Authenticate section, there you will see 3 Http post methods, 1 to login and the other 2 is to register new users (normal user and admin user) currently both admin and a normal user has the same rights.![image](https://user-images.githubusercontent.com/90188915/188459544-c21de9e3-9129-45c1-8d55-b1d7620d0a0d.png)
5. Select the /login method to log in, then click on the Try it out button and enter the username and password and then just click on execute.![image](https://user-images.githubusercontent.com/90188915/188460036-3316592b-f7b4-444e-b643-0f73172e8437.png)
6. After a successful login you will get a response with a token, copy that token and navigate to the Authorize button. ![image](https://user-images.githubusercontent.com/90188915/188460414-26405262-8d1f-4b0c-8d90-f9fb773c42e8.png) 
7. The following window will open where you should type "Bearer" and then paste your token in after the word Bearer.![image](https://user-images.githubusercontent.com/90188915/188460718-a2f99c0d-aad5-4028-ad9b-2c970913f909.png)
8. Once you are logged in you will be able to access all the methods from the Category, device and zone tables, from there you can select a method and click on Try it out, to test the method. ![image](https://user-images.githubusercontent.com/90188915/188461522-20a8d1fd-35fc-40af-a779-530c5a135ce3.png)![image](https://user-images.githubusercontent.com/90188915/188461553-3dd7da01-c094-4a3d-98e3-856f55afef73.png)![image](https://user-images.githubusercontent.com/90188915/188461575-5acce074-9c6c-4227-a1e1-404a080a0990.png)
9. If a method requires an ID, first run the get method to retrieve all the records and then copy and paste the Id you are interested in, into the id field. Then execute the method to view te results.
## Reference list:
- [Document containing references](https://github.com/dennisvantonder/CMPG-323-Project-2-31609988/blob/main/Reference%20list.docx)
