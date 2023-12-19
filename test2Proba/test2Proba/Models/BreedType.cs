using System.ComponentModel.DataAnnotations;

namespace test2Proba.Models
{
    public class BreedType
    {
        [Key]
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
