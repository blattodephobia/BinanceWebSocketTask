To build and run the solution:
1. Go to the src/BinanceWebSocketTask.Web folder. In the appsettings.json file, specify a valid connection string (ConnectionStrings section, Default property). The target server has to have a database named "bwst", i.e. there is nothing, at the moment, in the app to create the database automatically.
2. Go to the src/BinanceWebSocketTask.DataAccess/Scripts folder. Execute the SQL in the CreateTables.sql in a query window against a connection that targets the bwst database. E.g., using the default way, LocalDB:
	2.1. Launch SQL Server Management Studio
	2.2. Connect to (LocalDB)\MSSQLLocalDB using Windows Security
	2.3. Open a new query window; copy and paste the SQL from the CreateTables.sql file in the query window
	2.4. Execute the query (F5)
3. Build the solution using Visual Studio 2022 or later. You'll have to be connected to the internet for the dependent NuGet packages to be downloaded and installed.
4. Start the BinanceWebSocketTask.Web project using the BinanceWebSocketTask.Web configuration (should be default).