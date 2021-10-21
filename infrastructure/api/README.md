# JSON Server

1. Install

```
npm uninstall -g json-server --save     // remove global if you dont want to use npx
npm install --save-dev json-server      // I dont think this is actually needed if you using npx instead of npm
```

2. Create `db.json`

- [The JSON data is in this post](https://carlpaton.github.io/2021/07/c-sharp-timed-hosted-service/).

3. Create run.ps1

```ps1
npx json-server db-workerprocess.json -p 3331 --delay 1500
```

4. Finally run .\run.ps1 from powershell and access the endpoint

- http://localhost:3331
- http://localhost:3331/db

5. JSON Server operators

When calling out to the server use `id_gte=42` to where

- `id` is a columns primary key
- `gte` is greater than and equal to
- `42` is the watermark, so we want all rows from this table where `id >= 42`

```js
const axios = require('axios');

axios.get('http://localhost:3000/users?id_gte=4')
    .then(resp => {
        console.log(resp.data)
    }).catch(error => {
        console.log(error);
    }); 
```

- https://github.com/typicode/json-server/
- https://zetcode.com/javascript/jsonserver/