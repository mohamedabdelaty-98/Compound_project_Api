using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class ApplicationRepo : GenericReposatory<Application>, IApplication
  {
    private readonly Context context;
    public ApplicationRepo(Context context) : base(context)
    {
      this.context = context;

    }

        public List<Application> GetApplicationsByUserId(string userid)
        {
            return context.applications.Where(a => a.UserId == userid).ToList();
        }
    }
}
