using System;
using System.ComponentModel.DataAnnotations;

namespace PetPackApi.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Color { get; set; }

        public string Breed { get; set; }

        public double Weight { get; set; }

        public int PackId { get; set; }
        public Pack Pack { get; set; }
    }
}