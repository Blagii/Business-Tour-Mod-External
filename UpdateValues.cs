using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BusinessTourMod
{
    public partial class BusinessTourMod
    {
        private void UpdateAddress_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // Live diagnosis: show in the UI why nothing is happening.
                try
                {
                    IntPtr handle = Memory.GetProcessHandle();
                    SetStatusText(handle != IntPtr.Zero
                        ? "Povezano sa igrom (base 0x" + _BaseAddress.ToString("X") + ")"
                        : "Nema procesa 'BusinessTour' ili pristup odbijen (Win32 " + Memory.LastWin32Error + ")");
                }
                catch (Exception ex)
                {
                    Program.LogError(ex);
                }

                {
                    //Money Address
                    int Pointer = Memory.GetPointerAddress(_BaseAddress + 0x012CC25C, new[] {0x60, 0x54});
                    int Money = Memory.ReadInteger(Pointer, 4);
                    int EncryptedMoney = Memory.ReadInteger(Pointer - 4, 4);
                    int EncryptingKey = Memory.ReadInteger(Pointer - 8, 4);
                    int BooleanTrue = Memory.ReadInteger(Pointer + 4, 4);

                    if ((Money ^ EncryptingKey) == EncryptedMoney && BooleanTrue == 1)
                    {
                        _MoneyAddress = Pointer;
                        _MoneyEncryptingKey = EncryptingKey;
                    }
                }

                {
                    //Bonus Address
                    int Pointer = Memory.GetPointerAddress(_BaseAddress + 0x012C6090, new[] {0x760, 0x5C, 0x0});
                    int EncryptingKey = Memory.ReadInteger(Pointer, 4);
                    int EncryptedBonus = Memory.ReadInteger(Pointer + 4, 4);
                    int Bonus = Memory.ReadInteger(Pointer + 8, 4);
                    int BooleanTrue = Memory.ReadInteger(Pointer + 12, 4);
                    if ((Bonus ^ EncryptingKey) == EncryptedBonus && BooleanTrue == 1)
                    {
                        _BonusAddress = Pointer;
                    }
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private void UpdateValues_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                {
                    if (FreePair.Checked)
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7) + 8, 0, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7) + 4, 0 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                    else
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7) + 8, 2, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 7) + 4, 2 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                }
                
                {
                    if (FreeDouble.Checked)
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8) + 8, 0, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8) + 4, 0 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                    else
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8) + 8, 2, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 8) + 4, 2 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                }

                {
                    if (FreeCard.Checked)
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9) + 8, 0, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9) + 4, 0 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                    else
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9) + 8, 2, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 9) + 4, 2 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                }

                {
                   if (FreeReroll.Checked)
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10) + 8, 0, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10) + 4, 0 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                    else
                    {
                        int EncryptingKey = Memory.ReadInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10), 4);
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10) + 8, 3, 4); //Writing a 4 byte integer
                        Memory.WriteInteger(_BonusAddress + (OBSCURED_OBJECT_SIZE * 10) + 4, 3 ^ EncryptingKey, 4); //Writing a 4 byte integer
                    }
                }
                
                {
                    // ReSharper disable once InconsistentNaming
                    for(int i = 0; i < 4; i++)
                    {
                        if (_JailedPlayer[i])
                        {
                            int AddressModificatior = 168 * i;
                            Memory.WriteInteger((_MoneyAddress - AddressModificatior) - 20, 3, 4); //Writing a 4 byte integerMemory.WriteInteger(this.MoneyAddress - AddressModificatior - 4, MoneyWanted ^ this.EncryptingKey, 4); //Writing a 4 byte integer
                        }
                        else
                        {
                            int AddressModificatior = 168 * i;
                            Memory.WriteInteger(_MoneyAddress - AddressModificatior - 20, -1, 4); //Writing a 4 byte integerMemory.WriteInteger(this.MoneyAddress - AddressModificatior - 4, MoneyWanted ^ this.EncryptingKey, 4); //Writing a 4 byte integer
                        }

                        if(NeverJail.Checked)
                        {
                            Memory.WriteInteger(_MoneyAddress - 20, -1, 4); //Writing a 4 byte integerMemory.WriteInteger(this.MoneyAddress - AddressModificatior - 4, MoneyWanted ^ this.EncryptingKey, 4); //Writing a 4 byte integer
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
