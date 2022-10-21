using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Windows.Forms;
using System.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.Net;

namespace Gossiping
{
    public partial class Form1_fix : DevExpress .XtraEditors  .XtraForm 
    {

        readonly Guid OurServiceClassId = new Guid("{29913A2D-EB93-40cf-BBB8-DEEE26452197}");
        readonly string OurServiceName = "32feet.NET Chat2";
        //
        volatile bool _closing;
        TextWriter _connWtr;
        BluetoothListener _lsnr;
        static Form1_fix obj;
        int nb_send_echec=0;
        int nb_send_success=0;
        int nb_envoi=0;
        
        const float chargeEnvoi  =  17.1F;
        const float chargeRecep = 20.1F;
        const float chargeEcout = 22.9F;
        public int compt;
        public static Form1_fix getInstance()
        {
            if ((obj == null))
            {
                obj = new Form1_fix();
                return obj;
            }
            return obj;
        }
        public Form1_fix()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var addr = BluetoothSelect();
            //if (addr == null)
            //{
            //    return;
            //}
            

            if (!(Voisin5.getInstance().LocalHost.Niveau == 0))
            {
                if (Voisin5.Protocol == 2)
                {
                    //foreach (Host h in Form2.getInstance().Hosts)
                    //{
                    if (Voisin5.getInstance().Hosts.Count > 0)
                    {

                        Random random = new Random();
                        Host h = Voisin5.getInstance().Hosts[random.Next(0, Voisin5.getInstance().Hosts.Count)];
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    //}
                }
                if (Voisin5.Protocol == 1)
                {
                    foreach (Host h in Voisin5.getInstance().Hosts)
                    {
                    
                    if (Voisin5.getInstance().Hosts.Count > 0)
                    {
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    }
                }
                if (Voisin5.Protocol == 3)
                {
                    //foreach (Host h in Form2.getInstance().Hosts)
                    //{
                    if (Voisin5.getInstance().UnUsedHosts.Count > 0)
                    {

                        Random random = new Random();
                        Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts.Count)];
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            Voisin5.getInstance().UnUsedHosts.Remove(h);
                            h.Used = true;
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    else
                    {
                        if (Voisin5.getInstance().Hosts.Count > 0)
                        {
                            foreach (Host hs in Voisin5.getInstance().Hosts)
                            {
                                Voisin5.getInstance().UnUsedHosts.Add(hs);
                            }

                            Random random = new Random();
                            Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts.Count)];
                            if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                            {
                                Voisin5.getInstance().UnUsedHosts.Remove(h);
                                h.Used = true;
                                var addr = BluetoothAddress.Parse("002233445566");
                                string line = h.Adr;
                                line = line.Trim();
                                if (!BluetoothAddress.TryParse(line, out addr))
                                {
                                    MessageBox.Show("Invalid address.");
                                    return;
                                }
                                BluetoothConnect(addr);
                                SendMessage(h.Name, this.textBoxInput.Text);
                                BluetoothDisconnect();
                                StartBluetooth();
                            }
                        }
                    }
                    //}
                }
            }

        
            
               
                     
                timer1.Start();
          compt = timer1.Interval/1000;
                timer2.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 30;
            //linearScaleComponent3.MaxValue = 5000;
            //linearScaleComponent4.MaxValue = 100;
            //linearScaleComponent3.Value  = 5000;
        }

        BluetoothAddress BluetoothSelect()
        {
            var dlg = new SelectBluetoothDeviceDialog();
            var rslt = dlg.ShowDialog();
            if (rslt != DialogResult.OK)
            {
                AddMessage(MessageSource.Info, "Selection Périphérique annulé");
                return null;
            }
            var addr = dlg.SelectedDevice.DeviceAddress;
            return addr;
        }

        private void StartBluetooth()
        {
            try {
                new BluetoothClient();
            } catch (Exception ex) {
                var msg = "initialisation Bluetooth  a échoué: " + ex;
                MessageBox.Show(msg);
                throw new InvalidOperationException(msg, ex);
            }
            // TODO Check radio?
            //
            // Always run server?
            StartListener();
        }

      
        void BluetoothConnect(BluetoothAddress addr)
        {
            var cli = new BluetoothClient();
            try {
                nb_send_success++;
                nb_envoi++;
                cli.Connect(addr, OurServiceClassId);
                var peer = cli.GetStream();
                SetConnection(peer, true, cli.RemoteEndPoint);
                ThreadPool.QueueUserWorkItem(ReadMessagesToEnd_Runner, peer);
                
                            } catch (SocketException ex) {
                                nb_send_echec++;
                                nb_send_success--;


                // Try to give a explanation reason by checking what error-code.
                // http://32feet.codeplex.com/wikipage?title=Errors
                // Note the error codes used on MSFT+WM are not the same as on
                // MSFT+Win32 so don't expect much there, we try to use the
                // same error codes on the other platforms where possible.
                // e.g. Widcomm doesn't match well, Bluetopia does.
                // http://32feet.codeplex.com/wikipage?title=Feature%20support%20table
                string reason;
                switch (ex.ErrorCode) {
                    case 10048: // SocketError.AddressAlreadyInUse
                        // RFCOMM only allow _one_ connection to a remote service from each device.

                        reason = "Il ya une connexion existante vers le service distant";
                        ConnectionCleanup();
                        cli.Close();
                        break;
                    case 10049: // SocketError.AddressNotAvailable
                        reason = "Le service n'est pas en cours d'exécution sur le périphérique distant";
                        break;
                    case 10064: // SocketError.HostDown
                        reason = "Chat2 Service not using RFCOMM (huh!!!)";
                        break;
                    case 10013: // SocketError.AccessDenied:
                        reason = "authentification requise";
                        break;
                    case 10060: // SocketError.TimedOut:
                        reason = "Timed-out";
                        break;
                    default:
                        reason = null;
                        break;
                }
                reason += " (" + ex.ErrorCode.ToString() + ") -- ";
                //
                var msg = "Connexion Bluetooth a échoué: " + MakeExceptionMessage(ex);
                msg = reason + msg;
                AddMessage(MessageSource.Error, msg);
                MessageBox.Show(msg);
            } catch (Exception ex) {
                var msg = "Connexion Bluetooth a échoué: " + MakeExceptionMessage(ex);
                AddMessage(MessageSource.Error, msg);
                MessageBox.Show(msg);
            }
        }

        private void StartListener()
        {
            var lsnr = new BluetoothListener(OurServiceClassId);
            lsnr.ServiceName = OurServiceName;
            lsnr.Start();
            _lsnr = lsnr;
            ThreadPool.QueueUserWorkItem(ListenerAccept_Runner, lsnr);
        }

        void ListenerAccept_Runner(object state)
        {
            var lsnr = (BluetoothListener)_lsnr;
            // We will accept only one incoming connection at a time. So just
            // accept the connection and loop until it closes.
            // To handle multiple connections we would need one threads for
            // each or async code.
            while (true) {
                SetBattery(chargeEcout);
                var conn = lsnr.AcceptBluetoothClient();
                var peer = conn.GetStream();
                SetConnection(peer, false, conn.RemoteEndPoint);
                
                ReadMessagesToEnd(peer);

            }
        }

        enum MessageSource
        {
            Local,
            Remote,
            Info,
            Error,
        }

        void AddMessage(MessageSource source, string message)
        {
            EventHandler action = delegate
            {
                string prefix;
                switch (source)
                {
                    case MessageSource.Local:
                        prefix = "Serveur: ";
                        break;
                    case MessageSource.Remote:
                        prefix = "Client: ";
                        break;
                    case MessageSource.Info:
                        prefix = "Info: ";
                        break;
                    case MessageSource.Error:
                        prefix = "Erreur: ";
                        break;
                    default:
                        prefix = "???:";
                        break;
                }
                AssertOnUiThread();
               
                   
                        this.textBox1.Text =
                    prefix + message + "\r\n"
                    + this.textBox1.Text;
                        
                

                
            };
            ThreadSafeRun(action);
        }

        void AddMessage(string Nom, string message)
        {
            EventHandler action = delegate
            {
                string prefix;
                
                prefix = Nom +": ";
                                    
                AssertOnUiThread();


                this.textBox1.Text =
            prefix + message + "\r\n"
            + this.textBox1.Text;




            };
            ThreadSafeRun(action);
        }
        #region Chat Log
        private void ClearScreen()
        {
            EventHandler action = delegate
            {
                AssertOnUiThread();
                this.textBox1.Text = string.Empty;
            };
            ThreadSafeRun(action);
        }
      

        private void ThreadSafeRun(EventHandler action)
        {
            Control c = this.textBox1;
            if (c.InvokeRequired)
            {
                c.BeginInvoke(action);
            }
            else
            {
                action(null, null);
            }
        }
        #endregion

        #region Connection Set/Close
        private void SetConnection(Stream peerStream, bool outbound, BluetoothEndPoint remoteEndPoint)
        {
            //if (_connWtr != null)
            //{
            //    AddMessage(MessageSource.Error, "Déjà connecté!");
            //    return;
            //}
            _closing = false;
            var connWtr = new StreamWriter(peerStream);
            connWtr.NewLine = "\r\n"; // Want CR+LF even on UNIX/Mac etc.
            _connWtr = connWtr;
            //ClearScreen();
            AddMessage(MessageSource.Info,
                (outbound ? "connecté à" : "connexion à partir de")
                // Can't guarantee that the Port is set, so just print the address.
                // For more info see the docs on BluetoothClient.RemoteEndPoint.
                + remoteEndPoint.Address);
        }

        private void ConnectionCleanup()
        {
            _closing = true;
            var wtr = _connWtr;
            //_connStrm = null;
            _connWtr = null;
            //_lsnr.Stop();
            if (wtr != null)
            {
                try
                {
                    wtr.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Nettoyage de fin de connexion" + MakeExceptionMessage(ex));
                }
            }
        }

        void BluetoothDisconnect()
        {
            AddMessage(MessageSource.Info, "Déconnexion");
            ConnectionCleanup();
        }
        #endregion

        #region Connection I/O
        private bool Send(string message)
        {
            if (_connWtr == null)
            {
                //MessageBox.Show("Pas de connexion.");
                return false;
            }
            try
            {
                _connWtr.WriteLine(message);
                _connWtr.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("La connexion a été perdu! (" + MakeExceptionMessage(ex) + ")");
                ConnectionCleanup();
                return false;
            }
        }

        private void ReadMessagesToEnd_Runner(object state)
        {
            Stream peer = (Stream)state;
            ReadMessagesToEnd(peer);
            //BluetoothDisconnect();
        }
        string info = "";
      
        private void ReadMessagesToEnd(Stream peer)
        {
            try
            {
                var rdr = new StreamReader(peer);
         

            while (true)
            {
                string line;
                
                try
                {
                    line = rdr.ReadLine();
                    if (line != null)
                    {
                                              info = line;
                    }
                   

                   

                    SetBattery(chargeRecep);
           
                }
                catch (IOException ioex)
                {
                    if (_closing)
                    {
                        // Ignore the error that occurs when we're in a Read
                        // and _we_ close the connection.
                    }
                    else
                    {
                        AddMessage(MessageSource.Error, "La connexion a été fermée "
                            + MakeExceptionMessage(ioex));
                    }
                    break;
                }
                if (line == null)
                {
                    AddMessage(MessageSource.Info, "La connexion a été fermée.");
                    ///********************************
                    
                     
                        if (!(Voisin5.getInstance().LocalHost.Niveau == 0))
                        {
                           
                            if (Voisin5.Protocol == 2)
                            {
                                //foreach (Host h in Form2.getInstance().Hosts)
                                //{
                                if (Voisin5.getInstance().Hosts.Count > 0)
                                {

                                    Random random = new Random();
                                    Host h = Voisin5.getInstance().Hosts[random.Next(0, Voisin5.getInstance().Hosts.Count)];
                                    if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                                    {
                                        var addr = BluetoothAddress.Parse("002233445566");
                                        string adr = h.Adr;
                                        adr = adr.Trim();
                                        if (!BluetoothAddress.TryParse(adr, out addr))
                                        {
                                            MessageBox.Show("Invalid address.");
                                            return;
                                        }
                                        BluetoothDisconnect();
                                        StartBluetooth();
                                        BluetoothConnect(addr);
                                        SendMessage(h.Name, info);
                                    

                                    }
                                }
                                //}
                            }
                            if (Voisin5.Protocol == 1)
                            {
                                foreach (Host h in Voisin5.getInstance().Hosts)
                                {

                                    if (Voisin5.getInstance().Hosts.Count > 0)
                                    {
                                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                                        {
                                            var addr = BluetoothAddress.Parse("002233445566");
                                            string adr = h.Adr;
                                            adr = adr.Trim();
                                            if (!BluetoothAddress.TryParse(adr, out addr))
                                            {
                                                MessageBox.Show("Invalid address.");
                                                return;
                                            }
                                            BluetoothDisconnect();
                                            //StartBluetooth();
                                            BluetoothConnect(addr);
                                            SendMessage(h.Name, info);
                                            
                                        }
                                    }
                                }
                            }
                            if (Voisin5.Protocol == 3)
                            {
                                //foreach (Host h in Form2.getInstance().Hosts)
                                //{
                                if (Voisin5.getInstance().UnUsedHosts.Count > 0)
                                {

                                    Random random = new Random();
                                    Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts .Count)];
                                    if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                                    {
                                        Voisin5.getInstance().UnUsedHosts.Remove(h);
                                        h.Used = true;
                                        var addr = BluetoothAddress.Parse("002233445566");
                                        string adr = h.Adr;
                                        adr = adr.Trim();
                                        if (!BluetoothAddress.TryParse(line, out addr))
                                        {
                                            MessageBox.Show("Invalid address.");
                                            return;
                                        }
                                        BluetoothDisconnect();
                                        StartBluetooth();
                                        BluetoothConnect(addr);
                                        SendMessage(h.Name, info);
                                      
                                    }
                                }
                                else
                                {
                                    if (Voisin5.getInstance().Hosts.Count > 0)
                                    {
                                        foreach (Host hs in Voisin5.getInstance().Hosts)
                                        {
                                            Voisin5.getInstance().UnUsedHosts.Add(hs);
                                        }

                                        Random random = new Random();
                                        Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts.Count)];
                                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                                        {
                                            Voisin5.getInstance().UnUsedHosts.Remove(h);
                                            h.Used = true;
                                            var addr = BluetoothAddress.Parse("002233445566");
                                            string adr = h.Adr;
                                            adr = adr.Trim();
                                            if (!BluetoothAddress.TryParse(line, out addr))
                                            {
                                                MessageBox.Show("Invalid address.");
                                                return;
                                            }
                                            BluetoothDisconnect();
                                            StartBluetooth();
                                            BluetoothConnect(addr);
                                            SendMessage(h.Name, info);
                                          
                                        }
                                    }
                                }
                                //}
                            }
                        }
                    




                    timer1.Start();
                    compt = timer1.Interval / 1000;
                    timer2.Start();
                    break;
                }
                AddMessage(MessageSource.Remote, line);
                //ConnectionCleanup();
               //BluetoothDisconnect();
                ///***************************
               ///
               
            }//while
            ConnectionCleanup();
            }
            catch (Exception ex)
            {
                return;
            }
           
        }
        #endregion

        #region Radio
       

        static void DisplayPrimaryBluetoothRadio(TextWriter wtr)
        {
            var myRadio = BluetoothRadio.PrimaryRadio;
            if (myRadio == null)
            {
                wtr.WriteLine("Aucun matériel radio ou pile logicielle non pris en charge");
                return;
            }
            var mode = myRadio.Mode;
            // Warning: LocalAddress is null if the radio is powered-off.
            wtr.WriteLine("* Radio, address: {0:C}", myRadio.LocalAddress);
            wtr.WriteLine("Mode: " + mode.ToString());
            wtr.WriteLine("Name: " + myRadio.Name);
            wtr.WriteLine("HCI Version: " + myRadio.HciVersion
                + ", Revision: " + myRadio.HciRevision);
            wtr.WriteLine("LMP Version: " + myRadio.LmpVersion
                + ", Subversion: " + myRadio.LmpSubversion);
            wtr.WriteLine("ClassOfDevice: " + myRadio.ClassOfDevice
                + ", device: " + myRadio.ClassOfDevice.Device
                + " / service: " + myRadio.ClassOfDevice.Service);
            wtr.WriteLine("S/W Manuf: " + myRadio.SoftwareManufacturer);
            wtr.WriteLine("H/W Manuf: " + myRadio.Manufacturer);
        }
        #endregion
        private static string MakeExceptionMessage(Exception ex)
        {
#if !NETCF
            return ex.Message;
#else
            // Probably no messages in NETCF.
            return ex.GetType().Name;
#endif
        }

        private void AssertOnUiThread()
        {
            Debug.Assert(!this.textBox1.InvokeRequired, "UI access from non UI thread!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            compt = timer1.Interval / 1000;
            if (!(Voisin5.getInstance().LocalHost.Niveau == 0))
            {
                if (Voisin5.Protocol == 2)
                {
                    //foreach (Host h in Form2.getInstance().Hosts)
                    //{
                    if (Voisin5.getInstance().Hosts.Count > 0)
                    {

                        Random random = new Random();
                        Host h = Voisin5.getInstance().Hosts[random.Next(0, Voisin5.getInstance().Hosts.Count)];
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    //}
                }
                if (Voisin5.Protocol == 1)
                {
                    foreach (Host h in Voisin5.getInstance().Hosts)
                    {
                    
                    if (Voisin5.getInstance().Hosts.Count > 0)
                    {
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    }
                }
                if (Voisin5.Protocol == 3)
                {
                    //foreach (Host h in Form2.getInstance().Hosts)
                    //{
                    if (Voisin5.getInstance().UnUsedHosts.Count > 0)
                    {

                        Random random = new Random();
                        Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts.Count)];
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            Voisin5.getInstance().UnUsedHosts.Remove(h);
                            h.Used = true;
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                            BluetoothDisconnect();
                            StartBluetooth();
                        }
                    }
                    else
                    {
                        if (Voisin5.getInstance().Hosts.Count > 0)
                        {
                            foreach (Host hs in Voisin5.getInstance().Hosts)
                            {
                                Voisin5.getInstance().UnUsedHosts.Add(hs);
                            }

                            Random random = new Random();
                            Host h = Voisin5.getInstance().UnUsedHosts[random.Next(0, Voisin5.getInstance().UnUsedHosts .Count)];
                            if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                            {
                                Voisin5.getInstance().UnUsedHosts.Remove(h);
                                h.Used = true;
                                var addr = BluetoothAddress.Parse("002233445566");
                                string line = h.Adr;
                                line = line.Trim();
                                if (!BluetoothAddress.TryParse(line, out addr))
                                {
                                    MessageBox.Show("Invalid address.");
                                    return;
                                }
                                BluetoothConnect(addr);
                                SendMessage(h.Name, this.textBoxInput.Text);
                                BluetoothDisconnect();
                                StartBluetooth();
                            }
                        }
                    }
                    //}
                }
            }

        }

        private void SendMessage(string nomHost,string mesage)
        {
            var message = mesage;
            bool successSend = Send(message);
            if (successSend)
            {
                AddMessage(nomHost , message);
                SetBattery(chargeEnvoi);
                //this.textBoxInput.Text = string.Empty;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            {
                StartBluetooth();
                AddMessage(MessageSource.Info,
                    "Connect to another peripheral executing this application. write your text in the text box on the buttom and then click to send it. the radio on the destination peripheral should be conected and / or detectable.");
                this.textBox1.Select(0, 0); // Unselect the text.
                // Focus to the input-box.
#if !NETCF
                this.textBoxInput.Select();
#else
            this.textBoxInput.Focus();
#endif
            }
        }
        public void InitBattery(decimal val)
        {
            linearScaleComponent3.MaxValue = (float)val  ;
            linearScaleComponent4.MaxValue = 100;
            linearScaleComponent3.Value = (int)val;
        }
        public void SetBattery(float  val)
        {
            linearScaleComponent3.Value -= (float )val;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        break;
                    //
                    case CloseReason.WindowsShutDown:
                        return;
                    case CloseReason.ApplicationExitCall:
                        return;
                    case CloseReason.FormOwnerClosing:
                        return;
                    case CloseReason.MdiFormClosing:
                        return;
                    //
                    case CloseReason.None:
                        break;
                    case CloseReason.TaskManagerClosing:
                        break;
                    default:
                        break;
                }
                Form_Closing(sender, e);
            }
        }

        private void Form_Closing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Quit?", "Quit?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
                             
            }
            else
            {
                Voisin5.getInstance().Close();
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var wtr = new StringWriter())
            {
                DisplayPrimaryBluetoothRadio(wtr);
                MessageBox.Show (wtr.ToString(),"Info",MessageBoxButtons .OK, MessageBoxIcon.Information);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value)  * 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Voisin5.getInstance().Hosts.Clear();
            Voisin5.getInstance().UnUsedHosts.Clear();
            Voisin5.getInstance().Show ();
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!(Voisin5.getInstance().LocalHost.Niveau == 0))
                {
                    foreach (Host h in Voisin5.getInstance().Hosts)
                    {
                        if ((h.Niveau == Voisin5.getInstance().LocalHost.Niveau) || (h.Niveau == Voisin5.getInstance().LocalHost.Niveau - 1))
                        {
                            var addr = BluetoothAddress.Parse("002233445566");
                            string line = h.Adr;
                            line = line.Trim();
                            if (!BluetoothAddress.TryParse(line, out addr))
                            {
                                MessageBox.Show("Invalid address.");
                                return;
                            }
                            BluetoothConnect(addr);
                            SendMessage(h.Name, this.textBoxInput.Text);
                           // BluetoothDisconnect();
                           // StartBluetooth();
                        }
                    }
                }
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = compt.ToString ();
            compt--;
        }
        public string nb_envoie()
        {
            return nb_envoi.ToString ();
        }
        public string nb_fail()
        {
            return nb_send_echec.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_carac f = new Form_carac();
            f.Show();
            
        }

    }
}
