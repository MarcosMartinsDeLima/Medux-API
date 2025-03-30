using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medux.Domain.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Medux.Infra.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToCollection("usuarios");
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
