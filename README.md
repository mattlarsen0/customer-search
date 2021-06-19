# customer-search
A simple React customer search application built with a C# backend.

## Dependencies
[NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

[Node.js (npm)](https://nodejs.org/en/)

[Visual Studio Code](https://code.visualstudio.com/) for easy editing

## Setup and Configuration

### Building
1. In the `frontend` directory, Run `npm install` and `npm run build` to build js/css bundles (copied to `backend/wwwroot/bundles` directory automatically).
2. In the `backend` directory, Run `dotnet run` to build and start the web server.
3. If it does not exist, a database named `customer-test.db` will be created in the working directory.
4. Open app by using the default URL `https://localhost:5001` (see output to confirm URL).

## Other Commands
* Backend Tests (Run in `backendTests` directory)
  - Run NUnit tests: `dotnet test`
* Frontend Tests (Run in `frontend` directory)
  - Run Jest tests: `npm run test`

## Code Explanation
C# and React were chosen because they are the most recent languages that I have professional experience with.

### Backend
Project structure:
* Controllers - View and API controllers
* DomainObjects - Simple Entity Framework objects, minimal or no logic
* DomainServices - Entity Framework and wrappers to retrieve DomainObjects
* Models - Objects to be serialized to JSON by controllers, uses camelCasing to match frontend
* ModelServices - Services to convert DomainObjects into Models that can be used by the frontend
* Properties - Auto-generated configuration files web server
* Views - Simple razor views to display React frontend
* wwwroot - Root of web server. js/css bundles are in `bundles` directory

#### Backend Tests
* Test project, copies folder structure from `backend`

I used Moq and NUnit for my testing libraries. NUnit has a good testing syntax and Moq is a powerful C# interface mocking library.
Moq made it easier to test controllers while avoiding any interaction with the database or modeling services.

Entity Framework worked well, it was simple to setup and use. Testing EF was a bit of a challenge, requiring wrapping CustomerContext in CustomerRepository to properly mock the object.

This was my first time using the `dotnet` CLI tool for anything substantial. It works very well with VS code, I never had to open visual studio 🎉

### Frontend
Tools used:
* React
* Babel
* Jest
* TestingLibrary
* ESLint
* Webpack

`create-react-app` has too many dependencies. To start this project I used an existing package.json from my side project. I had previously "ejected" and trimmed some unneeded packages.

I found TestingLibrary to be a bit difficult to use because I had used Enzyme in the past, I need to practice more with it.

The frontend of this project is weaker than the backend. I have about 1 year of React experience and building the frontend was challenging for me.

### Next steps (What needs improvement?)
* More frontend test coverage
* Split domain from presentation layer (create another project for DomainServices)
* Unity or other DI system to make managing controller objects easier
* Error page is auto-generated from MVC template, should be removed or replaced
* Normalize DB by moving companies from customers into new table (easier filtering by company, more performant?)
* Testing framework helpers, common repeated tasks could be moved into a base class or a service
* Refactor frontend for easier testing (avoid difficult mocking of built-in functions like `fetch`)
