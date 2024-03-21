namespace Zadanie8.models;

public class Prescription_Medicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
    public virtual Medicament IdMedicamentNavigation { get; set; } = null!;
    public virtual Prescription IdPrescriptionNavigation { get; set; } = null!;
}