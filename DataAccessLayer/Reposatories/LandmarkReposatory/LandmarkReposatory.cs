using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.LandmarkReposatory
{
    public class LandmarkReposatory : GenericReposatory<Landmark>, ILandmarkReposatory
    {
        private readonly Context context;

        public LandmarkReposatory(Context context) : base(context)
        {
            this.context = context;
        }

        public Landmark GetLandmarkByName(string name)
        {
            return context.landmarks.FirstOrDefault(l => l.Name.ToLower() == name.ToLower());
        }
    }
}
