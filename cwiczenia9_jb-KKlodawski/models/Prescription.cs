namespace Zadanie9.models;

public class Prescription
{
    public int IdPresscription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateDue { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; } = null!;
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; } = null!;
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; } = null!;
}