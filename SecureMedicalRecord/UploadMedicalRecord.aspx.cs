using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZXing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace SecureMedicalRecord
{
    public partial class UploadMedicalRecord : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                DataTable tab= new DataTable();
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
            objSecureMedicalRecordDTO.RecordName = txtRecordName.Text;
            objSecureMedicalRecordDTO.DeptId = int.Parse(ddlDept.SelectedItem.Value);
            objSecureMedicalRecordDTO.RecordData = txtRecordData.Text;
            objSecureMedicalRecordDTO.AccessType =ddlAccessType.SelectedItem.Text;

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
            string path = "~/RecordImages/" + txtRecordName.Text + "_" + v + ".jpg";
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
            objSecureMedicalRecordDTO.FilePath =path;
            objSecureMedicalRecordDTO.DataKey = attributedata;
            int res = objSecureMedicalRecordBLL.UploadMedicalRecord(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                
                ddlDept.SelectedIndex = 0;
                ddlAccessType.SelectedIndex = 0;
                txtRecordName.Text = txtRecordData.Text = "";
                lblMsg.Text = "Medical Upload Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == 2)
            {
                ddlDept.SelectedIndex = 0;
                ddlAccessType.SelectedIndex = 0;
                txtRecordName.Text = txtRecordData.Text = "";
                lblMsg.Text = "Medical Record Name Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ddlDept.SelectedIndex = 0;
                ddlAccessType.SelectedIndex = 0;
                txtRecordName.Text = txtRecordData.Text = "";
                lblMsg.Text = "Medical Upload Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}