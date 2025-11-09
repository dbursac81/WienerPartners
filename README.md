WienerPartners - 3-project solution (Core, Data, Web)

Projects:
- WienerPartners.Core : models
- WienerPartners.Data : Dapper repository (references Core)
- WienerPartners.Web  : Blazor Server UI (references Core & Data)

How to run:
1. Open solution with Visual Studio or run `dotnet build` in solution folder.
2. Create DB WienerDB and run `WienerPartners.Data/sql/create_tables.sql`.
3. From Web project folder:
   dotnet restore
   dotnet run

After running, open the app and test the features.

Note:
- All Razor pages have code-behind files (.razor.cs)
- Repositories use Dapper and set CreatedAtUtc server-side.
