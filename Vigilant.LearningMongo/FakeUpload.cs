using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vigilant.LearningMongo
{
    class FakeUpload
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FakeFile> Files { get; set; }
        public DateTime CreatedAt { get; set; }

        public FakeUpload()
        {

        }

        public FakeUpload(string name)
        {
            this.Id = ObjectId.GenerateNewId();
            this.Name = name;
            this.Files = new List<FakeFile>();
            this.CreatedAt = DateTime.UtcNow;
        }

        public FakeUpload(string name, IEnumerable<FakeFile> files) : this(name)
        {
            this.Files = files;
        }
    }
}
