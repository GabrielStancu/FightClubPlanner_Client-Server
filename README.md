# FightClubPlanner_Client-Server

The application is called FightClubPlanner. Although "nobody talks about the Fight Club", we will give it a brief description here. For more information check the documentation.

The app provides a place for managers to create and organize their MMA fights tournaments (create them, send invites to fighters and generate fights for these tournaments), while the fighters can accept invites and test themselves, as we have to ensure Covid - safety measures. In order too fight, a fighter must have at least 3 weeks of negative tests. In this version the tournament policy can be either weekly or monthly.

A major update from the first version is the migration in a web environment. The application is divided by the client - server architecture. They communicate by HTTP requests.

The server is developed using the layered architecture. The layers are: API (controllers and configuration/startup files), Core(models and database context) and Infrastructure(connects the previous 2 layers through DTOs, repositories and services).

The client is divided by the component it uses. We have a component for each view loaded in the client application, models and services.

Database provider: SQL Server

Application Framework: .NET Core 3.1 Web Application (server) + Angular (client)

Languages: C#, HTML, CSS, Typescript

For a visual demo of the application, please check the following link:

https://www.youtube.com/watch?v=_KSQUpyolfo
