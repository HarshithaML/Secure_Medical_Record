using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace SecureMedicalRecord
{
    public partial class ViewDoctorMD : System.Web.UI.Page
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
                tab = objSecureMedicalRecordBLL.GetDoctorData_Approved(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    Table1.Controls.Clear();
                    TableRow hr = new TableRow();

                    TableHeaderCell hc1 = new TableHeaderCell();
                    hc1.Text = "Record Name";

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
                        lnk.Text = "View";
                        lnk.CommandArgument = tab.Rows[i]["AccessKey"] + "-" + tab.Rows[i]["FilePath"] + "-" + tab.Rows[i]["DataKey"];
                        lnk.Click += Lnk_Click;

                        TableCell lnkview = new TableCell();
                        lnkview.Controls.Add(lnk);

                        row.Controls.Add(RecordName);
                        row.Controls.Add(lnkview);

                        Table1.Controls.Add(row);
                    }
                }
            }
            catch
            { }
        }

        private void Lnk_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            if (txtKey.Text == lnk.CommandArgument.ToString().Split('-')[0])
            {
                string dk = lnk.CommandArgument.ToString().Split('-')[2];
                GetDecryptData obj = new GetDecryptData();
                string result = obj.GetData(dk);
                var QCreader = new BarcodeReader();
                string QCfilename = Path.Combine(Request.MapPath
                   ("~/DoctorRecordImages"), lnk.CommandArgument.ToString().Split('-')[1].Split('/')[2]);
                var QCresult = QCreader.Decode(new Bitmap(QCfilename));

                txtMedicalData.Text = AESCryptoClass.Decrypt(QCresult.Text, result.ToString());
            }
        }
    }
}