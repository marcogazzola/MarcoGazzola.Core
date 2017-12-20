using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoGazzola.Identity.Interface
{
    public class UserService : IUserService
    {
        public UserService(string connectionString) { }
        public IList<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IUser GetByUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
