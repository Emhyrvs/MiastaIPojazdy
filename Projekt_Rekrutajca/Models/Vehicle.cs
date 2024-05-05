using System.ComponentModel.DataAnnotations;

namespace Projekt_Rekrutajca.Models
{
    public class Vehicle
    {
        [Required]
        public int Min_Population { get; set; }
        [Required]
        public int Max_Population { get; set; }
        [Required]
        public string Vehicle_Name { get; set;}
    }
    
}
