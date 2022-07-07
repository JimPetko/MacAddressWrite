using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Threading;

/// <summary>
/// For demo purposes, there is a Raspberry Pi Zero connected through a UART adapter ()
/// 
/// </summary>








namespace MacAddressWrite
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        string uid, password, database, server, connectionstring;
        bool sqlConnected = false;
        bool serialConnected = false;
        bool serialMonitorOn = false;
        private SerialPort serialPort = new SerialPort();
        
        
        public Form1()
        {
            InitializeComponent();
            GetSerialPorts();
        }

        /// <summary>
        /// Connects to the MySql server and and retrieves the next available Mac Address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!sqlConnected)
            {
                sqlConnected = true;
                uid = tbx_UserName.Text;
                password = tbx_Password.Text;
                database = "mac_addresses";
                server = "localhost";
                connectionstring = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", server, database, uid, password);
                connection = new MySqlConnection(connectionstring);
                try
                {
                    connection.Open();
                    statusLabel_DatabaseConnection.ForeColor = Color.Green;
                    statusLabel_DatabaseConnection.Text = "Connected";
                    btn_Connect.Text = "Disconnect";
                    sqlConnected = true;
                    btn_WriteToEEPROM.Enabled = true;
                    GetMacAddress();
                }
                catch (MySqlException ex)
                {
                    sqlConnected = false;
                    statusLabel_DatabaseConnection.ForeColor = Color.Red;
                    switch (ex.Number)
                    {
                        case 0: //Error 0 is 'no connection available'
                            statusLabel_DatabaseConnection.Text = "Cannot Connect. Contact administrator";
                            break;

                        case 1045://error 1045 is 'incorrect login'
                            statusLabel_DatabaseConnection.Text = "Invalid Username/Password, Please Try Again";
                            break;
                    }
                }
            }
            else 
            {
                try
                {
                    connection.Close();
                    statusLabel_DatabaseConnection.Text = "Database Disconnected";
                    statusLabel_DatabaseConnection.ForeColor= Color.Red;
                    btn_Connect.Text = "Connect to DB";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        /// <summary>
        /// Attempts connection to the UART/Serial port with the user provided properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SerialConnect_Click(object sender, EventArgs e)
        {
            if (!serialConnected)
            {
                //UI control tasks
                serialConnected = true;
                StatusLabel_SerialConnection.Text = "Serial Connected";
                StatusLabel_SerialConnection.ForeColor = Color.Blue;
                btn_SerialConnect.Text = "Disconnect Serial";
                try
                {
                    serialPort.PortName = cbx_SerialPorts.Text;
                    serialPort.BaudRate = Int32.Parse(cbx_BaudRate.Text);
                    serialPort.Parity = Parity.None;
                    serialPort.Handshake = Handshake.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Open();
                }
                catch
                {
                    serialConnected = false;
                    StatusLabel_SerialConnection.Text = "Serial Error, Try Again";
                    StatusLabel_SerialConnection.ForeColor = Color.Red;
                    btn_SerialConnect.Text = "Connect Serial";
                }

            }
            else 
            {
                serialConnected = false;
                StatusLabel_SerialConnection.Text = "Serial Disconnected";
                StatusLabel_SerialConnection.ForeColor = Color.Purple;
                btn_SerialConnect.Text = "Establish Serial Connection";
            }
        }

        /// <summary>
        /// Writes the data to the EEPROM of the connected chip, Updates the table to indicate the Mac Address has been consumed
        /// Retrives another new MacAddress for the next unit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WriteToEEPROM_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if(StartUART_Sync())
                    Update_Table_OnSuccess();
                
                GetMacAddress();
            }
        }

        /// <summary>
        /// For now the user and password are hard coded, if these are needed to be input from the user, it can be gathered by a TextBox or 2.
        /// This application currently will only function on a Raspberry Pi with UART enabled and connected.
        /// </summary>
        private bool StartUART_Sync() 
        {
            // \n is the return char escape in c#
            string user = "jpetko\n";
            string password = "123reallyComplicatedPassword\n";// Credientials hard coded is bad prac but its only for demonstration purposes.

            string cmd = "MacAddressDemo.txt <<< \""+ lab_MacAddress.Text +"\"\n"; 
            //while better to parse the MacAddress write into bytes,
            //when going over UART to a linux kernel, a string is easier.
            serialPort.Write(user);
            Thread.Sleep(5000);
            serialPort.Write(password);
            Thread.Sleep(5000);
            serialPort.Write(cmd);

            if(serialPort.ReadLine()=="") 
            {
                Console.WriteLine("Success");
                return true;
            }
            else
                return false;
        }

        private void btn_SerialMonitor_Click(object sender, EventArgs e)
        {
            if (!serialMonitorOn && serialPort.IsOpen)
            {
                btn_SerialMonitor.Text = "Serial Monitor <<";
                this.Size = new System.Drawing.Size(895, 345);
                bwrk_Monitor.RunWorkerAsync();
            }
            else 
            {
                this.Size = new Size(465, 345);
            }
        }

        private void bwrk_Monitor_DoWork(object sender, DoWorkEventArgs e)
        {
            rtb_SerialContent.Text += serialPort.ReadLine();
        }



        /// <summary>
        /// Closes connections that might generate errors in other apps if left open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!statusLabel_DatabaseConnection.Text.Contains("Disconnected"))
                connection.Close();
            if (!StatusLabel_SerialConnection.Text.Contains("Disconnected"))
                serialPort.Close();
        }

        /// <summary>
        /// Gets the next available Mac Address from the MySQL Instance.
        /// </summary>
        private void GetMacAddress()
        {
            if (sqlConnected) 
            {
                string query = "SELECT `available_mac`.`MAC_Address`, `available_mac`.`isAvailable` FROM `mac_addresses`.`available_mac`;";
                MySqlCommand cmd = new MySqlCommand(query,connection);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                List<string> MacList = new List<string>();
                while (reader.Read()) 
                {
                    if (reader.GetString(1) == "True") 
                    {
                        lab_MacAddress.Text = reader.GetString(0);
                        reader.Close();
                        break;
                    }
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(0));
                }
                
            }

        }

        /// <summary>
        /// If the MAC Address is successfully written to the EEPROM, then mark the MAC Address as unavailable.
        /// </summary>
        private void Update_Table_OnSuccess() 
        {
            //if write complete correctly with no error
            string query = "UPDATE available_mac SET isAvailable = False where mac_address =\"" + lab_MacAddress.Text + "\";";
            MySqlCommand cmd = new MySqlCommand(query,connection);
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Gets the list of available COM ports and populates the combo boxes for port and baud rate
        /// </summary>
        private void GetSerialPorts() 
        {
            string[] ArrayComPortsNames = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            
            foreach (string s in ArrayComPortsNames) 
            {
                cbx_SerialPorts.Items.Add(s);
            }
            cbx_SerialPorts.SelectedIndex = 0;

            cbx_BaudRate.Items.Add("115200");
            cbx_BaudRate.Items.Add("57600");
            cbx_BaudRate.Items.Add("38400");
            cbx_BaudRate.Items.Add("19200");
            cbx_BaudRate.Items.Add("14400");
            cbx_BaudRate.Items.Add("9600");
            cbx_BaudRate.SelectedIndex = 0;
        }

    }
}
