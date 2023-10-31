using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class Context:IdentityDbContext<User>
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        public DbSet<Application> applications { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<CComponent> components { get; set; }
        public DbSet<Compound> compounds { get; set; }
        public DbSet<BuildingImage> BuildingImages { get; set; }
        public DbSet<CompoundImage> CompundImages { get; set; }
        public DbSet<Landmark> landmarks { get; set; }
        public DbSet<LandMarksCompound> landMarksCompounds { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<ServiceBuilding> serviceBuildings { get; set; }
        public DbSet<ServicesCompound> servicesCompounds { get; set; }
        public DbSet<ServiceUnit> serviceUnits { get; set; }
        public DbSet<Unit> units { get; set; }
        public DbSet<UnitComponent> unitComponents { get; set; }
        public DbSet<UnitImage> unitImages { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }
        public DbSet<WishlistUnit> wishlistUnits { get; set; }
    }
}
