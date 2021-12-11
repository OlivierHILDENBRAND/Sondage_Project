using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sondage_Project.Services.ViewModels
{
    public class UpdateSondagesViewModel
    {
        public int Counter_1 { get; set; }

        public int Counter_2 { get; set; }

        public int Counter_3 { get; set; }

        public int Counter_4 { get; set; }
    }
}