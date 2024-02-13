using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface IUserDao
    {
        IList<User> GetUsers();
        User GetUserById(string id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string id);
  

    }
}
