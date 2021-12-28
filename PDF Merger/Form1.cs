using PDF_Merger.Helper;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Merger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<System.IO.FileInfo> fileList = new List<System.IO.FileInfo>();

        private void AddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog thisDialog = new OpenFileDialog();

            thisDialog.InitialDirectory = "c:\\";
            thisDialog.RestoreDirectory = true;
            thisDialog.Multiselect = true;
            thisDialog.Title = "Please Select Source File(s) for Conversion";

            if (thisDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in thisDialog.FileNames)
                {
                    try
                    {
                        fileList.Add(new System.IO.FileInfo(file));
                        this.SelectedItemsList.Items.Add(file, true);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            
        }

        private void SelectedItemsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.SelectedItemsList.SelectedItem == null) return;
            this.SelectedItemsList.SetItemChecked(SelectedItemsList.SelectedIndex, !this.SelectedItemsList.GetItemChecked(this.SelectedItemsList.SelectedIndex));
            this.SelectedItemsList.DoDragDrop(this.SelectedItemsList.SelectedItem, DragDropEffects.Move);
        }

        private void SelectedItemsList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void SelectedItemsList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = SelectedItemsList.PointToClient(new Point(e.X, e.Y));
            int index = this.SelectedItemsList.IndexFromPoint(point);
            if (index < 0) index = this.SelectedItemsList.Items.Count - 1;
            bool value = this.SelectedItemsList.GetItemChecked(this.SelectedItemsList.SelectedIndex);
            object data = SelectedItemsList.SelectedItem;
            this.SelectedItemsList.Items.Remove(data);
            this.SelectedItemsList.Items.Insert(index, data);
            this.SelectedItemsList.SetItemChecked(index, value);
        }

        private void MakePDF_Click(object sender, EventArgs e)
        {
            if (this.SelectedItemsList.Items.Count == 0)
                MessageBox.Show("Add files to merge! No files selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            var items = this.SelectedItemsList.CheckedItems;
            
            using (PdfDocument outPdf = new PdfDocument())
            {
                foreach (var item in items)
                {
                    if (item.ToString().ToLowerInvariant().EndsWith(".pdf"))
                    {
                        PdfDocument temp = PdfReader.Open(item.ToString(), PdfDocumentOpenMode.Import);
                        CopyPages(temp, outPdf);
                    }
                    else
                    {
                        //PdfHelper helper = new PdfHelper();
                        //helper.SaveImageAsPdf(item.ToString(), "temp.pdf");
                        PdfHelper2.imageToPdf(item.ToString(), new System.IO.StreamWriter("temp.pdf").BaseStream);
                        PdfDocument temp = PdfReader.Open("temp.pdf", PdfDocumentOpenMode.Import);
                        CopyPages(temp, outPdf);
                    }
                        
                }
                SaveFileDialog(outPdf);
            }
            MessageBox.Show("Successfully merged!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveFileDialog(PdfDocument outPdf)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Save file as";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outPdf.Save(saveFileDialog1.FileName);
            }
        }

        void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
