using System;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace WindowsUpdateBlocker.Win32Api
{
    public static class Advapi32
    {
        internal const uint ServiceNoChange = 0xFFFFFFFF;

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool ChangeServiceConfig(IntPtr serviceHandle,
                                                        uint serviceType,
                                                        ServiceStartMode startType,
                                                        uint errorControl,
                                                        string binaryPathName,
                                                        string loadOrderGroup,
                                                        IntPtr tagId,
                                                        [In] char[] dependencies,
                                                        string serviceStartName,
                                                        string password,
                                                        string displayName);
    }
}