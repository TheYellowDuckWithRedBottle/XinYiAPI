using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;

namespace XinYiAPI.Services
{
    public class LandSpaceService
    {
       
            private readonly IMongoCollection<LandSpace> _LandSpace;
            public LandSpaceService()
            {

                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("XinYiDB");
                _LandSpace = database.GetCollection<LandSpace>("landSpace");
            }
            public List<LandSpace> GetAll() =>
                 _LandSpace.Find(item => true).ToList();
        public List<LandSpace> GetByVillageName(string villageName) => 
            _LandSpace.Find(item => item.ZLDWMC == villageName).ToList();
        
    }
}
