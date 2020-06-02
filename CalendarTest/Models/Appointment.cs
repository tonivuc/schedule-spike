using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarTest.Models
{
    class Appointment
    {

        public Appointment(string patientName, DateTime from, DateTime to)
        {
            PatientName = patientName;
            StartTime = from;
            EndTime = to;
        }

        public string PatientName { get; set; }

        public string Type { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public string EncounterReason { get; set; }

        public string Status { get; set; }

        public string ContactType { get; set; }

        public string DiagnosisGroup { get; set; }

        public string TentativeDiagnosis { get; set; }

        public string HealthIssue { get; set; }

        public string LevelOfCare { get; set; }

        public string ReferralReason { get; set; }

        public bool HasReadAccess { get; set; }
    }
}
