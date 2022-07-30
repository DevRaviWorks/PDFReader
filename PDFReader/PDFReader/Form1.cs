using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFReader
{
    public partial class Form1 : Form
    {
        string pdfPath= AppDomain.CurrentDomain.BaseDirectory + "\\PDF\\sample-pdf.pdf";
        public Form1()
        {
            InitializeComponent();
            PDF_Reader.src = pdfPath;
        }

        private void btn_coppy_Click(object sender, EventArgs e)
        {
            var folderPath= ConfigurationManager.AppSettings["copyFolderPath"];
            if (!string.IsNullOrEmpty(folderPath))
            {
                var fileinfo = new FileInfo(pdfPath);
                File.Copy(pdfPath, folderPath+"\\"+fileinfo.Name);
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "Acrobat.exe";
                myProcess.StartInfo.Arguments = "/A \"nameddest=Test2\" "+ folderPath + "\\" + fileinfo.Name + "";
                myProcess.Start();
            }
        }
    }
}
