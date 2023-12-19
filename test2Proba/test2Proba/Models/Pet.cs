using System.ComponentModel.DataAnnotations;

namespace test2Proba.Models
{
    public class Pet
    {
        [Key]
        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public BreedType BreedType { get; set; }

        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApproximateDateOfBirth { get; set; }
        public DateTime DateAdopted { get; set; }

        public List<VolunteerPet> VolunteerPets { get; set; }
    }

}
