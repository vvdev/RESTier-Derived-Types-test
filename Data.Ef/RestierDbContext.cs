using Data.Ef;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Ef
{
    public class RestierDbContext : DbContext
    {
        public DbSet<HierarchyRoot> TablePerHierarchyEntitySet { get; set; }
    }
}
