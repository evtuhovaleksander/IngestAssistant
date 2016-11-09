using System;
using System.IO;
using System.Windows.Forms;
using Ingest_Assistant;
using Ingest_Assistant.Properties;
using Microsoft.Office.Interop.Excel;
using VipLiner_Control.Properties;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VipLiner_Control
{
    public partial class TestStart : Form
    {
        public TestStart()
        {
            InitializeComponent();
        }

        private void TestStart_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Settings_Form();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new AddToBase();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes("xls.xls", Resources.xls);
            var file_path = Environment.CurrentDirectory + "/xls.xls";
            var ExcelAppR = new Application();
            Workbook ObjWorkBook;

            ObjWorkBook = ExcelAppR.Workbooks.Open(file_path);
            Worksheet m_workSheet = null;
            m_workSheet = ExcelAppR.ActiveSheet;
            // ExcelAppR.Visible = true;
            m_workSheet.Unprotect();

            m_workSheet.Cells[46, 2] = "АЯ МОГУ СЮДА ПИСАТЬ ТОКО СКАЖИ МНЕ ЧТО";
            m_workSheet.Cells[45, 2] = "АЯ МОГУ СЮДА ПИСАТЬ ТОКО СКАЖИ МНЕ ЧТО";
            m_workSheet.Cells[44, 2] = "АЯ МОГУ СЮДА ПИСАТЬ ТОКО СКАЖИ МНЕ ЧТО";
            ObjWorkBook.SaveAs(@"D:\testBook.xls",
                XlFileFormat.xlWorkbookNormal, null, null, null, null,
                XlSaveAsAccessMode.xlExclusive, null, null, null, null, null);
            ObjWorkBook.Close(false, null, null);

            ExcelAppR.Quit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }
    }
}