using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigilant.LearningMongo
{
    public class FakeFile
    {
        public string FileName { get; set; }
        public long SizeBytes { get; set; }
        public DateTime CreatedAt { get; set; }

        public FakeFile()
        {

        }

        public FakeFile(string fileName, long sizeBytes)
        {
            this.FileName = fileName;
            this.SizeBytes = sizeBytes;
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
