using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;

namespace Vigilant.LearningMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start by seeding the database
            SeedDatabase.Seed(true);

            //Now you can practice queries

            //This returns the first five Uploads, sorted by Name descending
            var uploadsSortedByNameDescending = Mongo.Database<FakeUpload>()    //Search in the FakeUpload Collection
                .FindAll()                                                      //Doesn't filter the results
                .SetSortOrder(SortBy.Descending("Name"))                        //Tells DB to sort results by the Name field, descending
                .SetSkip(0)                                                     //Start at the beginning of the list, don't skip any items
                .SetLimit(5)                                                    //Limit the results to 5
                .ToList();                                                      //Initiate the query. Usually this isn't done, to allow for Delayed Execution/Lazy Loading

            //This returns all the uploads with a FakeFile.FileName 'a.jpg'
            var uploadsWithFileNameContainingA = Mongo.Database<FakeUpload>()   //Search in the FakeUpload Collection
                .Find(Query.ElemMatch("Files", Query.EQ("FileName", "a.jpg")))  //Return FakeUploads where Files.FileName == "a.jpg"
                .ToList();                                                      //Initiate the query.


            //Write your own queries here.


            Thread.Sleep(5);                                    //Place a breakpoint on this line to inspect your query results
        }
    }
}
