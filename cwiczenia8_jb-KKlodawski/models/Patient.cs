namespace Zadanie8.models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthdate { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;

}