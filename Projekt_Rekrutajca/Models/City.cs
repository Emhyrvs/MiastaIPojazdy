using System.ComponentModel.DataAnnotations;

namespace Projekt_Rekrutajca.Models
{
    public class City
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Population { get; set; }
    }
}
