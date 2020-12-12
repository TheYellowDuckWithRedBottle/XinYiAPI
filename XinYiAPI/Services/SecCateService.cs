using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;

namespace XinYiAPI.Services
{
    public class SecCateService
    {
        private readonly IMongoCollection<SecCate> _SecCate;
        public SecCateService()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("XinYiDB");
            _SecCate = database.GetCollection<SecCate>("secCate");
        }
        public List<SecCate> GetAll()
        {
           return  _SecCate.Find(item => true).ToList();
        }
        public SecCate GetNameByCode(string code)
        {
            return _SecCate.Find(item => item.secLevelCode == code).FirstOrDefault();
        }
    }
}
