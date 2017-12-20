using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoGazzola.Identity.Interface
{
    public interface IUserService
    {
        IUser GetById(string id);
        IUser GetByUser(string userName);
        IList<IUser> GetAll();
    }
}
