using System;
using System.Collections.Generic;

namespace Zadanie7.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int SpecializationId { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Specialization Specialization { get; set; } = null!;
}
