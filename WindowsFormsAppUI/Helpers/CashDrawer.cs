using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace WindowsFormsAppUI.Helpers
{
    public class CashDrawer
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        [DllImport("winspool.drv", EntryPoint = "OpenPrinterW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter(string printerName, out IntPtr hPrinter, int printerDefaults);

        [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOCINFO documentInfo);

        [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr buffer, int bufferLength, out int bytesWritten);

        public static bool PrintRaw(string printerName, string origString)
        {
            IntPtr hPrinter;
            DOCINFO spoolData = new DOCINFO();
            IntPtr dataToSend;
            int dataSize;
            int bytesWritten;

            dataSize = origString.Length;
            dataToSend = Marshal.StringToCoTaskMemAnsi(origString);

            spoolData.pDocName = "OpenDrawer";
            spoolData.pDataType = "RAW";

            try
            {
                OpenPrinter(printerName, out hPrinter, 0);
                StartDocPrinter(hPrinter, 1, ref spoolData);
                StartPagePrinter(hPrinter);
                WritePrinter(hPrinter, dataToSend, dataSize, out bytesWritten);
                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
                ClosePrinter(hPrinter);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.ToString());
                return false;
            }
            finally
            {
                Marshal.FreeCoTaskMem(dataToSend);
            }
        }

        public static void OpenCashdrawer()
        {
            PrinterSettings printerSettings = new PrinterSettings();
            PrintRaw(printerSettings.PrinterName, "\x1B\x70\x30\x40\x40");
        }
    }
}
