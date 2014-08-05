using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace gta3vcMusic
{
    public partial class GTA3VCMusic : Form
    {
        // The folder to output to, should be the /mp3 of VC or GTA3
        string gameMp3Folder = "";

        // Playlist file type.
        /**
         * The file is just a text file with each music file separated by a newline, but consistency
         * is key. Plus I might want to make it more elaborate later!
         */
        const string PlaylistFileType = "GTA3VCMusic playlist|*.gta3vc";

        public GTA3VCMusic()
        {
            InitializeComponent();

            //txtFolderPath.Text = "E:\\Games\\Grand Theft Auto Vice City\\mp3";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.TextLength > 3)
            {
                folderDialog.SelectedPath = txtFolderPath.Text;
            }

            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFolderPath.Text = folderDialog.SelectedPath;
                gameMp3Folder = folderDialog.SelectedPath;
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            lstFiles.BeginUpdate();
            foreach (string file in files)
            {
                // only add if extension is .mp3
                if (file.IndexOf(".mp3") == file.Length - 4)
                {
                    // check for duplicates
                    if (lstFiles.FindString(file) == -1)
                    {
                        lstFiles.Items.Add(file);
                    }
                }
            }
            lstFiles.EndUpdate();
        }

        private void btnCreateSymLinks_Click(object sender, EventArgs e)
        {
            var filenames = lstFiles.Items;

            foreach (string file in filenames)
            {
                // get rekt
                string[] split = file.Split('\\');
                string nFile = "\"" + txtFolderPath.Text + "\\" + split[split.Length - 1] + "\"";
                var sfile = "\"" + file + "\"";

                Console.WriteLine("/c mklink " + nFile + " " + sfile);

                ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c mklink " + nFile + " " + sfile);
                Process.Start(startInfo);
            }
        }

        private void btnCreateSymLinks_MouseEnter(object sender, EventArgs e)
        {
            btnCreateSymLinks.ForeColor = Color.Red;
        }

        private void btnCreateSymLinks_MouseLeave(object sender, EventArgs e)
        {
            btnCreateSymLinks.ForeColor = Color.Black;
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            int curr = lstFiles.SelectedIndex;

            System.Windows.Forms.ListBox.SelectedIndexCollection selected = lstFiles.SelectedIndices;

            foreach (var i in selected)
            {
                lstFiles.Items.RemoveAt((int)i);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = PlaylistFileType;

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;

                // open file for writing
                System.IO.StreamWriter pFile = new StreamWriter(filename);

                var files = lstFiles.Items;
                foreach( string file in files )
                {
                    pFile.WriteLine(file);
                }

                pFile.Close();
            }
        }

        private void btnLoadPlaylist_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                lstFiles.Items.Clear();

                System.IO.StreamReader pFile = new StreamReader(filename);

                while (!pFile.EndOfStream)
                {
                    string musicFile = pFile.ReadLine();
                    lstFiles.Items.Add(musicFile);
                }
            }
        }
    }
}
