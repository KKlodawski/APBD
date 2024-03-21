namespace Zadanie9.DTO;

public class PresFind
{
    public string DoctorFirstName { get; set; }
    public string DoctorLastName { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public ICollection<string> Medicament { get; set; }
}