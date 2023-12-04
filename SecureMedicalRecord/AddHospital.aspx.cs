using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class AddHospital : System.Web.UI.Page
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
            objSecureMedicalRecordDTO.HospitalId =rnd.Next(100000,999999);
            objSecureMedicalRecordDTO.Password = rnd.Next(1000, 9999).ToString();
            objSecureMedicalRecordDTO.HospitalName = txtHospitalName.Text;
            objSecureMedicalRecordDTO.ContactPerson = txtContactPerson.Text;
            objSecureMedicalRecordDTO.ContactNo = txtMobileNo.Text;
            objSecureMedicalRecordDTO.Address = txtAddress.Text;
            int res = objSecureMedicalRecordBLL.AddHospital(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                txtHospitalName.Text = txtContactPerson.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Hospital Created Successfully & Hopsital Id:"+objSecureMedicalRecordDTO.HospitalId+" & Password:"+objSecureMedicalRecordDTO.Password;
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == 2)
            {
                txtHospitalName.Text = txtContactPerson.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Hospital Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtHospitalName.Text = txtContactPerson.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Hospital Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}