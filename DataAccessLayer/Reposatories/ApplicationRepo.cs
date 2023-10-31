using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
  public class ApplicationRepo : CrudOperation<Application>, IApplication
  {
    private readonly Context context;
    public ApplicationRepo(Context context) : base(context)
    {
      this.context = context;

    }
  }
}
