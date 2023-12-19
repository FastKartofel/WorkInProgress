using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2Proba.Models
{
    public class Volunteer
    {
        [Key]
        public int IdVolunteer { get; set; }
        public int? IdSupervisor { get; set; }
        public Volunteer Supervisor { get; set; }
        public List<Volunteer> Subordinates { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }

        public List<VolunteerPet> VolunteerPets { get; set; }
    }

}
