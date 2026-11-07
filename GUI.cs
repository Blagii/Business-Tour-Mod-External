using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BusinessTourMod
{
    public partial class BusinessTourMod
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAddress.RunWorkerAsync();
#if !CLEAN_BUILD
            CheckDebugger.RunWorkerAsync();
#endif
            UpdateValues.RunWorkerAsync();
            UpdateColor.RunWorkerAsync();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int ScrollValue = MoneyTrackBar.Value;
            switch (ScrollValue)
            {
                case 1:
                    MoneyAmount.Value = 25000;
                    break;

                case 2:
                    MoneyAmount.Value = 50000;
                    break;

                case 3:
                    MoneyAmount.Value = 100000;
                    break;

                case 4:
                    MoneyAmount.Value = 250000;
                    break;

                case 5:
                    MoneyAmount.Value = 500000;
                    break;

                case 6:
                    MoneyAmount.Value = 1000000;
                    break;

                case 7:
                    MoneyAmount.Value = 2500000;
                    break;

                case 8:
                    MoneyAmount.Value = 5000000;
                    break;

                case 9:
                    MoneyAmount.Value = 10000000;
                    break;

                case 10:
                    MoneyAmount.Value = 20000000;
                    break;

                default:
                    MoneyAmount.Value = 0;
                    break;
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This software was made by Gayben#7736 
Special thanks to Spyder#3252 for helping me manipulating the memory", @"About this software", MessageBoxButtons.OK);
        }
    }
}
