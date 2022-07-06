using System;
using System.IO.Ports;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;

namespace Interrupciones
{
    public partial class MainWindow : Window
    {
        private SerialPort Arduino;
        private string PortName = "COM3";
        private string incomString = "";
        private string prev = "";

        public MainWindow()
        {
            InitializeComponent();
            Arduino = new SerialPort();
            Arduino.BaudRate = 9600;
            Arduino.PortName = PortName;
            try
            {
                Arduino.Open();
                Arduino.DataReceived += Arduino_DataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nRestart the aplication");
                this.Close();
            }
            finally
            {
                this.Closing += OnWindowClosing;
            }
        }


        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Arduino.Close();
            string text = "";
            if (Arduino.IsOpen)
            {
                text = "Channel is still open";
            }
            else
            {
                text = "Channel is already closed";
            }
            MessageBox.Show(text, "FAREWELL", MessageBoxButton.OK);
        }

        private void Arduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string aux = Arduino.ReadLine();
            if (aux != prev)
            {
                try
                {
                    if (Int32.Parse(aux) == 0)
                    {
                        incomString = "Turned off";
                    }
                    else if (Int32.Parse(aux) == 1)
                    {
                        incomString = "Turned on";
                    }
                }
                catch (Exception exc)
                {
                    incomString = "An unexpected message was received";
                }
                Dispatcher.Invoke(changeText);
                prev = aux;
            }
        }

        private void changeText()
        {
            OnOffLabel.Text = incomString;
            if (incomString.Contains("of"))
            {
                TurnOnOffButton.Background = Brushes.Gray;
            }
            else
            {
                TurnOnOffButton.Background = Brushes.LightGreen;
            }
        }
    }
}