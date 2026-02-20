using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PetPackApi.Models
{
    public class Pack
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        [ValidateNever]
        public Owner Owner { get; set; }

        public List<Pet> Pets { get; set; } = new();
    }
}