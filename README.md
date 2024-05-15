# Issue
After upgrading from Oracle.EntityFrameworkCore **8.21.140** to **8.23.40** queries in .NET Core using `.Any()` throw an exception ORA-00904: "FALSE": invalid identifier.

# Root cause:
By default package version 8.23.40 assumes version 23 since it's ODP.NET 23. Oracle DB 23ai supports Boolean table columns. Since we use DB 21c XE, we need to set OracleSQLCompatibility to 21 to tell ODP.NET to use numeric values instead of Booleans. See https://github.com/oracle/dotnet-db-samples/issues/380

## Analysis
With version **8.21.140** a `.Any()` generates a SQL statement that returns a **0** or **1** like shown in the example below:

```csharp
    if (context.Customers.Any())
    {
        return "We have customers!";
    }
    else
    {
        return "We have no customers!";
    }
```

```sql
SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM "MY_USER"."CUSTOMERS" "c") THEN 1
          ELSE 0
      END FROM DUAL
```

With version **8.23.40** a `.Any()` generates a SQL statement that returns **True** or **False** like shown in the example below:

```sql
SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM "MY_USER"."CUSTOMERS" "c") THEN True
          ELSE False
      END FROM DUAL
```

The solution contains 2 Web API projects, one executes an `.Any()` query using Oracle.EntityFrameworkCore **8.21.140** which is working as expected. The other Web API project uses version **8.23.40** and shows the ORA-00904 error is thrown if you change the compatibility mode to `OracleSQLCompatibility.DatabaseVersion23`. The current version in this code repository already contains the fix where the compatibility mode is set to DatabaseVersion21.

You can use the dockerfile to create the Oracle database to test.
