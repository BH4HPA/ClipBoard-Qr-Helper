using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace ToastHelper
{
    class AutoStart
    {
        private static void CreateShortcut(string lnkFilePath, string args)
        {
            var shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);
            var shortcut = shell.CreateShortcut(lnkFilePath);
            shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
            shortcut.Arguments = args;
            shortcut.WorkingDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            shortcut.Save();
        }

        public static void SetAutoStart()
        {
            var startupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "ClipBoardQrHelper.lnk");
            CreateShortcut(startupPath, "--silence");
        }

        public static void UnsetAutoStart()
        {
            var startupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "ClipBoardQrHelper.lnk");
            File.Delete(startupPath);
        }

        public static bool IsAutoStart()
        {
            var startupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "ClipBoardQrHelper.lnk");
            return File.Exists(startupPath);
        }
    }
}
