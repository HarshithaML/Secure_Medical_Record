using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class Login : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.UserId = int.Parse(txtUserId.Text);
            objSecureMedicalRecordDTO.Password = txtPassword.Text;
            objSecureMedicalRecordDTO.UserType = ddlUserType.SelectedItem.Text;
            Session["UserId"] = txtUserId.Text;
            Session["Password"] = txtPassword.Text;
            Session["UserType"] = ddlUserType.SelectedItem.Text;
            string res = objSecureMedicalRecordBLL.LoginVerification(objSecureMedicalRecordDTO);
            if (res == "1")
            {
                switch (ddlUserType.SelectedItem.Text)
                {
                    case "Admin":
                        Response.Redirect("AdminHome.aspx");
                        break;
                    case "Receptionist":
                        Response.Redirect("HospitalHome.aspx");
                        break;
                    case "Doctor":
                        Response.Redirect("DoctorHome.aspx");
                        break;
                    case "Patient":
                        Response.Redirect("PatientHome.aspx");
                        break;
                }
            }
            else
            {
                lblMsg.Text = "Invalid User Id/Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}