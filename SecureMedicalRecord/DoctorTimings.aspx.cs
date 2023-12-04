using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureMedicalRecord
{
    public partial class DoctorTimings : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;

        static int DoctorId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                //objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                //objSecureMedicalRecordDTO.HospitalId = int.Parse(Session["UserId"].ToString());
                //DataTable tab = new DataTable();
                //tab = objSecureMedicalRecordBLL.GetDoctor_HId(objSecureMedicalRecordDTO);
                //ddlDoctor.DataSource = tab;
                //ddlDoctor.DataTextField = "DoctorName";
                //ddlDoctor.DataValueField = "DoctorId";
                //ddlDoctor.DataBind();
                //ddlDoctor.Items.Insert(0, "--Select--");

                if (Request.QueryString["DoctorId"] != null)
                {
                    DoctorId = int.Parse(Request.QueryString["DoctorId"].ToString());
                }



            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            Random rnd = new Random();
            objSecureMedicalRecordDTO.HospitalId = int.Parse(Session["UserId"].ToString());
            objSecureMedicalRecordDTO.DoctorId = DoctorId;
            objSecureMedicalRecordDTO.DurationTimings = txtDoctorTimings.Text;
            int res = objSecureMedicalRecordBLL.DoctorTimings(objSecureMedicalRecordDTO);
            if (res == 1)
            {
               
                txtDoctorTimings.Text = "";
                lblMsg.Text = "Doctor Created Successfully & Doctor Id:" + DoctorId + " & Password:" + Session["UPassword"].ToString();
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == 2)
            {
                
                txtDoctorTimings.Text = "";
                lblMsg.Text = "Doctor Timings Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
               
                txtDoctorTimings.Text = "";
                lblMsg.Text = "Doctor Timings Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}