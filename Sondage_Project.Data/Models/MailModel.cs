using System.ComponentModel.DataAnnotations;

namespace Sondage_Project.Data.Models
{
    public class MailModel
    {
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
        
    }
}
