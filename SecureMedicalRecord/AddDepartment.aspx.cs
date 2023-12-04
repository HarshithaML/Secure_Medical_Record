using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class AddDepartment : System.Web.UI.Page
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
            objSecureMedicalRecordDTO.DeptName = txtDepartmentName.Text;
            objSecureMedicalRecordDTO.Description = txtDescp.Text;
            int res = objSecureMedicalRecordBLL.CreateDept(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                txtDepartmentName.Text = txtDescp.Text = "";
                lblMsg.Text = "Department Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == 2)
            {
                txtDepartmentName.Text = txtDescp.Text = "";
                lblMsg.Text = "Department Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtDepartmentName.Text = txtDescp.Text = "";
                lblMsg.Text = "Department Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}