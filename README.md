# MatchTables
MatchTables is a simple tool to Compare Data of Two Tables sharing the same Schema. Some Scenario is explained in details here:
 
Picture a customer that has a sourcesystem that provides data about employees, now they change the sourcesystem to something else and they have transferred all the employees to the new system.
What we want to make sure is that we get the exact same data content from the new source as we did from the old one.

The customer has arranged two tables as shown in the picture below, where SourceTable1 contains the data from the old system and SourceTable2 contains the data from the new system. They expect the tables to contain the same employees and want to know all differences about the the two tables.

* What employees exists in table1 and not in table2?
* What employees has been removed from table2 (which does not exist in table1)
* Has any of the fields changed.

# Sample Data Setup
Step 1: Clone the following repository from Github.
```
git clone https://github.com/faysalmirmd/MatchTables.git
```
Step 2: From the Script folder Run the the script **MatchTables_CreateDBTbl_Script.sql** for creating Database and some tables.

This will create 
```
Database 
  [MatchTablesDB] 
Tables 
  [EmployeeOldTable], Primary Key : [socialsecuritynumber]
  [EmployeeNewTable], Primary Key : [socialsecuritynumber]
  [StudentOldTable], Primary Key : [StudentId]
  [StudentNewTable], Primary Key : [StudentId]
```
Step 3: From the Script folder Run the the script **MatchTables_DataInsert.sql** for inserting sample data into the tables

# Project Setup
Step 1: Download and install .NET Core 3.1 SDK (https://dotnet.microsoft.com/download/dotnet-core/3.1)

Step 2: Clone the following repository from Github.
```
git clone https://github.com/faysalmirmd/MatchTables.git
cd MatchTables
```
Step 3: Change Connection String in **appsettings.json** file to match yours
```
"ConnectionStrings": {
    "DataConnection": "Data Source=localhost;Initial Catalog=MatchTablesDB;Persist Security Info=True;Trusted_Connection=true;"
  }
```
Step 4: Change application arguments from **Properties > Debug > Application arguments**
```
-Table1 Table1Name -Table2 Table2Name -Primarykey PrimaryKeyName
```
Step 5:
Open, build and run the Solution MatchTables.sln in Visual Studio 2019

# Run From Cmd
Go to following directory and run the following command
```
cd ..\MatchTables\bin\Debug\netcoreapp3.1 path and run following command
MatchTables.exe -Table1 EmployeeOldTable -Table2 EmployeeNewTable -Primarykey SocialSecurityNumber
```
