using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureMedicalRecord.DTO
{
    public class SecureMedicalRecordDTO
    {
        public Int64 UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Description { get; set; }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }

        public int RecordId { get; set; }
        public string RecordName { get; set; }
        public string RecordData { get; set; }
        public string AccessType { get; set; }
        public string DataKey { get; set; }
        public string FilePath { get; set; }
        
        public string AccessKey { get; set; }
        public int ReqId { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }

        public string DurationTimings { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Reason { get; set; }

        public string MedicalHistory { get; set; }
        public string PatientAllergies { get; set; }
        public string SocialHistory { get; set; }

        public string TDate { get; set; }
        public string ProblemTitle { get; set; }

        public int DRecordId { get; set; }
        public int RDDId { get; set; }
    }
}