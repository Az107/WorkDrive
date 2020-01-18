using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2test
{
    public partial class Form2 : Form
    {
        private static FileSystemWatcher watcher;

        private static Size mini = new Size(10, 350);
        private static Size Max = new Size(500,350);
        private static bool MaxB = false;

        private void refreshFiles(bool max = true)
        {
            ImageList imageListLarge = new ImageList();
            if (max) imageListLarge.ImageSize = new Size(35, 35);
            else imageListLarge.ImageSize = new Size(5, 5);
            listView1.Items.Clear();
            String[] files = Directory.GetFiles(Program.driveL + ":\\");
            foreach (string file in files)
            {

                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                item.Tag = file;
                item.ImageIndex = imageListLarge.Images.Count;
                listView1.Items.Add(item);
                Image icon = Icon.ExtractAssociatedIcon(file).ToBitmap();
                imageListLarge.Images.Add(icon);
            }
            string[] folders = Directory.GetDirectories(Program.driveL + ":\\");
            foreach (string folder in folders)
            {

                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(folder));
                item.Tag = folder;
                listView1.Items.Add(item);

            }
            listView1.LargeImageList = imageListLarge;
        }
        private void refreshFileHandler(object sender, FileSystemEventArgs e)
        {
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new MethodInvoker(delegate
                {
                    refreshFiles();
                }));
            }
            else refreshFiles();
            
        }
        public Form2()
        {
            InitializeComponent();
            this.TopMost = true;
            Screen scn = Screen.FromPoint(this.Location);
            this.Left = scn.WorkingArea.Left;
            refreshFiles();
            watcher = new FileSystemWatcher(Program.driveL + ":\\");
            watcher.Changed += new FileSystemEventHandler(refreshFileHandler);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        
        }

        private void Maximice()
        {
            if (!MaxB) refreshFiles();

            MaxB = true;
            this.Size = Max;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Enter(object sender, EventArgs e)
        {

            
        }

        private void Form2_Leave(object sender, EventArgs e)
        {
            refreshFiles(false);
            MaxB = false;
            this.Size = mini;
        }

        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            Maximice();
        }

        private void Form2_DragOver(object sender, DragEventArgs e)
        {
            Maximice();
        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string fileName = listView1.SelectedItems[0].Tag.ToString();
                Process.Start(fileName);


            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {

                    string path = Program.driveL + ":\\" + filePath.Split('\\')[filePath.Split('\\').Length - 1];
                    File.Copy(filePath,path);
                }
            }
            refreshFiles();
        }
    }
}
