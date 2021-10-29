using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetworkInfo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
               txtIp.Content= GetLocalIPAddress();
               txtMAC.Content= GetMAC();
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string GetMAC()
        {
            var macAddr =(from nic in NetworkInterface.GetAllNetworkInterfaces()where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()      ).FirstOrDefault();
            return macAddr.ToString().InsertCharAtDividedPosition(2, "-"); ;
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
    public static class StringExtenstions
    {
        public static string InsertCharAtDividedPosition(this string str, int count, string character)
        {
            var i = 0;
            while (++i * count + (i - 1) < str.Length)
            {
                str = str.Insert((i * count + (i - 1)), character);
            }
            return str;
        }
    }
}
