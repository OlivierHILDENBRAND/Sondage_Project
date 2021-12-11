using Sondage_Project.Data.Models;
using Sondage_Project.Data.Repositories;
using Sondage_Project.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondage_Project.Services
{
    public class SondageService : ISondagesService
    {

        private readonly ISondageRepository _repo;
        public SondageService (ISondageRepository dbContext)
        {
            _repo = dbContext;
        }

        public async Task CreateSondageAsync(AddSondagesViewModel model)
        {

            var sondage = new Sondage()
            {
                Question = model.Question,
                Answer_1 = model.Answer_1,
                Answer_2 = model.Answer_2,
                Answer_3 = model.Answer_3,
                Answer_4 = model.Answer_4,
                IsActivated = true,
                MultipleAnswer = model.MultipleAnswer
            };


            await _repo.AddAsync(sondage);
        }

        public Task<List<SondagesIndexViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateSondagesViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
