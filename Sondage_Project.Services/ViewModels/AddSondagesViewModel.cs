using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sondage_Project.Services.ViewModels
{
    public class AddSondagesViewModel
    {
        [Required]
        [Display(Name ="Type your question here")]
        [StringLength(5000, MinimumLength = 10)]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Type your first answer here")]
        [StringLength(5000, MinimumLength = 10)]
        public string Answer_1 { get; set; }

        [Display(Name = "Type your second answer here")]
        [StringLength(5000, MinimumLength = 10)]
        public string Answer_2 { get; set; }

        [Display(Name = "Type your third answer here")]
        [StringLength(5000, MinimumLength = 10)]
        public string Answer_3 { get; set; }

        [Display(Name = "Type your fourth answer here")]
        [StringLength(5000, MinimumLength = 10)]
        public string Answer_4 { get; set; }

        [Required]
        public bool IsActivated { get; set; }

        [Required]
        [Display(Name = "Enable multiple answer")]
        public bool MultipleAnswer { get; set; }
    }
}