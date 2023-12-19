using System.ComponentModel.DataAnnotations;

namespace test2Proba.Models
{
    public class VolunteerPet
    {
        [Key]
        public int IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        public int IdPet { get; set; }
        public Pet Pet { get; set; }

        public DateTime DateAccepted { get; set; }
    }
}
