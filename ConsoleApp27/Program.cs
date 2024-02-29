using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp27
{
    internal class Program
    {
        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern int MessageBox(IntPtr intPtr, string text, string title, uint type);

        [DllImport("Shell32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr ShellExecute
        (
            IntPtr hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            int nShowCmd
        );

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)] 
        public static extern bool GetUserName(StringBuilder buffer, ref int size);

        static void Main(string[] args)
        {
            //MessageBox(IntPtr.Zero, "Hello, World!", "Message", 0);
            //Console.WriteLine("Hello, World!");
            string url = "https://google.com";

            IntPtr result = ShellExecute
            (
                IntPtr.Zero,
                "open",
                url,
                null,
                null,
                1
            );

            if (result.ToInt32() <= 32)
                Console.WriteLine("Failed to open URL. Error code: " + result.ToInt32());
            else
                Console.WriteLine("URL opened successfully!");


            int size = 256;
            StringBuilder buffer = new StringBuilder(size);
            if (GetUserName(buffer, ref size))
            {
                string user = buffer.ToString();
                Console.WriteLine($"User: {user}");
            }
        }
    }
}
