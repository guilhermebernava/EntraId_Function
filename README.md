# Microsoft Login with Azure Functions 🔒🔑

This project demonstrates how to implement Microsoft login functionality using Azure Functions. It consists of two functions: one for initiating the login process and another for handling the callback after successful authentication.

## Prerequisites

Before running the project, make sure you have the following:

- [.NET](https://dotnet.microsoft.com/download) installed.
- An Azure account. If you don't have one, you can [create a free account](https://azure.microsoft.com/free/).
- Register your application in the [Azure portal](https://portal.azure.com/) to obtain the following:
  - `CLIENT_ID`: Your Azure AD application client ID.
  - `CLIENT_SECRET`: Your Azure AD application client secret.
  - `TENANT_ID`: Your Azure AD tenant ID.
  - `CALLBACK_URL`: The URL of your callback function (e.g., `http://localhost:7157/api/HandleCallback`).

## Getting Started 

### Configure the project:

1. Open the `local.settings.json` file.
2. Update the following fields with your Azure AD application details:
   - `CLIENT_ID`: Your Azure AD application client ID.
   - `CLIENT_SECRET`: Your Azure AD application client secret.
   - `TENANT_ID`: Your Azure AD tenant ID.
   - `CALLBACK_URL`: The URL of your callback function (e.g., `http://localhost:7157/api/HandleCallback`).

## Usage

1. Open your web browser and navigate to the login function endpoint:

   ```plaintext
   http://localhost:7157/api/LoginUser
    ```
2. Follow the instructions to log in with your Microsoft credentials.

3. After successful authentication, you will be redirected to the callback function, and the token will be displayed.
