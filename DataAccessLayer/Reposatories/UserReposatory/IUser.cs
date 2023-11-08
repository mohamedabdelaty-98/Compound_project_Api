using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.UserReposatory
{
    public interface IUser : IGenericReposatory<User>
    {
        public User GetById(String id);


    }
}
