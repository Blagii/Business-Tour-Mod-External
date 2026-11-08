#if !CLEAN_BUILD
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BusinessTourMod
{
    public partial class BusinessTourMod
    {
        private void CheckDebugger_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                string[] Processes = {"Medusa", "Relyze", "ODA", "Hiew", "decompiler", "Disassembler", "Hopper", "radare", "Debugger", "dbg", "IlSpy", "DnSpy", "Binary", "IDA", "ArtMoney", "scanmem", "GameConqueror", "Cheat", "Squalr", "iHaxGamez", "Bit Slicer", "PINCE", "GameGuardian", "moding"};
                
                foreach (Process P in Process.GetProcesses())
                {
                    try
                    {
                        if (P.MainWindowTitle.Length <= 0)
                        {
                            continue;
                        }

                        foreach (string modSoftware in Processes)
                        {
                            if (P.MainWindowTitle.ToUpper().Contains(modSoftware.ToUpper()))
                            {
                                Application.Exit();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
#endif
