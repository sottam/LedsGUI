using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LedsGUI
{
    class StartupManager
    {
        public static bool CheckIfOnStartUp()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
            {
                if (key.GetValue("LEDsGUI") != null)
                    return true;
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
            {
                if (key.GetValue("LEDsGUI") != null)
                    return true;
            }

            return false;
        }

        public static void AddApplicationToStartup(bool AllUser = false)
        {
            if (AllUser)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("LEDsGUI", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("LEDsGUI", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
            }
        }

        public static void RemoveApplicationFromStartup(bool AllUser = false)
        {
            if (AllUser)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("LEDsGUI", false);
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("LEDsGUI", false);
                }
            }
           
        }

        public static bool IsUserAdministrator()
        {
            //bool value to hold our return value
            bool isAdmin;
            try
            {
                //get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                isAdmin = false;
                Console.WriteLine(ex);
            }
            return isAdmin;
        }
    }
}
