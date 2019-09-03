using System.ComponentModel.DataAnnotations;

namespace Ecopetrol.Api.API.DataContracts
{
    public class FAQ
    {        
        public int Id { get; set; }
     
        public string Question { get; set; }

        public string answer { get; set; }

    }
}
