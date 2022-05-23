# API Project-Crypto Tracker Api, Organizer


What I built was an API that is a mock Crypto Watchlist. In our API we can, get all coins, get coins by id, get all categories, get categories by ID, get by symbol. Add new coins, add new categories and could 
also delete the respective properties as well. For now , our API only works on a very basic level, where users are only able to enter mock date for each section mentioned.
What I intended to do was integrate another API that gets continously sends realtime information on our currencies, and make our API do its job.
But our API works great with our mock data!


//Command to run 
Scaffold-DbContext 'server=localhost; port=3306; database=CRYPTODATABASE; user=root; password=password; Persist Security Info=False; Connect Timeout=300' Pomelo.EntityFrameworkCore.MySql -OutputDir Model -force
```

```sh
- GetAll Crypto Currency
This API is used to retrieve all crypto currency with there categories.
- Get CryptoCurrency by Symbol
This API is used to retrieve crypto currency with specific symbol.
- GetAPI category by list
This API is used to retrieve cryptro currency by list

-
- Add new Crypto Currency
This API Used to Add new crypto currency.
 

Postman collection. https://lively-capsule-531997.postman.co/workspace/New-Team-Workspace~64b97ed5-baf9-40d7-b603-5f9082506601/request/20683806-8305d50f-d4d1-4bab-9fe5-7e32448af351