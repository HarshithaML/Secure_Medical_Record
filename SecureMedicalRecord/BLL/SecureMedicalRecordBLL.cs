using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SecureMedicalRecord.BLL
{
    public class SecureMedicalRecordBLL
    {
        SecureMedicalRecord.DAL.SecureMedicalRecordDAL objSecureMedicalRecordDAL = null;

        public string LoginVerification(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.LoginVerify(objSecureMedicalRecordDTO);
        }
        public int CreateDept(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.CreateDept(objSecureMedicalRecordDTO);
        }
        public int AddHospital(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.AddHospital(objSecureMedicalRecordDTO);
        }
        public DataTable GetDeptDetails()
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDeptDetails();
        }
        public int UploadMedicalRecord(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.UploadMedicalRecord(objSecureMedicalRecordDTO);
        }
        public int AddDoctor(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.AddDoctor(objSecureMedicalRecordDTO);
        }
        public DataTable GetDoctor()
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDoctor();
        }
        public DataTable GetDoctor_HId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDoctor_HId(objSecureMedicalRecordDTO);
        }
        public int DoctorTimings(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.DoctorTimings(objSecureMedicalRecordDTO);
        }
        public DataTable GetGeneralMedicalRecord_DoctorId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetGeneralMedicalRecord_DoctorId(objSecureMedicalRecordDTO);
        }
        public int DoctorReq_RDA(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.DoctorReq_RDA(objSecureMedicalRecordDTO);
        }
        public DataTable GetDoctor_BS_AMRR(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDoctor_BS_AMRR(objSecureMedicalRecordDTO);
        }
        public int DoctorReq_RDA_Approve(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.DoctorReq_RDA_Approve(objSecureMedicalRecordDTO);
        }
        public int DoctorReq_RDA_Reject(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.DoctorReq_RDA_Reject(objSecureMedicalRecordDTO);
        }
        public DataTable GetMedicalRecordA_ViewData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetMedicalRecordA_ViewData(objSecureMedicalRecordDTO);
        }
        public string CreatePatient(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.CreatePatient(objSecureMedicalRecordDTO);
        }
        public string CreatePatientClinical(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.CreatePatientClinical(objSecureMedicalRecordDTO);
        }
        public string PatientTreatment(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.PatientTreatment(objSecureMedicalRecordDTO);
        }
        public DataTable GetPatient_MD(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetPatient_MD(objSecureMedicalRecordDTO);
        }
        public DataTable GetPatient_PHD(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetPatient_PHD(objSecureMedicalRecordDTO);
        }
        public DataTable GetPatientDetails_Consult(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetPatientDetails_Consult(objSecureMedicalRecordDTO);
        }
        public int UploadDoctorMedicalRecord(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.UploadDoctorMedicalRecord(objSecureMedicalRecordDTO);
        }
        public DataTable GetDoctorMedicalRecord_DoctorId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDoctorMedicalRecord_DoctorId(objSecureMedicalRecordDTO);
        }
        public int DoctorReq_DoctorMData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.DoctorReq_DoctorMData(objSecureMedicalRecordDTO);
        }
        public DataTable Approve_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.Approve_DoctorData(objSecureMedicalRecordDTO);
        }
        public int UpdateApprove_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.UpdateApprove_DoctorData(objSecureMedicalRecordDTO);
        }
        public int Reject_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.Reject_DoctorData(objSecureMedicalRecordDTO);
        }
        public DataTable GetDoctorData_Approved(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.GetDoctorData_Approved(objSecureMedicalRecordDTO);
        }
        public string ChangePassword(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO)
        {
            objSecureMedicalRecordDAL = new DAL.SecureMedicalRecordDAL();
            return objSecureMedicalRecordDAL.ChangePassword(objSecureMedicalRecordDTO);
        }
    }
}