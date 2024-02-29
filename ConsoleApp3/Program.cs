using System.Runtime.InteropServices;

namespace ConsoleApp2
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        const uint WM_SETTEXT = 0x000C;

        static void Main(string[] args)
        {
            while (true)
            {
                IntPtr handle = FindWindow("Notepad", null);

                if (handle != IntPtr.Zero)
                {
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");

                    SendMessage(handle, WM_SETTEXT, IntPtr.Zero, currentTime);
                }
                else
                {
                    Console.WriteLine("Notepad window wasn't found");
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
