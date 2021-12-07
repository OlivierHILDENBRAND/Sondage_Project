using System;
using Sondage_Project.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Sondage_Project.Data.Models;

namespace Sondage_Project.Data.Repositories
{
    public class SondageRepository : ISondageRepository
    {

        private readonly ApplicationDbContext _context;


        public SondageRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public Task AddAsync(Sondage sondage)
        {
            throw new NotImplementedException();
        }

        
    }
}
