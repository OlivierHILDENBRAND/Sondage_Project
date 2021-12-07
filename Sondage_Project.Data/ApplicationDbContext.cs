using Microsoft.EntityFrameworkCore;
using Sondage_Project.Data.Models;
using System;

namespace Sondage_Project.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Sondage> Sondages { get; set; }


        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}