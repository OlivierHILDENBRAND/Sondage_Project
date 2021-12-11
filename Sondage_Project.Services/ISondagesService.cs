using Sondage_Project.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondage_Project.Services
{
    public interface ISondagesService
    {
        Task<List<SondagesIndexViewModel>> GetAllAsync();
        Task CreateSondageAsync(AddSondagesViewModel model);
    }
}
