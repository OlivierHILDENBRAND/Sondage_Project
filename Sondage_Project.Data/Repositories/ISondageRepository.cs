using Sondage_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondage_Project.Data.Repositories
{
    public interface ISondageRepository
    {

        Task<List<Sondage>> GetAllAsync();

        Task<Sondage> GetSondageAsync(int id);

        Task AddAsync(Sondage sondage);

        Task DisableAsync(int id);

        Task AnswerAsync(Sondage sondage);

        

    }
}
