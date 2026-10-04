# NextUp

A personal planner web app for tracking daily things - work, exams, assignments and more in one ordered place.

*📌 Note: this project is still in early development. This README is just a base that will have content added alongside the project*

## 🚀 Features
*No features have been implemented yet*

## 🛠️ Tech stack

### Front-end
* **HTML5 | CSS3 | JavaScript**
* **Bootstrap** (UI Framework)


### Back-end
* **ASP.NET Core 8.0 (MVC Architecture)**
* **Entity Framework Core**
* **SQL Server**

## 📊 Data model

*No data models implemented yet.*

| Entity | Purpose |
|---|---|
| `N/A` |  |

## ⚙️ Setup
*Requires .NET 8 SDK and SQL Server*

1. **Clone the repository**
``` bash
git clone https://github.com/pav-deny/nextup.git
cd NextUp
```

2. **Restore packages**
``` bash
dotnet restore
```

3. **Configure the connection string** (if you're not using LocalDB)

* Open `appsettings.json` and verify that the database connection string points to the local SQL Server Instance you are using (defaults to LocalDB)

4. **Apply database migrations**
``` bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. **Run the app**
``` bash
dotnet run
```

6. **Open the app through prompted URL (e.g. `https://localhost:5001`)**

## 🎯 Future plans
*Although this is made as a course project, I plan to continue developing it and hopefully make it into a full web app in the future*