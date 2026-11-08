using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BusinessTourMod
{
    public partial class BusinessTourMod : Form
    {
        private const int OBSCURED_OBJECT_SIZE = 16;
        private readonly int _BaseAddress;
        private int _BonusAddress;
        private int _MoneyAddress;
        private int _MoneyEncryptingKey;
        private readonly bool[] _JailedPlayer = new bool[4];

        public BusinessTourMod()
        {
            // Always build the UI first. The original code returned before this
            // call when the game was missing, which produced a blank / invisible
            // window and made it look like "nothing started".
            InitializeComponent();

            Process TargetProcess = Process.GetProcessesByName("BusinessTour").FirstOrDefault();
            if (TargetProcess == null)
            {
                _BaseAddress = 0;
                SetStatusText("Igra nije pokrenuta - pokreni Business Tour, pa restartuj mod");
                return;
            }

            foreach (ProcessModule Procmodule in TargetProcess.Modules)
            {
                if ("GameAssembly.dll" == Procmodule.ModuleName)
                {
                    long raw = Procmodule.BaseAddress.ToInt64();
                    if (raw > uint.MaxValue)
                    {
                        SetStatusText("Igra je 64-bitna - ovaj mod radi samo sa 32-bitnim adresama");
                        _BaseAddress = 0;
                        return;
                    }
                    _BaseAddress = unchecked((int)(uint)raw);
                }
            }

            SetStatusText(_BaseAddress != 0
                ? "Povezano sa igrom (GameAssembly.dll)"
                : "GameAssembly.dll nije pronadjen u procesu igre");
        }

        private void InfiniteJail_Click(object sender, EventArgs e)
        {
           _JailedPlayer[PlayersListBox.SelectedIndex] = !_JailedPlayer[PlayersListBox.SelectedIndex];
        }
    }
}
