using System.ComponentModel.DataAnnotations;

namespace Ecopetrol.Api.Services.Model
{
    public class FAQ
    {        
        public int Id { get; set; }
     
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

    }
}
