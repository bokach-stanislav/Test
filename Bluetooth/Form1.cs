using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bluetooth
{
    public partial class Form1 : Form
    {
        BluetoothDeviceInfo[] infos = { };
        BluetoothDeviceInfo selected = null;
        bool inRange = false;
        bool isRefreshing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDeviceList();
            //var login = WindowsIdentity.GetCurrent().Name;
            var login = Environment.UserName;
            labelLogin.Text = "Logged in as: " + login;

            var res = Encrypt(login);
            tbEncrypted.Text = string.Format("{0}\r\n\r\nRoundtrip: {1}", res.Encrypted, res.Roundtrip);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void RefreshDeviceList()
        {
            bRefresh.Enabled = false;
            labelStatus.Text = "Status: Loading devices...";
            devicesLoader.RunWorkerAsync();
        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = infos[cbDevices.SelectedIndex];
            RefreshDeviceStatus();
        }

        private void RefreshDeviceStatus()
        {
            if (selected == null)
            {
                labelStatus.Text = "Status: No Device selected";
            }
            else
            {
                if (!isRefreshing)
                {
                    isRefreshing = true;
                    inRangeTester.RunWorkerAsync(selected);
                }
            }
        }

        private void devicesLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BluetoothClient client = new BluetoothClient();
                infos = client.DiscoverDevices();
            }
            catch
            { }
        }

        private void devicesLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbDevices.Items.Clear();
            cbDevices.Items.AddRange(infos.Select(i => i.DeviceName).ToArray());
            bRefresh.Enabled = true;
            RefreshDeviceStatus();
        }

        private void inRangeTester_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var device = (BluetoothDeviceInfo)e.Argument;
                device.GetServiceRecords(Guid.NewGuid());
                inRange = true;
            }
            catch (SocketException)
            {
                inRange = false;
            }
        }

        private void inRangeTester_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isRefreshing = false;
            labelStatus.Text = inRange ? "Status: In range" : "Status: Out of range";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshDeviceStatus();
        }

        private class EncryptionResult
        {
            public string Encrypted;
            public string Roundtrip;
        }

        private EncryptionResult Encrypt(string login)
        {
            var data = Encoding.UTF8.GetBytes(login);
            using (RijndaelManaged algorythm = new RijndaelManaged())
            {
                algorythm.GenerateKey();
                algorythm.GenerateIV();
                using (var encryptor = algorythm.CreateEncryptor())
                using (var memStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] encrypted = memStream.ToArray();
                    //return BitConverter.ToString(encrypted);


                    using (var decryptor = algorythm.CreateDecryptor())
                    using (MemoryStream from = new MemoryStream(encrypted))
                    using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                    {
                        var result = new byte[encrypted.Length];
                        var count = reader.Read(result, 0, result.Length);
                        return new EncryptionResult()
                        {
                            Encrypted = BitConverter.ToString(encrypted).Replace('-', ' '),
                            Roundtrip = Encoding.UTF8.GetString(result.Take(count).ToArray())
                        };
                    }
                    
                }
            }
        }

    }
}
