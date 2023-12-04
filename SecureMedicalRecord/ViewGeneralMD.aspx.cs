using System;
using System.Collections;
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
    public partial class ViewGeneralMD : System.Web.UI.Page
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
                objSecureMedicalRecordDTO.AccessType = "General";
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetGeneralMedicalRecord_DoctorId(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
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
                        lblRecordName.Text = tab.Rows[i]["RecordName"].ToString();

                        TableCell RecordName = new TableCell();
                        RecordName.Controls.Add(lblRecordName);

                        LinkButton lnk = new LinkButton();
                        lnk.ID = "lnk" + i.ToString();
                        lnk.Text = "View";
                        lnk.CommandArgument = tab.Rows[i]["RecordPath"] + "-" + tab.Rows[i]["DataKey"];
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
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            { }
        }

        

        static ArrayList xList = null;
        static ArrayList yList = null;
        static ArrayList lagrangeList = null;

        double result = 0.0;
        string K, N;
        ArrayList valrnd = new ArrayList();
        private void Lnk_Click(object sender, EventArgs e)
        {
            xList = new ArrayList();
            yList = new ArrayList();
            lagrangeList = new ArrayList();
            Shamir objShamir = new Shamir();
            LinkButton lnk = (LinkButton)sender;
            string[] attval = lnk.CommandArgument.ToString().Split('-')[1].Split(',');
            Random rnd = new Random();
            for (int i = 0; i <= 2;)
            {
                int v = rnd.Next(1, 6);
                int p = valrnd.IndexOf(v);
                if (p < 0)
                {
                    valrnd.Add(v);
                    i++;

                }


            }
            for (int i = 0; i <= 2; i++)
            {
                xList.Add(valrnd[i]);
                yList.Add(attval[int.Parse(valrnd[i].ToString()) - 1].ToString());

            }
            K = "3";
            for (int i = 0; i < int.Parse(K); i++)
            {
                lagrangeList.Add(Lagarange(i));
            }
            double result = 0.0;
            for (int i = 0; i < int.Parse(K); i++)
            {
                result = result + (double.Parse(yList[i].ToString()) * double.Parse(lagrangeList[i].ToString()));
            }
            if (result < 0)
            {
                result = result * -1.0;
            }
            result = Math.Round(result, MidpointRounding.AwayFromZero);

            var QCreader = new BarcodeReader();
            string QCfilename = Path.Combine(Request.MapPath
               ("~/RecordImages"), lnk.CommandArgument.ToString().Split('-')[0].Split('/')[2]);
            var QCresult = QCreader.Decode(new Bitmap(QCfilename));

            txtMedicalData.Text = AESCryptoClass.Decrypt(QCresult.Text, result.ToString());
        }

        public double Lagarange(int index)
        {
            return numerator(index) / denominator(index);
        }

        public double numerator(int index)
        {
            double num = 1.0;
            K = "3";
            for (int i = 0; i < int.Parse(K); i++)
            {
                if (i != index)
                {
                    num = num * double.Parse(xList[i].ToString());
                }
            }
            return num;
        }
        public double denominator(int index)
        {
            double den = 1.0;
            K = "3";
            for (int i = 0; i < int.Parse(K); i++)
            {
                if (i != index)
                {
                    den = den * (double.Parse(xList[index].ToString()) - double.Parse(xList[i].ToString()));
                }
            }
            return den;
        }
    }
}