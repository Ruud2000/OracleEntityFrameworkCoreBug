# OracleEntityFrameworkCoreBug
This solution highlights the issue with Oracle.EntityFrameworkCore 8.23.40.

With version **8.21.140** a `.Any()` generates a SQL statement that returns a **0** or **1** like shown in the example below:

```
SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM "MY_USER"."CUSTOMERS" "c") THEN 1
          ELSE 0
      END FROM DUAL
```

With version **8.23.49** a `.Any()` generates a SQL statement that returns **True** or **False** like shown in the example below:

```
SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM "MY_USER"."CUSTOMERS" "c") THEN True
          ELSE False
      END FROM DUAL
```
