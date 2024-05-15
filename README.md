# OracleEntityFrameworkCoreBug
After upgrading from Oracle.EntityFrameworkCore 8.21.140 to 8.23.40 queries in .NET Core using `.Any()` throw an exception ORA-00904: "FALSE": invalid identifier.

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

The solution contains 2 Web API projects, one executes a query using Oracle.EntityFrameworkCore 8.21.140 which is working as expected. The other Web API project uses version 8.23.40 and shows the ORA-00904 error is thrown.

You can use the dockerfile to create the Oracle database to test.
