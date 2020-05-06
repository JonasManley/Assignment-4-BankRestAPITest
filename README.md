# Assignment-4-BankRestAPITest

## Assignment

Implement a RESTful API on that uses the contract.
In the case that there are discrepancies between contract methods with DTOs
and the functionality needed for the API endpoints; adjust the contract.
Remember to adjust contract tests as well.
Set up tests for the Rest API, using one or more of the following.
• Using your package manager (Maven)
• Creating a separate project, using setUp and tearDown methods to
start the service.
• Using A CI-server
• A dedicated REST test tool (e.g. Postman)

## API

We have created a REST Api with visual studio (ASP.Net web-application), where we have implemented CRUD methods for Bank, Account, Customer. Take a look at the files in the controller folder..

Movement class and methods is yet to be implemented.

## CI

We have a CI server running on Azure pipelines, which can validate and test compilation and rest calls.

## Postman

We also tested the API calls manually with postman, here is an example:

![Overview over API calls](https://github.com/JonasManley/Assignment-4-BankRestAPITest/blob/master/1.png)
![Postman response to a get call](https://github.com/JonasManley/Assignment-4-BankRestAPITest/blob/master/2.png)
