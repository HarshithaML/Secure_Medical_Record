using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class AddPatient : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            Random rnd = new Random();
            
            objSecureMedicalRecordDTO.PatientId = rnd.Next(10000, 99999);
            objSecureMedicalRecordDTO.PatientName = txtPatientName.Text;
            objSecureMedicalRecordDTO.Password = rnd.Next(1000, 9999).ToString();
            objSecureMedicalRecordDTO.Gender = ddlGender.SelectedItem.Text;
            objSecureMedicalRecordDTO.Age = txtAge.Text;
            objSecureMedicalRecordDTO.Reason = txtReason.Text;
            objSecureMedicalRecordDTO.MobileNo = txtMobileNo.Text;
            objSecureMedicalRecordDTO.Address = txtAddress.Text;
            string res = objSecureMedicalRecordBLL.CreatePatient(objSecureMedicalRecordDTO);

            if (res == "1")
            {
                ddlGender.SelectedIndex = 0;
                txtPatientName.Text = txtMobileNo.Text = txtAge.Text = txtAddress.Text = txtMobileNo.Text = txtReason.Text = "";
                Session["PPassword"] = objSecureMedicalRecordDTO.Password;
                Response.Redirect("AddPatientClinical.aspx?PatientId=" + objSecureMedicalRecordDTO.PatientId);
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Patient Creation Error";
            }
        }
    }
}