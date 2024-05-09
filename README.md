# Contact Manager - Blazor WebAssembly PWA

Contact Manager is a progressive web application (PWA) built with Blazor WebAssembly. It allows users to manage a contact list with the ability to create, read, update, and delete contacts. It also features sorting capabilities and is designed to work offline.

## Features

- **CRUD Operations**: Create, read, update, and delete contacts.
- **Sorting**: Sort contacts by first name, last name, and other criteria in ascending or descending order.
- **Validation**: Client-side validation to ensure that required fields are filled before submission.
- **Responsive UI**: The application is responsive and works across different devices.
- **Offline Access**: Enabled through PWA capabilities, allowing for use even without an internet connection.
- **Filtering**: (Optional) Ability to filter the contact list based on specific criteria.
- **Error Handling**: Meaningful error messages are displayed to users as feedback for actions.

## Technologies Used

- **.NET 6**
- **Blazor WebAssembly**
- **Bootstrap** for styling

## Prerequisites

Before you run the application, ensure you have the following installed:
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Setup and Installation

1. **Clone the repository**

   ```bash
   git clone [URL of the repository]
   cd [repository name]
## Getting Started

### 1. Open the Solution File

Clone the repository and navigate to the project directory. Open the solution file `Contact_Task_DeyaAlbettar.sln` in Visual Studio or your preferred IDE.

### 2. Run the Backend ASP.NET Core API

1. In the Solution Explorer, right-click on the `ContactBackend` project.
2. Select **Set as Startup Project**.
3. Press `Ctrl + F5` or click on the **Start** button to build and run the backend API. 
4. By default, the API will start running on `http://localhost:5000`.

### 3. Run the Blazor WebAssembly PWA Frontend

1. Similarly, right-click on the `ContactFrontend` project in the Solution Explorer.
2. Select **Set as Startup Project**.
3. Press `Ctrl + F5` or click on the **Start** button to build and run the Blazor WebAssembly PWA frontend.
4. The frontend will be accessible by default at `http://localhost:5001`.
