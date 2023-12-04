using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == Session["Password"].ToString())
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.UserId = int.Parse(Session["UserId"].ToString());
                objSecureMedicalRecordDTO.Password = txtNewPassword.Text;
                objSecureMedicalRecordDTO.UserType = Session["UserType"].ToString();
                string Result = objSecureMedicalRecordBLL.ChangePassword(objSecureMedicalRecordDTO);
                if (Result != "0")
                {
                    Session["Password"] = txtNewPassword.Text;
                    txtNewPassword.Text = txtConfirmPassword.Text = txtOldPassword.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Password Reset Successfully";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Password Reset Error";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid Old Password";
            }
        }
    }
}