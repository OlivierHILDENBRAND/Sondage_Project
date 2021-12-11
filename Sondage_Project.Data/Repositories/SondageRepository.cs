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

        public async Task AddAsync(Sondage sondage)
        {
            if(sondage == null)
            {
                throw new ArgumentNullException(nameof(sondage));
            }
            await _context.AddAsync(sondage);
            await _context.SaveChangesAsync();
            //test branch data;
        }

        public Task AnswerAsync(Sondage sondage)
        {
            throw new NotImplementedException();
        }

        public Task DisableAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sondage>> GetAllAsync()
        {
            return await _context.Sondages
                .ToListAsync();
            //throw new NotImplementedException();
        }

        public Task<Sondage> GetSondageAsync(int id)
           => _context.Sondages.FirstOrDefaultAsync(s => s.Id == id);
            //throw new NotImplementedException();
        
    }
}
