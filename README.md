# 🧾 WienerPartners

A **Blazor Server (.NET 7.0)** web application for managing insurance partners and their policies.  
This project was built according to the provided technical and functional specification, using **C# / HTML / JS / T-SQL** with a **Dapper Micro ORM** data layer.

---

	## 📁 Project Structure

The solution consists of **three projects**, following a clean architecture approach:

WienerPartners.sln
│
├── WienerPartners.Blazor → Blazor Server web application (UI + pages)
├── WienerPartners.Core → Business entities and core models
└── WienerPartners.Data → Data access layer using Dapper


	## ⚙️ Requirements

- **.NET 7.0 SDK**
- **SQL Server (Express or full)**
- **Visual Studio 2022** or **VS Code**
- **Bootstrap 4** (already included)
- **Dapper** NuGet package


	## 🧱 Database Setup

1. Open a SQL Server database.
2. Run the SQL script placed in WienerPartners.Data/sql folder.
3. In appsettings.json of WienerPartners.Web, adjust your connection string if needed:
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost;Database=WienerDb;Integrated Security=True;TrustServerCertificate=true;"
    }


	## 🚀 Running the Application

Open the solution in Visual Studio.
Set WienerPartners.Web as the startup project.
Press F5 to run the app.
Navigate to https://localhost:5001


	##🔒 Security and Validation

Input data validated both on client (Blazor) and server side
Proper data typing and length validation enforced
UTC timestamps handled automatically on insert


	## 🧩 Technologies Used

.NET 7.0
Blazor Server
C# / Razor Pages
Dapper ORM
Bootstrap 4
SQL Server (T-SQL)


	##📦 Deployment Notes

Deploy via IIS or Docker (standard Blazor Server setup)
Database name must remain WienerDb
Connection string in appsettings.json must be configured for the target environment