# Simple Credit API

This API provides features for account creation and retrieval as well as transactions

## Installation

1. Clone repository
2. Install the [dotnet core 2.0.0 SDK & cli tools](https://www.microsoft.com/net/core#macos) for Windows, Mac, or Linux.
3. Ensure the 'dotnet' command is added to your terminals PATH.
4. In the repository navigate to src/CreditApp.Api 
5. Open a terminal with admin priveledges (should be in asme directory that has CreditApp.Api.csproj)
6. enter command ```dotnet restore``` to install package dependencies
7. enter command ```dotnet build``` to build the project
8. enter command ```dotnet run``` to host the API

## Usage

> **Note:** This API uses Swashbuckles Swagger UI to generate interactive help documents that are viewable in the browser.

Once the application is running, you can navigate to the [local swagger help pages.](http://localhost:5000/swagger)

### Create Account
This creates an account from the user name passed in the body with a POST request to http://localhost:5000/accounts.
Returns the users id.

> **Note:** In swagger, userName must be a string with quotations, i.e. "user1".

### Get Account
This gets a users account information with a GET request to http://localhost:5000/accounts. 
Returns a users account with current principal and transactions list

### Post Transaction
Make a POST request to http://localhost:5000/transactions with the body:
```
{
  "userName": "user1",
  "type": "purchase", //Can be "purchase" or "payment"
  "amount": 52.10
}
```

> **Note:** Only the three fields above are required to be in the body of the POST request. The "type" property must be a string containing either "purchase" or "payment"

### Get Service Health
Simple make a GET request to http://localhost:5000/health.
Returns status code 200 if API is running.

## Future Plans

1. Implement custom ASP identity system
2. Add unit tests
3. Expose API with an Angular MVC web app
4. Add e2e tests
5. Add custom logging