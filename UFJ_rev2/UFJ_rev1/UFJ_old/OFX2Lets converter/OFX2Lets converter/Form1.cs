using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OFX2Lets;

namespace OFX2LetsForm
{
    public partial class OFX2Lets : Form
    {
        public OFX2Lets()
        {
            InitializeComponent();         
            
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFile.Text = openFileDialog.FileName;
            }

            if (convertFile.Text == "")
            {
                convertFile.Text = Regex.Replace(sourceFile.Text, @"(.+)(\.\w+$)", "$1_2.ofx");
            }

            if (convertTable.Text == "")
            {
                convertTable.Text = "C:\\Data\\HouseholdAccounts\\明細\\convertTable.txt";
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                convertFile.Text = saveFileDialog.FileName;
            }
        }

        private void convbutton_Click_1(object sender, EventArgs e)
        {
            if (openconvertFile.ShowDialog() == DialogResult.OK)
            {
                convertTable.Text = openconvertFile.FileName;
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                OFXLets convertfile = new OFXLets();
                convertfile.getdata(sourceFile.Text);
                //convertfile.select_convert();
                convertfile.convert(convertTable.Text);
                //convertfile.debug_print(convertFile.Text);
                convertfile.writefile(convertFile.Text);
                MessageBox.Show("終わったよ");

            }

            catch (FileNotFoundException er)
            {
                MessageBox.Show("ファイル: " + er.FileName + "が見つかりません", "エラー");
            }

            catch (ArgumentException er)
            {
                    MessageBox.Show(er.Message, "エラー");
            }
                        
        }


    }
}
