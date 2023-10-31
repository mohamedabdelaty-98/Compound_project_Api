using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
  public interface IApplication : IGenericReposatory<Application>
  {
        public List<Application> GetApplicationsByUserId(string userid);  
  }
}
