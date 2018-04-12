using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using WindowsUpdateBlocker.Blockers.Support;
using WindowsUpdateBlocker.Extensions;
using WindowsUpdateBlocker.Win32Api;

namespace WindowsUpdateBlocker.Blockers
{
    public class WindowsUpdateServiceBlocker : IBlock
    {
        public void Block()
        {
            using (var service = new ServiceController("wuauserv"))
            {
                StopService(service);
                DisableService(service);
            }
        }

        private static void StopService(ServiceController service)
        {
            try
            {
                service.Refresh();
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    Console.WriteLine($"[{DateTime.Now:s}] - Status: {service.Status}");
                    if (service.CanStop)
                    {
                        Console.WriteLine($"[{DateTime.Now:s}] - Stopping wuauserv...");
                        service.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:s}] - {ex.Message}\r\n    StackTrace:\r\n    {ex.StackTrace.Indent()}");
            }
        }

        private static void DisableService(ServiceController service)
        {
            try
            {
                if (service.StartType != ServiceStartMode.Disabled)
                {
                    Console.WriteLine($"[{DateTime.Now:s}] - Disabling wuauserv...");
                    using (var serviceHandle = service.ServiceHandle)
                    {
                        if (!Advapi32.ChangeServiceConfig(serviceHandle.DangerousGetHandle(), Advapi32.ServiceNoChange, ServiceStartMode.Disabled, Advapi32.ServiceNoChange, null, null, IntPtr.Zero, null, null, null, null))
                        {
                            var exception = new Win32Exception(Marshal.GetLastWin32Error());
                            Console.WriteLine($"[{DateTime.Now:s}] - Could not disable {service.DisplayName}.\n    Message: {exception.Message}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:s}] - {ex.Message}\r\n    StackTrace:\r\n    {ex.StackTrace.Indent()}");
            }
        }
    }
}