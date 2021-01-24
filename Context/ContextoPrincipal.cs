using FormSigmaDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Context
{
    public class ContextoPrincipal : DbContext
    {
        public ContextoPrincipal(DbContextOptions<ContextoPrincipal> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Contacts> Contacts { get; set; }
    }
}
