using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Resources;

namespace XinYiAPI.Models
{
    [BsonIgnoreExtraElements]
    public class SecCate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string secLevelCode { get; set; }
        public string name { get; set; }
       
    }
}
