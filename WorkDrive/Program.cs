using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTR.IO.ImDisk;
using System.Management;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Principal;

namespace app2test
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static String Letters = "ABDEFGHIJKLMNOPQRSTVWXYZ";
        public static String driveL = "A";


        private static void Format()
        {
            Process proccess = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C FORMAT {driveL}: /Y /FS:NTFS /V:WorkDrive /Q";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            proccess.StartInfo = startInfo;
            proccess.Start();
            proccess.WaitForExit();


        }

        public static void Umount()
        {
            ImDiskAPI.RemoveDevice(driveL + ":\\");
        }

        public static void Create()
        {
            uint a = uint.MaxValue;
            int index = 0;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == driveL + ":\\")
                {
                    index++;
                    driveL = Letters[index].ToString();
                }

            }

            ImDiskAPI.CreateDevice(250 * 1024 * 1024, driveL + ":\\", ref a);
            Format();

        }
    }
}
