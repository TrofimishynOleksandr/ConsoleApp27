using System.Runtime.InteropServices;


namespace ConsoleApp2
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_CLOSE = 0x0010;

        static void Main(string[] args)
        {
            IntPtr hwnd = FindWindow("Notepad", null);

            if (hwnd != IntPtr.Zero)
            {
                SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                Console.WriteLine("Notepad window was closed");
            }
            else
                Console.WriteLine("Notepad window wasn't found");
        }
    }
}
