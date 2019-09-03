using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecopetrol.Api.Data.Models
{
    [Table("Faq")]
    public class Faq
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string Question { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string Answer { get; set; }
    }
}
