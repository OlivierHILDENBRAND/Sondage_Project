using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Sondage_Project.Data.Models
{
    public class Sondage
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(5000)]
        public string Descriptif { get; set; }


        [Required]
        [StringLength(5000)]
        public string Question_1 { get; set; }


        [StringLength(5000)]
        public string Question_2 { get; set; }


        [StringLength(5000)]
        public string Question_3 { get; set; }


        [StringLength(5000)]
        public string Question_4 { get; set; }


        [Required]
        [DefaultValue(0)]
        public int counter_1 { get; set; }


        [DefaultValue(0)]
        public int counter_2 { get; set; }


        [DefaultValue(0)]
        public int counter_3 { get; set; }


        [DefaultValue(0)]
        public int counter_4 { get; set; }


        [DefaultValue(true)]
        public bool IsActivated { get; set; }


        [DefaultValue(false)]
        public bool MultipleAnswer { get; set; }

    }

   
}
