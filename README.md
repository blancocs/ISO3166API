# ISO3166API
API for iso3166

after download. you can run the migration package, or you run the API. there is a class, called "dbIntializer", inside "DBUtilities" folder, called on program startup, wich
executes dbcontext.database.EnsureCreated() Method, if DB  exits, no action is taken, otherwise, database and all its schema are created.

after creation, looks for any country in table. if table's empty, will populate with 12 countrys and states.

