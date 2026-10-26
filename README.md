# NextUp

What's next at a glance - organize upcoming events and task so you can manage your time.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

# 📋 Table of contents
- [About the project](#%E2%84%B9%EF%B8%8Fabout-the-project)
- [Features](#-features)
- [Tech stack](#%EF%B8%8F-tech-stack)
- [Data model](#-data-model)
- [Project structure](#-project-structure)
- [Setup](#%EF%B8%8F-setup)
- [Future plans (Roadmap)](#-future-plans)
- [License](#%EF%B8%8F-license)
- [Contacts](#-contacts)

# ℹ️About the project

NextUp is a task management web app built as the final project for the `ASP.NET Fundamentals` course at `SoftUni`. It is currently in a local self-hosted state but I plan on expanding it after I finish the course.

NextUp allows you to track upcoming events and tasks. You can organize them by cateogries and tags.

# 🚀 Features
- Create Categories, Tags and Tasks
- Update/Edit and Delete Categories (except global), Tags and Tasks 
- Put Tags in a Category
- Add Tags to Tasks
- Put Tasks in Categories
- Global category that cannot be modified or removed (seeded)
- Dashboard home page that shows upcoming tasks, calendar with colored dots to show days with tasks (by category) and colored bars to show how many tasks per category there are

# 🛠️ Tech stack

| Technology | Version | Purpose |
| ------------ | ---------- | --------- |
| `ASP.NET Core MVC` | 8.0 | Web framework |
| `Entity Framework Core` | 8.0 | ORM / Database access |
| `SQL Server` | - | Database |
| `Bootstrap` | 5.1.0 | Front-end styling |
| `Razor Views` | - | Server-side HTML rendering |

# 📊 Data model

| Entity | Purpose |
| ---- | ---|
| `Category` | Contains the categories created by the user and seeded from the server (like Global) |
| `Tag` | Contains the tags created by the user |
| `TaskItem` | Contains the tasks created by the user |
| `TaskTag` | Contains a many-to-many join between the `Tags` and the `Tasks` |

# 📂 Project structure

```

NextUp/
│
├── Common/                  # Classes that hold constant values
├── Controllers/             # MVC Controllers
├── Models/                  # Database Models
├── Views/                   # Razor Views (.cshtml)
├── ViewModels/              # ViewModels (Only ErrorViewModel inside)
├── Data/                    # DbContext
├── Migrations/              # Migrations
├── Services/                # Business logic / service layer
├── wwwroot/                 # Static files (CSS, JS, images)
├── appsettings.json         # App configuration
└── Program.cs               # Entry point for app and setup

```

# ⚙️ Setup 

### Requirements
- .Net 8.0 SDK (or any higher)
- SQL Server (SQL Server Express)
- EF Core tools

### Setup process
*done in terminal/command prompt in Windows*

1. Clone the repository and open the project directory
```
git clone https://github.com/pav-deny/nextup.git
cd nextup
```

2. Check the connection string in `appsettings.json`

It's currently setup to be a locally run DB with a trusted connection

```
Server=.\SQLEXPRESS;Database=Nextup;Trusted_Connection=True;TrustServerCertificate=True;
```

3. Install the EF Core tools (if not installed)

Check using:

```
dotnet --version
dotnet ef --version
```

if dotnet isn't found run:

```
dotnet tool install --global dotnet-ef
```

4. Update the database

```
dotnet ef database update
```

5. Run the app
```
dotnet run
```

**If you don't see an https:// port after running stop (Ctrl + C) and run:* 
```
dotnet run --launch-profile https
```

6. Open the prompted port

Examples:
```
http://localhost:5214
https://localhost:7171
```

### Enviroment variables and credentials
None. The default connection uses Windows authentication

# 🎯 Future plans (Roadmap)

Like mentioned above, this web app is made as a project for the `ASP.NET Fundamentals` course at `SoftUni`. But I wish to continue developing it and one day making it a web app available online.

### Short-term plans (not in order):
* [ ] Make a To-do list toggle for tasks
* [ ] Add users and login and register functionality
* [ ] Add dynamic greeting (based on the time)
* [ ] Make ViewModels
* [ ] Make the homepage and dashboard separate (homepage to be a landing page and the dashboard to be for signed-in users)
* [ ] Add DTO
* [ ] Dashboard to include a filter by category and/or tag

# ⚖️ License

This project is licensed with an `MIT License`. See the [LICENSE](LICENSE) file for details

# 📫 Contacts

**Deni Pavlov** 

**GitHub** [@pav-deny](https://github.com/pav-deny)