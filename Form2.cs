using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Windows.Forms;
using System.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.Net;

namespace Rx_des_capteurs_sans_fils
{
    public partial class Form2  
    {

        const Boolean m_noBluetooth = false;
        private Object m_lock = new object();//    'To apply 'volatile' access to the m_devices shared field.
        private DateTime m_startTime, m_endTime;
        private BluetoothDeviceInfo[] m_devices;
        public IList <Host> Hosts = new List <Host>();
        public Host LocalHost;
        static Form2 obj;

        public static  Form2 getInstance()
        {
            if ((obj == null))
            {
                obj = new Form2();
                return obj;
            }
            return obj;
        }

        public Form2()
        {
            InitializeComponent();
        }

        
        public static string GETMACADR()
        {
            var myRadio = BluetoothRadio.PrimaryRadio;
            if (myRadio == null)
            {
                MessageBox .Show("Aucun matériel radio ou pile logicielle non pris en charge");
                return null ;
            }
            return myRadio.LocalAddress.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //StartBluetooth();

            AdrLocalTextBox.Text = GETMACADR();
            DiscoveryFlags flags = new DiscoveryFlags(false, false, false, true);
            System.Threading.ThreadPool.QueueUserWorkItem(BackgroundDiscoverAndFill3, flags );
            SetDiscoveringState("Détection...");
        }

        private void SetDiscoveringState(string state)
        {
            if (state == null)
            {
                state = "Vali&der";
                this.simpleButton1.Enabled = true;
            }
            else
            {
                this.simpleButton1.Enabled = false ;
            }
            this.simpleButton1 .Text = state;

	this.Adr1 .Text = state;

        }

        private void BackgroundDiscoverAndFill(object dummy)
        {
            bool newOnly = Convert.ToBoolean(dummy);
            DiscoveryFlags flags = new DiscoveryFlags(!newOnly, !newOnly, true, false);
            BackgroundDiscoverAndFill3(flags);
        }

        struct DiscoveryFlags
        {
            internal readonly bool m_authenticated;
            internal readonly bool m_remembered;
            internal readonly bool m_unknown;

            internal readonly bool
                m_discoOnly;
            public DiscoveryFlags(bool authenticated, bool remembered, bool unknown, bool discoverableOnly)
            {
                m_authenticated = authenticated;
                m_remembered = remembered;
                m_unknown = unknown;
                m_discoOnly = discoverableOnly;
            }
        }

        private void BackgroundDiscoverAndFill3(object dummy)
        {
            DiscoveryFlags flags = (DiscoveryFlags)dummy;
            if (m_noBluetooth)
            {
                //Beep();
                return;
            }
            BluetoothClient cli = new BluetoothClient();
            DateTime startTime = DateTime.UtcNow;
            BluetoothDeviceInfo[] devices = cli.DiscoverDevices(255, flags.m_authenticated, flags.m_remembered, flags.m_unknown, flags.m_discoOnly);
            DateTime endTime = DateTime.UtcNow;

            lock (m_lock)
            {
                m_startTime = startTime;
                m_endTime = endTime;
                m_devices = devices;
            }
            EventHandler handler = FillDevices;
            this.BeginInvoke(handler);
        }

        private void FillDevices(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(!this.InvokeRequired);
            BluetoothDeviceInfo[] devices = null;
            DateTime startTime = default(DateTime);
            DateTime endTime = default(DateTime);
            // Get the device list set by the background thread.
            lock (m_lock)
            {
                devices = m_devices;
                startTime = m_startTime;
                endTime = m_endTime;
            }
            FillDevices(devices, startTime, endTime, true);
        }
        private void FillDevices(BluetoothDeviceInfo[] devices, DateTime startTime, DateTime endTime, bool clearDisplay)
        {
            System.Diagnostics.Debug.Assert(!this.InvokeRequired);
            System.Diagnostics.Debug.Assert((devices != null));
            //
            SetDiscoveringState("Disco&vered");
            FillDevicesFill(devices);
            SetDiscoveringState("RSSI & Display...");
            DumpDeviceInfo(devices, startTime, endTime, clearDisplay);
            SetDiscoveringState(null);
        }

        private void DumpDeviceInfo(BluetoothDeviceInfo[] devices, DateTime startTime, DateTime endTime, bool clearDisplay)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
           //if (clearDisplay)
               //this.TB6.Text = string.Empty;
            DateTime localTime = startTime.ToLocalTime();
            sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Discovery process started at {0} UTC, {1} local, and ended at {2} UTC.", startTime, localTime, endTime);
            sb.Append(Environment.NewLine + Environment.NewLine);
           // this.TB6.Text += sb.ToString();
            bool doRssi = true;
            foreach (BluetoothDeviceInfo curDevice in devices)
            {
                sb.Length = 0;
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "* {0}", curDevice.DeviceName);
                sb.Append(Environment.NewLine);
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Address: {0}", curDevice.DeviceAddress);
                sb.Append(Environment.NewLine);
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Remembered: {2}, Authenticated: {0}, Connected: {1}", curDevice.Authenticated, curDevice.Connected, curDevice.Remembered);
                sb.Append(Environment.NewLine);
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "LastSeen: {0}, LastUsed: {1}", curDevice.LastSeen, curDevice.LastUsed);
                sb.Append(Environment.NewLine);
                DumpCodInfo(curDevice.ClassOfDevice, sb);
                if (doRssi)
                {
                    Int32 rssi = curDevice.Rssi;
                    if (rssi != Int32.MinValue)
                    {
                        sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Rssi: {0} (0x{0:X})", rssi);
                    }
                    else
                    {
                        sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Rssi: failed");
                    }
                    sb.Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
                //this.TB6.Text += sb.ToString();
            }
        }

        public static void DumpCodInfo(ClassOfDevice cod, System.Text.StringBuilder sb)
        {
            sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "CoD: (0x{0:X6})", cod.Value, cod);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, " Device:  {0} (0x{1:X2}) / {2} (0x{3:X4})", cod.MajorDevice, Convert.ToInt32(cod.MajorDevice), cod.Device, Convert.ToInt32(cod.Device));
            sb.Append(Environment.NewLine);
            sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, " Service: {0} (0x{1:X2})", cod.Service, Convert.ToInt32(cod.Service));
            sb.Append(Environment.NewLine);
        }

        private void FillDevicesFill(BluetoothDeviceInfo[] devices)
        {
            // Add a special device entry for the local device.
            //devices = AppendLocalDeviceInfo(devices);
            //
            FillDevicesFillNoAddLocal(devices);
        }

        private void FillDevicesFillNoAddLocal(BluetoothDeviceInfo[] devices)
        {
            // Apply to the combobox via data binding
            this.BluetoothDeviceInfoBindingSource.SuspendBinding();
            this.BluetoothDeviceInfoBindingSource.Clear();
            foreach (BluetoothDeviceInfo item in devices)
            {
                this.BluetoothDeviceInfoBindingSource.Add(item);
            }
            this.BluetoothDeviceInfoBindingSource.ResumeBinding();
            ////Interaction.Beep()
        }

        // Adds a special device entry for the local device.
        private BluetoothDeviceInfo[] AppendLocalDeviceInfo(BluetoothDeviceInfo[] devices)
        {
            BluetoothRadio localRadio = BluetoothRadio.PrimaryRadio;
            if (localRadio == null)
            {
                System.Windows.Forms.DialogResult rslt = MessageBox.Show ( "There is no Bluetooth hardware, or it uses unsupported software. Quit?", "No Bluetooth support", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (rslt != System.Windows.Forms.DialogResult.No)
                {
                    Application.Exit();
                }
            }
            System.Diagnostics.Debug.Assert(!(localRadio == null & devices.Length != 0), "PrimaryRadio is null -- but DiscoverDevices worked!");
            //
            // Handle gracefully anyway!
            if ((localRadio != null))
            {
                // Get the local MAC Address and create a device object.
                InTheHand.Net.BluetoothAddress localAddr = localRadio.LocalAddress;
                BluetoothDeviceInfo localBdi = new BluetoothDeviceInfo(localAddr);
                localBdi.DeviceName = "- local device -";
                // Copy the entries into a new array with the 'local' item at the front.
                BluetoothDeviceInfo[] devicesPlusLocal = new BluetoothDeviceInfo[devices.Length + 1];
                devices.CopyTo(devicesPlusLocal, 1);
                devicesPlusLocal[0] = localBdi;
                devices = devicesPlusLocal;
            }
            return devices;
        }

        private void AdrLocalTextBox_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ValiderChoix();
        }
        public void ValiderChoix()
        {
           Form2.getInstance (). LocalHost =new Host ("Local",AdrLocalTextBox .Text ,Convert .ToInt32 (id0.Text ),Convert .ToInt32 (niv0.Text ));

            if (!string.IsNullOrEmpty(Adr1.Text))
            {
                Host h1 = new Host(((BluetoothDeviceInfo )Adr1 .EditValue).DeviceName , Adr1.Text.ToString(), Convert.ToInt32(id1.EditValue),Convert.ToInt32( niv1.EditValue));
                Form2.getInstance ().Hosts.Add(h1);
            }
            if (!string.IsNullOrEmpty(adr2.Text))
            {
                Host h1 = new Host(((BluetoothDeviceInfo)adr2.EditValue).DeviceName, adr2.Text.ToString(), Convert.ToInt32(id2.EditValue), Convert.ToInt32(niv2.EditValue));
                Form2.getInstance ().Hosts.Add(h1);
            }
            if (!string.IsNullOrEmpty(adr3.Text))
            {
                Host h3 = new Host(((BluetoothDeviceInfo)adr3.EditValue).DeviceName, adr3.Text.ToString(), Convert.ToInt32(id3.EditValue), Convert.ToInt32(niv3.EditValue));
              Form2.getInstance ().  Hosts.Add(h3);
            }
            if (!string.IsNullOrEmpty(adr4.Text))
            {
                Host h4 = new Host(((BluetoothDeviceInfo)adr4.EditValue).DeviceName, adr4.Text.ToString(), Convert.ToInt32(id4.EditValue), Convert.ToInt32(niv4.EditValue));
                Form2.getInstance ().Hosts.Add(h4);
            }
            this.Hide();
          
            Form1.getInstance().InitBattery (Convert.ToInt32(textEdit3.EditValue));
            
            Form1.getInstance().Show();
            
        }

        private void Adr1_EditValueChanged(object sender, EventArgs e)
        {
            if (Adr1.EditValue != null)
            {
                Voisin1.Text = ((BluetoothDeviceInfo)Adr1.EditValue).DeviceName;
            }
        }

        private void adr2_EditValueChanged(object sender, EventArgs e)
        {
            if (adr2 .EditValue != null)
            {
                Voisin2.Text = ((BluetoothDeviceInfo)adr2 .EditValue).DeviceName;
            }
        }

        private void adr3_EditValueChanged(object sender, EventArgs e)
        {
            if (adr3 .EditValue != null)
            {
                Voisin3.Text = ((BluetoothDeviceInfo)adr3.EditValue).DeviceName;
            }
        }
        private void adr4_EditValueChanged(object sender, EventArgs e)
        {
            if (adr4 .EditValue != null)
            {
                Voisin4.Text = ((BluetoothDeviceInfo)adr4.EditValue).DeviceName;
            }
        }
    }
    public class Host
    {
        public Host(string Name, String adr, int id, int niveau)
        {
            this.Name = Name;
            this.Adr = adr;
            this.Id = id;
            this.Niveau = niveau;
        }

        public  String Name{get; set;}
        public String Adr { get; set;}
        public int Id { get; set;}
        public int Niveau { get; set;}

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Host temp = (Host)obj;
                if (String.Equals(temp.Adr, this.Adr))
                    return true;
                else
                    return false;
            }
            else
                return false;
            
        }
    }
}
