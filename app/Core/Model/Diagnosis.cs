using app.Core.Model;
using System;
using System.Collections.Generic;

namespace app.core.model
{
    /// <summary>
    /// Represents a patient's consultation diagnosis, including vital signs, findings, and treatment plan.
    /// </summary>
    public class Diagnosis
    {
            public int Id { get; set; } = 0;
            public int Patient { get; set; }
            public Client Client { get; set; }
            public Pet PatientPet { get; set; }
            public string Weight { get; set; }
            public string BloodPressure { get; set; }
            public string HeartRate { get; set; }
            public string Temperature { get; set; }
            public string Complaint { get; set; }
            public string Findings { get; set; }
            public string PlanTreatment { get; set; }
            public DateTime ConsultDate { get; set; } = DateTime.Now;
            public DateTime? FollowUpDate { get; set; }

            public List<MedicationWithFrequency> MedicationsWithFrequency { get; set; } = new List<MedicationWithFrequency>();

            public double Price { get; set; } = 200; // Default consultation fee
    }

        public class MedicationWithFrequency
        {
            public int MedicineId { get; set; }
            public string MedicineDescription { get; set; }
            public string DaysIntake { get; set; }
            public string Frequency { get; set; }
            public string Notes { get; set; } // Used for 'Other' notes

        }
    }

