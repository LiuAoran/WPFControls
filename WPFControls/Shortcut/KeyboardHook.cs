using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shortcut
{

    public class KeyPressedEventArgs : EventArgs
    {
        public Key KeyPressed { get; private set; }

        public KeyPressedEventArgs(Key keyPressed)
        {
            KeyPressed = keyPressed;
        }
    }

    internal class KeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc hookCallback;
        private IntPtr hookId = IntPtr.Zero;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public KeyboardHook()
        {
            hookCallback = HookCallback;
            hookId = SetHook(hookCallback);
        }

        ~KeyboardHook()
        {
            UnhookWindowsHookEx(hookId);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                KeyPressed?.Invoke(this, new KeyPressedEventArgs(KeyInterop.KeyFromVirtualKey(vkCode)));
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        #region Native methods

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}
