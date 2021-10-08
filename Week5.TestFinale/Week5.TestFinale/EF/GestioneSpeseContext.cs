using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.TestFinale.EF.Configuration;
using Week5.TestFinale.Model;

namespace Week5.TestFinale.EF
{
    public class GestioneSpeseContext : DbContext
    {
        public DbSet<Spesa> Spesa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public GestioneSpeseContext() : base()
        {

        }

        public GestioneSpeseContext(DbContextOptions<GestioneSpeseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionStringSQL = config.GetConnectionString("AcademyG");
                optionsBuilder.UseSqlServer(connectionStringSQL);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpesaConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        }
    }
}
