using System;
using System.Collections.Generic;

namespace Zadanie7.Models;

public partial class Prescription
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public int MedicineId { get; set; }

    public int Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
