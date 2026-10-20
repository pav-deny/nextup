# NextUp [EARLY STAGE]

*📌This app is still in early development - not all features have been implemented. This document isn't full either as it needs a "full version" (simple task management) to include things like tasks and a setup guide*

What's next at a glance - organize upcoming events, tasks and to-do lists so you can manage your time.

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
- [Future plans](#-future-plans)
- [License](#%EF%B8%8F-license)
- [Contacts](#-contacts)

# ℹ️About the project

NextUp is a task management web app built as the final project for the `ASP.NET Fundamentals` course at `SoftUni`. It is currently in a local self-hosted state but I plan on expanding it after I finish the course.

NextUp allows you to track upcoming events, tasks and to-do lists. You can sort them by cateogries and tags.

# 🚀 Features
*list coming when full version releases*

# 🛠️ Tech stack

| Technology | Version | Purpose |
| ------------ | ---------- | --------- |
| `ASP.NET Core MVC` | 8.0 | Web framework |
| `Entity Framework Core` | 8.0 | ORM / Database access |
| `SQL Server` | - | Database |
| `Bootstrap` | 5.3 | Front-end styling |
| `Razor Pages / Views` | - | Server-side HTML rendering |

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
├── Controllers/             # MVC Controllers
├── Models/                  # Database Models
├── Views/                   # Razor Views (.cshtml)
├── ViewModels/              # ViewModels
├── Data/                    # DbContext
├── Migrations/              # Migrations
├── Services/                # Business logic / service layer
├── wwwroot/                 # Static files (CSS, JS, images)
├── appsettings.json         # App configuration
└── Program.cs               # Entry point for app and setup

```

# ⚙️ Setup 

Instructions coming soon (when app has a full version)

# 🎯 Future plans 

Like mentioned above, this web app is made as a project for the `ASP.NET Fundamentals` course at `SoftUni`. But I wish to continue developing it and one day making it a web app available online.

# ⚖️ License

This project is licensed with an `MIT License`. See the [LICENSE](LICENSE) file for details

# 📫 Contacts

**Deni Pavlov** 

**GitHub** [@pav-deny](https://github.com/pav-deny)