learning-mongo
==============

Getting started with MongoDB in C#


## Instructions
  1. Head over to [MongoHQ](http://mongohq.com) and sign up for an account, or create a new database.
  2. Configure the MongoConfig class in [Mongo.cs](https://github.com/vigilant/learning-mongo/blob/master/Vigilant.LearningMongo/Mongo.cs)

        public static class MongoConfig
        {
          public static readonly string CONNECTION_STRING_URI = "#PUT YOUR MONGOHQ CONNECTION STRING HERE";
          public static readonly string DATABASE_NAME = "#PUT YOUR DATABASE NAME HERE";
        }

  3. Place a breakpoint at the end of [Program.cs](https://github.com/vigilant/learning-mongo/blob/master/Vigilant.LearningMongo/Program.cs)
         
        Thread.Sleep(5);                 //Place a breakpoint on this line to inspect your query results

  4. Run the program and inspect your query results
