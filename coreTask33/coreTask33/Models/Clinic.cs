using System;
using System.Collections.Generic;

namespace coreTask33.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicImg { get; set; }
        public string? ClinicDis { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
