using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace SecureMedicalRecord
{
    public partial class AddPatientClinical : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        static int PatientId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PatientId"] != null)
                {
                    PatientId = int.Parse(Request.QueryString["PatientId"].ToString());
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            Shamir obj = new Shamir();
            Random rnd = new Random();
            int key = rnd.Next(1000, 9999);
            string attributedata = obj.AttributeValue(key);
            attributedata = attributedata.Remove(0, 1);
            objSecureMedicalRecordDTO.PatientId = PatientId;
            string PastData = txtMedicalHistory.Text+ "-" + txtPatientAllergies.Text + "-" + txtSocialHistory.Text;
            string EncryptData = AESCryptoClass.EncryptData(PastData, key.ToString());

            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(EncryptData);
            string v = rnd.Next(1000, 9999).ToString();
            string path = "~/PatientRecord/" + PatientId + "_PH_" + v + ".jpg";
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(Server.MapPath(path),
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            objSecureMedicalRecordDTO.FilePath = path;
            objSecureMedicalRecordDTO.DataKey = attributedata;
            string res = objSecureMedicalRecordBLL.CreatePatientClinical(objSecureMedicalRecordDTO);
            if (res == "1")
            {
                txtMedicalHistory.Text = txtPatientAllergies.Text = txtSocialHistory.Text = "";
                lblMsg.Text = "Patient Past Medical History Uploaded Successfully & Patient Id:" + PatientId + " & Password:" + Session["PPassword"].ToString();
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == "2")
            {
                txtMedicalHistory.Text = txtPatientAllergies.Text = txtSocialHistory.Text = "";
                lblMsg.Text = "Patient Past Medical History Uploaded Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtMedicalHistory.Text = txtPatientAllergies.Text = txtSocialHistory.Text = "";
                lblMsg.Text = "Patient Past Medical History Upload Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}