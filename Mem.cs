using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BusinessTourMod
{
    public class Memory
    {
        /////////////////////
        /////DLL Imports/////
        /////////////////////
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const uint PROCESS_VM_OPERATION = 0x0008;
        private const uint PROCESS_VM_READ = 0x0010;
        private const uint PROCESS_VM_WRITE = 0x0020;
        private const uint PROCESS_QUERY_INFORMATION = 0x0400;

        /////////////////////
        //////Variables//////
        /////////////////////
        public static IntPtr pHandle;  //Process Handle (cached)
        private static int _handlePid = -1;
        private static int _lastWin32Error;

        static string ExeName = "BusinessTour"; //Use the exename definied in the Trainer form

        /// <summary>True when a handle with read/write rights was obtained.</summary>
        public static bool IsAttached { get { return pHandle != IntPtr.Zero; } }

        /// <summary>Last Win32 error, useful when attaching fails.</summary>
        public static int LastWin32Error { get { return _lastWin32Error; } }

        // The original code used Process.Handle, which does not reliably grant
        // PROCESS_VM_WRITE / PROCESS_VM_OPERATION, and opened a fresh handle on
        // every single read (hundreds per second). Open once, cache by PID.
        private static void CloseCachedHandle()
        {
            if (pHandle != IntPtr.Zero)
            {
                CloseHandle(pHandle);
                pHandle = IntPtr.Zero;
            }
            _handlePid = -1;
        }

        public static IntPtr GetProcessHandle() //Find Process
        {
            try
            {
                Process[] ProcList = Process.GetProcessesByName(ExeName);
                if (ProcList.Length == 0)
                {
                    CloseCachedHandle();
                    _lastWin32Error = 0;
                    return IntPtr.Zero;
                }

                int pid = ProcList[0].Id;
                if (pHandle != IntPtr.Zero && _handlePid == pid)
                {
                    return pHandle;
                }

                CloseCachedHandle();
                pHandle = OpenProcess(
                    PROCESS_QUERY_INFORMATION | PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION,
                    false, pid);

                if (pHandle == IntPtr.Zero)
                {
                    _lastWin32Error = Marshal.GetLastWin32Error();
                    _handlePid = -1;
                    return IntPtr.Zero;
                }

                _handlePid = pid;
                _lastWin32Error = 0;
                return pHandle;
            }
            catch (Exception)
            {
                _lastWin32Error = Marshal.GetLastWin32Error();
                return IntPtr.Zero;
            }
        }

        // Addresses in this project are 32-bit ints; zero-extend them instead of
        // sign-extending when building the native pointer.
        private static IntPtr ToPtr(int address)
        {
            return new IntPtr((long)(uint)address);
        }

        private static bool Read(int address, byte[] buffer, int size)
        {
            IntPtr handle = GetProcessHandle();
            if (handle == IntPtr.Zero)
            {
                Array.Clear(buffer, 0, buffer.Length);
                return false;
            }

            IntPtr bytesRead;
            bool ok = ReadProcessMemory(handle, ToPtr(address), buffer, size, out bytesRead);
            if (!ok)
            {
                _lastWin32Error = Marshal.GetLastWin32Error();
                Array.Clear(buffer, 0, buffer.Length);
                CloseCachedHandle(); // force a fresh attach on the next call
            }
            return ok;
        }

        private static bool Write(int address, byte[] bytes, int size)
        {
            IntPtr handle = GetProcessHandle();
            if (handle == IntPtr.Zero)
            {
                return false;
            }

            IntPtr bytesWritten;
            bool ok = WriteProcessMemory(handle, ToPtr(address), bytes, size, out bytesWritten);
            if (!ok)
            {
                _lastWin32Error = Marshal.GetLastWin32Error();
                CloseCachedHandle();
            }
            return ok;
        }

        public static int GetBaseAddress(string ProcessName, string ModuleName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(ProcessName);
                ProcessModuleCollection modules = processes[0].Modules;
                ProcessModule RequestedModuleAddress = null;

                foreach (ProcessModule i in modules)
                {
                    if (i.ModuleName == ModuleName)
                    {
                        RequestedModuleAddress = i;
                    }
                }

                return unchecked((int)(uint)RequestedModuleAddress.BaseAddress.ToInt64());
            }
            catch
            {
                return 0;
            }
        }

        public static int GetPointerAddress(int Pointer, int[] Offset)
        {
            byte[] Buffer = new byte[4];

            Read(Pointer, Buffer, Buffer.Length);

            for (int x = 0; x < (Offset.Length - 1); x++)
            {
                Pointer = BitConverter.ToInt32(Buffer, 0) + Offset[x];
                Read(Pointer, Buffer, Buffer.Length);
            }

            Pointer = BitConverter.ToInt32(Buffer, 0) + Offset[Offset.Length - 1];

            return Pointer;
        }


        /////////////////////
        //Writing Functions//
        /////////////////////
        public static void WriteBytes(int Address, byte[] Bytes) //Write Byte Array
        {
            Write(Address, Bytes, Bytes.Length);
        }

        public static void WriteFloat(int Address, float Value) //Write a Float
        {
            Write(Address, BitConverter.GetBytes(Value), 4);
        }

        public static void WriteDouble(int Address, double Value) //Write a Double
        {
            Write(Address, BitConverter.GetBytes(Value), 8);
        }

        public static void WriteInteger(int Address, int Value, int size) //Write an Integer
        {
            Write(Address, BitConverter.GetBytes(Value), size);
        }

        public static void WriteString(int Address, string String) //Write a String
        {
            byte[] Buffer = new ASCIIEncoding().GetBytes(String);
            Write(Address, Buffer, Buffer.Length);
        }


        /////////////////////
        //Reading Functions//
        /////////////////////
        public static byte[] ReadByte(int Address, int Length) //ReadBytes
        {
            byte[] Buffer = new byte[Length];
            Read(Address, Buffer, Length);
            return Buffer;
        }

        public static float ReadFloat(int Address) //ReadFloat
        {
            byte[] Buffer = new byte[4];
            Read(Address, Buffer, 4);
            return BitConverter.ToSingle(Buffer, 0);
        }

        public static double ReadDouble(int Address) //ReadDouble
        {
            byte[] Buffer = new byte[8];
            Read(Address, Buffer, 8);
            return BitConverter.ToDouble(Buffer, 0);
        }

        public static int ReadInteger(int Address, int Length) //ReadInteger
        {
            byte[] Buffer = new byte[Length];
            Read(Address, Buffer, Length);
            return BitConverter.ToInt32(Buffer, 0);
        }

        public static string ReadString(int Address, int size) //ReadString
        {
            byte[] Buffer = new byte[size];
            Read(Address, Buffer, size);
            return new ASCIIEncoding().GetString(Buffer);
        }
    }
}
