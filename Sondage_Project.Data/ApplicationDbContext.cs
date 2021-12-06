using Microsoft.EntityFrameworkCore;
using System;

namespace Sondage_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}