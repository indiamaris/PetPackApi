using System.ComponentModel.DataAnnotations;

namespace PetPackApi.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Pack Pack { get; set; }
    }
}