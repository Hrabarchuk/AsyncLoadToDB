using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dl.Model;

namespace Dl.Implementations
{
    public class EFContext : DbContext
    {

        public EFContext() : base("MSSql")
        {

        }

        public DbSet<Good> Goods { get; set; }
    }
}
