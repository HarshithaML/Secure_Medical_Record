using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class RequestDoctorMD : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.DoctorId = int.Parse(Session["UserId"].ToString());
                
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDoctorMedicalRecord_DoctorId(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    Table1.Controls.Clear();
                    TableRow hr = new TableRow();

                    TableHeaderCell hc1 = new TableHeaderCell();
                    hc1.Text = "Doctor Record Name";

                    TableHeaderCell hc2 = new TableHeaderCell();
                    hc2.Text = "";


                    hr.Cells.Add(hc1);
                    hr.Cells.Add(hc2);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblRecordName = new Label();
                        lblRecordName.Text = tab.Rows[i]["DRecordName"].ToString();

                        TableCell RecordName = new TableCell();
                        RecordName.Controls.Add(lblRecordName);

                        LinkButton lnk = new LinkButton();
                        lnk.ID = "lnk" + i.ToString();
                        lnk.Text = "Request";
                        lnk.CommandArgument = tab.Rows[i]["DRecordId"].ToString();
                        lnk.Click += Lnk_Click;

                        TableCell lnkview = new TableCell();
                        lnkview.Controls.Add(lnk);

                        row.Controls.Add(RecordName);
                        row.Controls.Add(lnkview);

                        Table1.Controls.Add(row);
                    }
                }
                else
                {
                    lblMsg.Text = "No Record Found.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            { }
        }

        private void Lnk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton lnk = (LinkButton)sender;
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.DRecordId = int.Parse(lnk.CommandArgument);
            objSecureMedicalRecordDTO.DoctorId = int.Parse(Session["UserId"].ToString());
            int res = objSecureMedicalRecordBLL.DoctorReq_DoctorMData(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                lblMsg.Text = "Record Request Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}