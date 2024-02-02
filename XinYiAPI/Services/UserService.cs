using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using XinYiAPI.DataAccess.Base;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Eneities;

namespace XinYiAPI.Services
{

    public class UserService : IUserDao
    {
        private AlanContext alanContext;
        public UserService(AlanContext _alanContext)
        {
            this.alanContext = _alanContext;
        }
        public bool CreateUser(User user)
        {
            alanContext.users.Add(user);
            return alanContext.SaveChanges() > 0;
        }

        public bool DeleteUser(string id)
        {
            alanContext.users.Remove(alanContext.users.Find(id));
            return alanContext.SaveChanges() > 0;
        }

        public User GetUserById(string id)
        {
            alanContext.users.Find(id);
            return alanContext.users.Find(id);
        }

        public IList<User> GetUsers()
        {
            return alanContext.users.ToList();
        }
        public bool UpdateUser(User user)
        {
            alanContext.users.Update(user);
            return alanContext.SaveChanges() > 0;
        }
        public User GetUserByName(string username)
        {
           return alanContext.users.Where(item => item.username == username).FirstOrDefault();
        }
    }
}
