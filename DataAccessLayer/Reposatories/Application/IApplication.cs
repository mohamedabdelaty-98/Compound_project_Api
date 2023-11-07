using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IApplication : IGenericReposatory<Application>
  {
        public List<Application> GetApplicationsByUserId(string userid);  
  }
}
