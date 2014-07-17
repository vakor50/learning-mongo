using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigilant.LearningMongo
{
    public static class SeedDatabase
    {
        public const int FILES_TO_CREATE = 25; //Make sure you create more FILES than UPLOADS
        public const int UPLOADS_TO_CREATE = 25;
        private static Random _random = new Random();

        public static void Seed(bool clearDB = false)
        {
            if(clearDB)
            {
                //clear the existing collection first
                Mongo.Database<FakeUpload>().Drop();
            }
            //Create some random files
            var fileList = new List<FakeFile>();
            for (int i = 0; i < FILES_TO_CREATE; i++)
            {
                var name = Convert.ToChar(i) + ".jpg";
                var size = _random.Next();
                var f = new FakeFile(name, size);
                fileList.Add(f);
            }

            //Create some random uploads, attaching some files
            var filesPerUpload = FILES_TO_CREATE / UPLOADS_TO_CREATE;
            var uploadList = new List<FakeUpload>();
            for (int i = 0; i < UPLOADS_TO_CREATE; i++)
            {
                var name = Convert.ToChar(i).ToString().ToUpper() + ", " + Convert.ToChar(i + 1).ToString().ToUpper();
                var u = new FakeUpload(name, fileList.Skip(filesPerUpload * i).Take(filesPerUpload));
                uploadList.Add(u);
            }

            //Add the uploads to the database
            Mongo.Database<FakeUpload>().InsertBatch(uploadList);
        }
    }
}
