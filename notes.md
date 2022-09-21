Using C# language stuff with classes and objects to get things from database.
We will not be writing SQL.
We will be writing Entity Frameworks like ORM:

O - object
R - relations
M - mapper

We will be writing C# to do this with calsses and methods. ORM changes these to relations in our tables. We write models or files, and database has tables that relate to other tables.
Entity framework translates our classes, our C# code into the tables and rows of data.

We will be making C# do the work.

Some javaScript packages are ORMs, but pg is super super simple and does a lot of work for us.
pg contains pool, and is not an ORM

A migration is a history and memory fo our changes. we will be using this with ORM.

If we want to add a column, we will do that inour C# classes, and ti will be translated into the database.
_______________________

Bakery will deal with 2 things, Bakers, and bread.
The database has a baker and bread table as well, a 1 to many relationship.

Our C# models will translate this to our tables.

The word "model" is a:

M - model
V - view
C - controllers

.NET MVC Core the framework that saves time to do routing and requesting, it follows the MCV pattern.

Models is our data. we will make classes for our bread and bakers, then we have ocntrollers, then the view. The pattern goes, we have some data, then we have someone who can view it, the controllers job is to make sure and controll which data can be seen at any given time, it is the gatekeeper. The request comes fromt he view, goes to the controller, and the controller follows instructions and gets data and gives it back to the view.

For now, models/classes are C#, controllers are C#, and the view will be Postman for now.

______________________

Lets go!

We must do something similar to npm install...
dotnet restore

Now, we only have to do this once for our entity framework for our entire computer: 
dotnet tool install --global dotnet-ef
Now, once again, dotnet restore.

(pg is specific to node since it is an npm package.)

We will make a database without a table. Remember we wrote connection settings in pool? now we do appsettings.json  which also has localhost and port and database! Change database if needed.

So lets make a model class describing a baker, this describes the column we want. check out the baker.cs

Migrations are version control.

1 set up a migration
2 execute the migration