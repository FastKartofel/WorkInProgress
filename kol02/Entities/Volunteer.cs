namespace kol2.Entities;

public class Volunteer
{
    public int IdVolunteer { get; set; }
    public int? IdSupervisor { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public DateTime StartingDate { get; set; }

    public virtual ICollection<VolunteerPet> VolunteerPets { get; set; }
    public virtual Volunteer Supervisor { get; set; }
    public virtual  ICollection<Volunteer> Volunteers { get; set; }
}