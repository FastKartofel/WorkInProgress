namespace test2Proba.DTOs
{
    public class PetDto
    {
        public int IdPet { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApproximateDateOfBirth { get; set; }
        public string BreedName { get; set; }
        public List<VolunteerDto> Volunteers { get; set; }
    }
}
