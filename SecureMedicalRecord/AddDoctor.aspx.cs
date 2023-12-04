using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureMedicalRecord
{
    public partial class AddDoctor : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDeptDetails();
                ddlDept.DataSource = tab;
                ddlDept.DataTextField = "DeptName";
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");


            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            Random rnd = new Random();
            objSecureMedicalRecordDTO.DoctorId = rnd.Next(100000, 999999);
            objSecureMedicalRecordDTO.DeptId = int.Parse(ddlDept.SelectedItem.Value);
            objSecureMedicalRecordDTO.Password = rnd.Next(1000, 9999).ToString();
            objSecureMedicalRecordDTO.DoctorName = txtDoctorName.Text;
            objSecureMedicalRecordDTO.EmailId = txtEmailId.Text;
            objSecureMedicalRecordDTO.MobileNo = txtMobileNo.Text;
            objSecureMedicalRecordDTO.Address = txtAddress.Text;
            int res = objSecureMedicalRecordBLL.AddDoctor(objSecureMedicalRecordDTO);
            Session["UPassword"] = objSecureMedicalRecordDTO.Password;
            if (res == 1)
            {
                ddlDept.SelectedIndex = 0;
                txtDoctorName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                Response.Redirect("DoctorTimings.aspx?DoctorId="+objSecureMedicalRecordDTO.DoctorId);
                //lblMsg.Text = "Doctor Created Successfully & Doctor Id:" + objSecureMedicalRecordDTO.DoctorId + " & Password:" + objSecureMedicalRecordDTO.Password;
                //lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ddlDept.SelectedIndex = 0;
                txtDoctorName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Doctor Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}