using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)] 
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, MessageBoxOptions options); 
        
        static void Main(string[] args) 
        {
            while (true)
            {
                int leftBound = 0, rightBound = 100;
                int tries = 0;
                int answer;
                MessageBox(IntPtr.Zero, "Pick a number from 0 to 100", "Message", MessageBoxOptions.OK | MessageBoxOptions.IconInformation);
                while (true)
                {
                    var center = leftBound + (rightBound - leftBound) / 2;
                    answer = MessageBox(IntPtr.Zero, $"Is your number {center}?", "Number guesser", MessageBoxOptions.YesNoCancel | MessageBoxOptions.IconQuestion);
                    tries++;
                    if (answer == (int)MsgBoxButtons.Cancel)
                        break;
                    else if (answer == (int)MsgBoxButtons.Yes)
                    {
                        MessageBox(IntPtr.Zero, $"I have quessed in {tries} tries!", "Number guesser", MessageBoxOptions.OK);
                        break;
                    }
                    else
                    {
                        answer = MessageBox(IntPtr.Zero, $"Is your number bigger than {center}?", "Number guesser", MessageBoxOptions.YesNoCancel | MessageBoxOptions.IconQuestion);
                        if (answer == (int)MsgBoxButtons.Yes)
                            leftBound = center + 1;
                        else
                            rightBound = center - 1;
                        if (leftBound > rightBound)
                        {
                            MessageBox(IntPtr.Zero, $"You are lying!", "Number guesser", MessageBoxOptions.OK);
                            break;
                        }
                    }
                }
                answer = MessageBox(IntPtr.Zero, $"Do you want to play again?", "Number guesser", MessageBoxOptions.YesNo | MessageBoxOptions.IconQuestion);
                if(answer == (int)MsgBoxButtons.No)
                    break;
            }
        }
    }

    public enum MessageBoxOptions : uint 
    { 
        OK = 0x00000000, 
        OKCancel = 0x00000001, 
        AbortRetryIgnore = 0x00000002, 
        YesNoCancel = 0x00000003, 
        YesNo = 0x00000004, 
        RetryCancel = 0x00000005, 
        CancelTryContinue = 0x00000006, 
        IconError = 0x00000010, 
        IconQuestion = 0x00000020, 
        IconWarning = 0x00000030, 
        IconInformation = 0x00000040, 
        UserIcon = 0x00000080 
    }

    public enum MsgBoxButtons
    {
        Yes = 6,
        No = 7,
        Ok = 1,
        Cancel = 2
    }
}
