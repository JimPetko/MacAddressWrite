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

namespace MacAddressWrite
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        string uid, password, database, server, connectionstring;
        bool sqlConnected = false;
        bool serialConnected = false;
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
                StartUART_Sync();
                Update_Table_OnSuccess();
                GetMacAddress();
            }
        }

        /// <summary>
        /// For now the user and password are hard coded, if these are needed to be input from the user, it can be gathered by a TextBox or 2.
        /// This application currently will only function on a Raspberry Pi with UART enabled and connected.
        /// </summary>
        private void StartUART_Sync() 
        {
            string user = "pi\r\n";
            string password = "raspberry\r\n";
            string cmd = "sudo apt-get -y update && sudo apt-get -y upgrade && sudo shutdown -now\r\n"; //this will just bring the raspberry pi up to date.
            serialPort.Write(user);
            Thread.Sleep(5000);
            serialPort.Write(password);
            Thread.Sleep(5000);
            serialPort.Write(cmd);
            Thread.Sleep(5000);
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
