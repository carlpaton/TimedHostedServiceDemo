# Timed Hosted Service

Code for blog post - https://carlpaton.github.io/2021/07/c-sharp-timed-hosted-service/

## Usage

At a high level:

1. [Run the MySQL Database instance and provision it with the sql scripts.](https://github.com/carlpaton/TimedHostedServiceDemo/tree/master/infrastructure/db)
2. [Run the JSON Server API, it has a pre-defined `db.json`](https://github.com/carlpaton/TimedHostedServiceDemo/tree/master/infrastructure/api)
3. [Run the hosted service](https://github.com/carlpaton/TimedHostedServiceDemo/tree/master/src/01-simple)

To re-run delete `watermark.ini`