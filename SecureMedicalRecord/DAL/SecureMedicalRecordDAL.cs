using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using ZXing;
using System.IO;

namespace SecureMedicalRecord.DAL
{
    public class SecureMedicalRecordDAL
    {
       

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public string conn_string = "server=localhost;user id=root;database=be57;port=3306;";
        public SecureMedicalRecordDAL()
        {
            con = new MySqlConnection(conn_string);
            con.Open();
        }
        public string LoginVerify(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "Admin")
            {
                sql = string.Format("Select count(*) from adminmaster where AdminId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            else if (objDTO.UserType == "Receptionist")
            {
                sql = string.Format("Select count(*) from hospitalmaster where HospitalId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            else if (objDTO.UserType == "Doctor")
            {
                sql = string.Format("Select count(*) from doctormaster where DoctorId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            else if (objDTO.UserType == "Patient")
            {
                sql = string.Format("Select count(*) from patientmaster where PatientId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            con.Close();
            return result;
        }
        public int CreateDept(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from departmentmaster where DeptName='{0}'", objDTO.DeptName);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            int res = 0;
            if (cnt == 0)
            {
                string sql = string.Format("insert into departmentmaster(DeptName,Description)values('{0}','{1}')", objDTO.DeptName, objDTO.Description);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res;
        }
        public int AddHospital(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from hospitalmaster where HospitalName='{0}'", objDTO.HospitalName);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            int res = 0;
            if (cnt == 0)
            {
                string sql = string.Format("insert into hospitalmaster(HospitalId,HospitalName,Password,ContactPerson,ContactNo,Address)values({0},'{1}','{2}','{3}','{4}','{5}')",objDTO.HospitalId, objDTO.HospitalName, objDTO.Password, objDTO.ContactPerson, objDTO.ContactNo, objDTO.Address);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res;
        }
        public DataTable GetDeptDetails()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from departmentmaster");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public int UploadMedicalRecord(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from recordmaster where RecordName='{0}'", objDTO.RecordName);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            int res = 0;
            if (cnt == 0)
            {
                
                string sql = string.Format("insert into recordmaster(DeptId,RecordName,AccessType,RecordPath,DataKey)values({0},'{1}','{2}','{3}','{4}')", objDTO.DeptId, objDTO.RecordName, objDTO.AccessType, objDTO.FilePath, objDTO.DataKey);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res;
        }
        public int AddDoctor(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("insert into doctormaster(DoctorId,DeptId,DoctorName,Password,Type,MobileNo,EmailId,Address,Status)values({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','Active')", objDTO.DoctorId, objDTO.DeptId, objDTO.DoctorName, objDTO.Password, "Normal", objDTO.MobileNo, objDTO.EmailId, objDTO.Address);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataTable GetDoctor()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from doctormaster");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public DataTable GetDoctor_HId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select doctormaster.DoctorName,doctormaster.DoctorId from doctormaster inner join mapdoctorhospital on doctormaster.DoctorId=mapdoctorhospital.DoctorId where mapdoctorhospital.HospitalId={0}",objDTO.HospitalId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public int DoctorTimings(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from mapdoctorhospital where DoctorId={0}", objDTO.DoctorId);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            int res = 0;
            if (cnt == 0)
            {
                string sql = string.Format("insert into mapdoctorhospital(DoctorId,HospitalId,DurationTimings)values({0},{1},'{2}')", objDTO.DoctorId, objDTO.HospitalId, objDTO.DurationTimings);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res;
        }
        public DataTable GetGeneralMedicalRecord_DoctorId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select doctormaster.DeptId,mapdoctorhospital.HospitalId from doctormaster Inner Join mapdoctorhospital on doctormaster.DoctorId=mapdoctorhospital.DoctorId where doctormaster.DoctorId={0}", objDTO.DoctorId);
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            string rdsql = string.Format("select RecordId, RecordName,RecordPath,DataKey from recordmaster where DeptId={0} and AccessType='{1}'", int.Parse(buffer.Rows[0]["DeptId"].ToString()), objDTO.AccessType);
            MySqlDataAdapter adapRD = new MySqlDataAdapter(rdsql, con);
            DataTable bufferRD = new DataTable();
            adapRD.Fill(bufferRD);
            con.Close();
            return bufferRD;
        }
        public int DoctorReq_RDA(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("insert into recordrequest(RecordId,DoctorId,Status)values({0},{1},'Pending')", objDTO.RecordId, objDTO.DoctorId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataTable GetDoctor_BS_AMRR(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select doctormaster.DoctorName,doctormaster.EmailId,recordmaster.RecordName,recordrequest.ReqId from recordmaster Inner Join recordrequest on recordmaster.RecordId=recordrequest.RecordId Inner Join doctormaster on doctormaster.DoctorId=recordrequest.DoctorId Inner Join mapdoctorhospital on mapdoctorhospital.DoctorId=recordrequest.DoctorId where recordmaster.DeptId={0} and recordrequest.Status='Pending'", objDTO.DeptId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public int DoctorReq_RDA_Approve(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update recordrequest set AccessKey='{0}',Status='Accept' where ReqId={1}", objDTO.AccessKey, objDTO.ReqId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DoctorReq_RDA_Reject(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update recordrequest set AccessKey='{0}',Status='Reject' where ReqId={1}", objDTO.AccessKey, objDTO.ReqId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataTable GetMedicalRecordA_ViewData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select recordmaster.RecordName,recordrequest.AccessKey,recordmaster.RecordPath,recordmaster.DataKey from recordmaster Inner Join recordrequest on recordmaster.RecordId=recordrequest.RecordId where recordrequest.DoctorId={0} and recordrequest.Status='Accept'", objDTO.DoctorId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public string CreatePatient(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into patientmaster(Patientid,Name,Password,Gender,Age,Reason,MobileNo,Address) Values({0},'{1}','{2}','{3}',{4},'{5}','{6}','{7}')", objDTO.PatientId, objDTO.PatientName, objDTO.Password, objDTO.Gender, objDTO.Age, objDTO.Reason, objDTO.MobileNo, objDTO.Address);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string CreatePatientClinical(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlchk = string.Format("Select count(*) from patientclinicalmaster where PatientId={0}", objDTO.PatientId);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            if (cnt == 0)
            {
                string sql = string.Format("insert into patientclinicalmaster(PatientId,FilePath,DataKey) Values({0},'{1}','{2}')", objDTO.PatientId, objDTO.FilePath, objDTO.DataKey);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string PatientTreatment(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into patienttreatment(PatientId,DoctorId,ProblemTitle,FilePath,TDate,DataKey) Values({0},{1},'{2}','{3}','{4}','{5}')", objDTO.PatientId,objDTO.DoctorId,objDTO.ProblemTitle, objDTO.FilePath,DateTime.Now.ToString("dd/MM/yyyy"), objDTO.DataKey);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetPatient_MD(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from patientmaster where PatientId={0}",objDTO.PatientId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public DataTable GetPatient_PHD(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from patientclinicalmaster where PatientId={0}", objDTO.PatientId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public DataTable GetPatientDetails_Consult(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT patienttreatment.TDate,patienttreatment.ProblemTitle,  patienttreatment.FilePath, patienttreatment.DataKey, doctormaster.DoctorName,patientmaster.PatientId
                                         FROM patienttreatment INNER JOIN patientmaster ON patienttreatment.PatientId = patientmaster.PatientId INNER JOIN doctormaster ON patienttreatment.DoctorId = doctormaster.DoctorId where patientmaster.PatientId={0} order by patienttreatment.TId desc limit 5", objDTO.PatientId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public int UploadDoctorMedicalRecord(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from drecordmaster where DRecordName='{0}'", objDTO.RecordName);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            int res = 0;
            if (cnt == 0)
            {

                string sql = string.Format("insert into drecordmaster(DoctorId,DRecordName,FilePath,DataKey)values({0},'{1}','{2}','{3}')", objDTO.DoctorId, objDTO.RecordName, objDTO.FilePath, objDTO.DataKey);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
                string DRsql = string.Format("Select max(DRecordId) from drecordmaster");
                cmd.CommandText = DRsql;
                int DRId = int.Parse(cmd.ExecuteScalar().ToString());
                string sqlD = string.Format("select doctormaster.DeptId,mapdoctorhospital.HospitalId from doctormaster inner join mapdoctorhospital on doctormaster.DoctorId=mapdoctorhospital.DoctorId where doctormaster.DoctorId={0}",objDTO.DoctorId);

                cmd.CommandText = sqlD;
                adp = new MySqlDataAdapter(cmd);
                DataTable buffer = new DataTable();
                adp.Fill(buffer);
                string DDRMsql = string.Format("insert into dmrdatahospital(DRecordId,HospitalId,DeptId)values({0},{1},{2})", DRId, buffer.Rows[0]["HospitalId"].ToString(), buffer.Rows[0]["DeptId"].ToString());
                cmd.CommandText = DDRMsql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res;
        }
        public DataTable GetDoctorMedicalRecord_DoctorId(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select doctormaster.DeptId,mapdoctorhospital.HospitalId from doctormaster Inner Join mapdoctorhospital on doctormaster.DoctorId=mapdoctorhospital.DoctorId where doctormaster.DoctorId={0}", objDTO.DoctorId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            string rdsql = string.Format("select drecordmaster.DRecordName,drecordmaster.DRecordId from drecordmaster Inner Join dmrdatahospital on dmrdatahospital.DRecordId=drecordmaster.DRecordId where dmrdatahospital.DeptId={0} and dmrdatahospital.HospitalId={1} and drecordmaster.DoctorId<>{2}", int.Parse(buffer.Rows[0]["DeptId"].ToString()), int.Parse(buffer.Rows[0]["HospitalId"].ToString()), objDTO.DoctorId);
            cmd.CommandText = rdsql;
            adp = new MySqlDataAdapter(cmd);
            DataTable bufferRD = new DataTable();
            adp.Fill(bufferRD);
            con.Close();
            return bufferRD;
        }
        public int DoctorReq_DoctorMData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("insert into requestdocdata(DRecordId,DoctorId,Status)values({0},{1},'Pending')", objDTO.DRecordId, objDTO.DoctorId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataTable Approve_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string rdsql = string.Format("Select doctormaster.DoctorName,doctormaster.EmailId,drecordmaster.DRecordName,requestdocdata.RDDId from requestdocdata Inner Join drecordmaster on requestdocdata.DRecordId=drecordmaster.DRecordId Inner Join doctormaster on doctormaster.DoctorId=requestdocdata.DoctorId where drecordmaster.DoctorId={0} and requestdocdata.Status='Pending'", objDTO.DoctorId);
            cmd.CommandText = rdsql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public int UpdateApprove_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update requestdocdata set AccessKey='{0}',Status='Accept' where RDDId={1}", objDTO.AccessKey, objDTO.RDDId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Reject_DoctorData(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update requestdocdata set AccessKey='{0}',Status='Reject' where RDDId={1}", objDTO.AccessKey, objDTO.RDDId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataTable GetDoctorData_Approved(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select drecordmaster.DRecordName,drecordmaster.filePath,drecordmaster.DataKey,requestdocdata.AccessKey from drecordmaster Inner Join requestdocdata on drecordmaster.DRecordId=requestdocdata.DRecordId where requestdocdata.DoctorId={0} and requestdocdata.Status='Accept'", objDTO.DoctorId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable buffer = new DataTable();
            adp.Fill(buffer);
            con.Close();
            return buffer;
        }
        public string ChangePassword(SecureMedicalRecord.DTO.SecureMedicalRecordDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "Admin")
            {
                sql = string.Format("update adminmaster set Password={0} where AdminId={1}", objDTO.Password, objDTO.UserId);
            }
            else if (objDTO.UserType == "Receptionist")
            {
                sql = string.Format("update hospitalmaster set Password={0} where HospitalId={1}", objDTO.Password, objDTO.UserId);
            }
            else if (objDTO.UserType == "Doctor")
            {
                sql = string.Format("update doctormaster set Password={0} where DoctorId={1}", objDTO.Password, objDTO.UserId);
            }
            else if (objDTO.UserType == "Patient")
            {
                sql = string.Format("update patientmaster set Password={0} where PatientId={1}", objDTO.Password, objDTO.UserId);
            }
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
    }
}