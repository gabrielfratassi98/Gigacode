using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigacode.Infra.Data.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
            
        }

        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
