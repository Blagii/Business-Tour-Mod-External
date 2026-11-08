using System;
using System.IO;
using System.Windows.Forms;
#if !CLEAN_BUILD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Memory;
using System.Net;
using System.Security.Cryptography;
#endif

namespace BusinessTourMod
{
    class Program
    {
        internal static readonly string LogPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup-error.log");

        internal static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText(LogPath,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine +
                    ex + Environment.NewLine + Environment.NewLine);
            }
            catch
            {
                // Never let logging break the app.
            }
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
#if !CLEAN_BUILD
                int BaseAddress = 0;

                var targetProcess = Process.GetProcessesByName("BusinessTour").FirstOrDefault();
                if (targetProcess == null)
                {
                    MessageBox.Show("Can't find Business Tour, please open the game");
                    return;
                }
                ProcessModuleCollection modules = targetProcess.Modules;

                foreach (ProcessModule procmodule in modules)
                {
                    if ("steam_api.dll" == procmodule.ModuleName)
                    {
                        BaseAddress = (int)procmodule.BaseAddress;
                    }
                }

                byte[] SteamID1 = Memory.ReadByte(BaseAddress + 0x345B8, 4);
                byte[] SteamID2 = Memory.ReadByte(BaseAddress + 0x345B8 + 4, 4);

                List<byte> list1 = new List<byte>(SteamID1);
                List<byte> list2 = new List<byte>(SteamID2);
                list1.AddRange(list2);

                byte[] TempSteamID = list1.ToArray();
                long SteamID64 = BitConverter.ToInt64(TempSteamID, 0);
                string SteamIDList = string.Empty;

                try
                {
                    WebResponse response = WebRequest.Create("http://goguardian.ml/registeredIDs.txt").GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream());
                    SteamIDList = streamReader.ReadToEnd();
                    streamReader.Close();
                    response.Close();
                }
                catch (WebException ex)
                {
                    MessageBox.Show("An error has occured while reaching the whitelist : " + ex.ToString());
                    return;
                }

                string PlayerSteamID;
                using (MD5 md = MD5.Create())
                {
                    byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(SteamID64.ToString()));
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < array.Length; i++)
                    {
                        stringBuilder.Append(array[i].ToString("x2"));
                    }
                    PlayerSteamID = stringBuilder.ToString();
                }

                if (!SteamIDList.Contains(PlayerSteamID))
                {
                    MessageBox.Show("You aren't allowed to use this software, if you think this is an error, contact Gayben#7736");
                    MessageBox.Show("Debug : " + PlayerSteamID);
                    return;
                }
#endif
                // Fail loudly instead of dying silently with an empty window.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (s, e) => LogError(e.Exception);
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                    LogError(e.ExceptionObject as Exception ?? new Exception(e.ExceptionObject.ToString()));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BusinessTourMod());
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ne mogu da pokrenem mod:" + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "Detalji su u: " + LogPath,
                                "Business Tour Mod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
