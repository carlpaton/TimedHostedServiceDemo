# Database

We could probably use docker compose to orchestrate setting up this database but this code was more about the Hosted Service.

1. Create the instance

```
docker run --name=mysql-timed-hosted-service -e MYSQL_ROOT_PASSWORD=root -d -p 3301:3306  mysql:8.0.26
```

2. Connect to the instance with any database manager like [DBeaver](https://dbeaver.io/) or [MySQL Workbench](https://www.mysql.com/products/workbench/)

3. Run the sql scripts in order

Schema

- [v1.0.0_schema.sql](v1.0.0_schema.sql)

Tables

- [v1.0.1_cart.sql](v1.0.1_cart.sql)
- [v1.0.2_cart_item.sql](v1.0.2_cart_item.sql)

Stored Procedures

- [v1.1.0_cart_stored_procs.sql](v1.1.0_cart_stored_procs.sql)
- [v1.1.1_cart_item_stored_procs.sql](v1.1.1_cart_item_stored_procs.sql)