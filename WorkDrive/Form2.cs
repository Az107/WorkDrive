using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2test
{
    public partial class Form2 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private static FileSystemWatcher watcher;

        private static Size mini = new Size(15, 350);
        private static Size Max = new Size(505,350);
        private static bool MaxB = false;

        private void refreshFiles(byte max = 0)
        {
            ImageList imageListLarge = new ImageList();
            if (max == 1) imageListLarge.ImageSize = new Size(35, 35);
            else if (max == 2) imageListLarge.ImageSize = new Size(5, 5);
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
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.TopMost = true;
            Screen scn = Screen.FromPoint(this.Location);
            this.Left = scn.WorkingArea.Left - 5;
            //this.Top = scn.WorkingArea.Bottom / 5;
            refreshFiles();
            watcher = new FileSystemWatcher(Program.driveL + ":\\");
            watcher.Changed += new FileSystemEventHandler(refreshFileHandler);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        
        }

        private void Maximice()
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            //listView1.MouseEnter += Form2_Enter;
            //listView1.MouseLeave += Form2_Leave;

            if (!MaxB) refreshFiles(1);

            MaxB = true;
            this.Size = Max;
            listView1.Size = new Size(Max.Width,290);
            //listView1.Visible = true;

        }
        private void Minimice()
        {
            //listView1.MouseEnter -= Form2_Enter;
            //listView1.MouseLeave -= Form2_Leave;
            //listView1.Visible = false;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            refreshFiles(2);
            MaxB = false;
            this.Size = mini;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Enter(object sender, EventArgs e)
        {

            Maximice();
        }

        private void Form2_Leave(object sender, EventArgs e)
        {

            Minimice();
    
        }




        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string fileName = listView1.SelectedItems[0].Tag.ToString();
                Process.Start(fileName);


            }
        }



        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            Maximice();
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void listView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Debug.WriteLine("drag start");

        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            refreshFiles(1);
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {

                    string path = Program.driveL + ":\\" + filePath.Split('\\')[filePath.Split('\\').Length - 1];
                    File.Copy(filePath, path);
                }
            }
            refreshFiles(1);

        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {


            List<String> files = new List<string>();
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                files.Add((string)item.Tag);
            }
            this.DoDragDrop(new DataObject(DataFormats.FileDrop,files.ToArray()), DragDropEffects.Copy);
            
           
        }
    }
}
