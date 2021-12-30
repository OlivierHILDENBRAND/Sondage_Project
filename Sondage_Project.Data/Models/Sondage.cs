using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sondage_Project.Data.Models
{
    public class Sondage
    {
        [Key]
        public int SondageId { get; set; }
        
        
        [Required]
        [StringLength(5000)]
        public string Question { get; set; }


        [Required]
        [StringLength(5000)]
        public string Answer_1 { get; set; }


        [StringLength(5000)]
        public string Answer_2 { get; set; }


        [StringLength(5000)]
        public string Answer_3 { get; set; }


        [StringLength(5000)]
        public string Answer_4 { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Counter_1 { get; set; }


        [DefaultValue(0)]
        public int Counter_2 { get; set; }


        [DefaultValue(0)]
        public int Counter_3 { get; set; }


        [DefaultValue(0)]
        public int Counter_4 { get; set; }


        [DefaultValue(false)]
        public bool answer1check { get; set; }

        [DefaultValue(false)]
        public bool answer2check { get; set; }

        [DefaultValue(false)]
        public bool answer3check { get; set; }

        [DefaultValue(false)]
        public bool answer4check { get; set; }

        
        [DefaultValue(true)]
        public bool IsActivated { get; set; }


        [DefaultValue(false)]
        public bool MultipleAnswer { get; set; }

    }

   
}
