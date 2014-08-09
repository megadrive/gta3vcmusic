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
        Random rng = new Random();

        // Playlist file type, now supports an actual format!
        const string PlaylistFileType = "Playlist files|*.m3u";
        const string _settingsFilename = "gta3vc_settings.txt";

        public GTA3VCMusic()
        {
            InitializeComponent();

            // get previous used folder
            if (File.Exists(_settingsFilename))
            {
                StreamReader reader = new StreamReader(_settingsFilename);
                txtFolderPath.Text = reader.ReadLine();
            }

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
                var s = file.Split('.');
                if (s[s.Length-1] == "mp3")
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
            if (Directory.Exists(txtFolderPath.Text))
            {
                txtFolderPath.ForeColor = Color.Black;

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

                // Save last used
                if( System.IO.File.Exists(_settingsFilename) )
                {
                    System.IO.File.Delete(_settingsFilename); // todo: find something more elegant.
                }

                StreamWriter writer = new StreamWriter(_settingsFilename);
                writer.WriteLine(txtFolderPath.Text);
                writer.Close();

            }
            else
            {
                txtFolderPath.ForeColor = Color.Red;
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
                foreach (string file in files)
                {
                    pFile.WriteLine(file);
                }

                pFile.Close();
            }
        }

        private void btnLoadPlaylist_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = PlaylistFileType;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                lstFiles.Items.Clear();

                System.IO.StreamReader pFile = new StreamReader(filename);

                while (!pFile.EndOfStream)
                {
                    string musicFile = pFile.ReadLine();
                    var s = musicFile.Split('.');
                    if (s[s.Length - 1] == "mp3")
                    {
                        // check for duplicates
                        if (lstFiles.FindString(musicFile) == -1)
                        {
                            lstFiles.Items.Add(musicFile);
                        }
                    }
                }
            }
        }

        private void btnRandomise_Click(object sender, EventArgs e)
        {
            var files = lstFiles.Items;
            int n = files.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = files[k];
                files[k] = files[n];
                files[n] = value;
            }
        }
    }
}
