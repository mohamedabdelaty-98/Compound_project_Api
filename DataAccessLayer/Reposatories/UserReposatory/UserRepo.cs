using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.UserReposatory
{
    public class UserRepo : GenericReposatory<User>, IUser
    {
        private readonly Context _context;

        public UserRepo(Context context) : base(context)
        {
            _context = context;
        }
        public User GetById(String id)
        {
            return _context.Users.Find(id);
        }

    }
    
    
        
    
}
