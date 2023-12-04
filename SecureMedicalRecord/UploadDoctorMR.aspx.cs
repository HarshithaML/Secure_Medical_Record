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
    public partial class UploadDoctorMR : System.Web.UI.Page
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
            objSecureMedicalRecordDTO.RecordName = txtRecordName.Text;
            objSecureMedicalRecordDTO.DoctorId = int.Parse(Session["UserId"].ToString());
            objSecureMedicalRecordDTO.RecordData = txtDescp.Text;

            Shamir obj = new Shamir();
            Random rnd = new Random();
            int key = rnd.Next(1000, 9999);
            string attributedata = obj.AttributeValue(key);
            attributedata = attributedata.Remove(0, 1);
            string Encryptdata = AESCryptoClass.EncryptData(objSecureMedicalRecordDTO.RecordData, key.ToString());

            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(Encryptdata);
            string v = rnd.Next(1000, 9999).ToString();
            string path = "~/DoctorRecordImages/" + txtRecordName.Text + "_" + Session["UserId"].ToString() +"_"+ v + ".jpg";
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
            int res = objSecureMedicalRecordBLL.UploadDoctorMedicalRecord(objSecureMedicalRecordDTO);
            if (res == 1)
            {

                
                txtRecordName.Text = txtDescp.Text = "";
                lblMsg.Text = "Medical Upload Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == 2)
            {
                
                txtRecordName.Text = txtDescp.Text = "";
                lblMsg.Text = "Medical Record Name Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                
                txtRecordName.Text = txtDescp.Text = "";
                lblMsg.Text = "Medical Upload Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}