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

        Task AddAsync(Sondage sondage);

        

    }
}
