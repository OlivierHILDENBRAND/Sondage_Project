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

        public async Task<List<SondagesIndexViewModel>> GetAllAsync()
        {
            var sondages = await _repo.GetAllAsync();

            var enumerable = sondages.Select(item => new SondagesIndexViewModel()
            {
                SondageId = item.SondageId,
                Questions = item.Question,
                Answer_1 = item.Answer_1,
                Answer_2 = item.Answer_2,
                Answer_3 = item.Answer_3,
                Answer_4 = item.Answer_4,
                Counter_1 = item.Counter_1,
                Counter_2 = item.Counter_2,
                Counter_3 = item.Counter_3,
                Counter_4 = item.Counter_4,
            });

            return enumerable.ToList();
        }

        public Task<UpdateSondagesViewModel> GetAsync(int id)
        {   
            throw new NotImplementedException();
        }
    }
}
