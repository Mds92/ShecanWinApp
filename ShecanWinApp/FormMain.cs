using System;
using System.Diagnostics;
using System.Windows.Forms;
using ShecanWinApp.Helpers;

namespace ShecanWinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FillNetworkComboBox();
        }

        private const string ActiveString = "Active";
        private const string DeactiveString = "Deactive";

        private void FillNetworkComboBox()
        {
            var itemIndex = 0;
            var activeNetworkInterface = NetworkHelper.GetActiveEthernetOrWifiNetworkInterface();
            foreach (var networkInterface in NetworkHelper.GetAllEthernetOrWifiNetworkInterface())
            {
                comboBoxNetworks.Items.Add(networkInterface.Name);
                if (activeNetworkInterface.Name.Equals(networkInterface.Name, StringComparison.InvariantCultureIgnoreCase))
                    comboBoxNetworks.SelectedIndex = itemIndex;
                itemIndex++;
            }
        }

        private void buttonSetDns_Click(object sender, EventArgs e)
        {
            var activeNetworkInterfaceName = comboBoxNetworks.SelectedItem.ToString();
            try
            {
                if (buttonSetDns.Text.Equals(ActiveString))
                {
                    NetworkHelper.SetDns(activeNetworkInterfaceName,
                        Constants.ShecanPreferredDnsServer,
                        Constants.ShecanAlternateDnsServerShecan,
                        OperationSystemEnum.Windows10,
                        message =>
                        {
                            Trace.WriteLine(message);
                        });
                    buttonSetDns.Text = "Deactive";
                }
                else
                {
                    NetworkHelper.RemoveDns(activeNetworkInterfaceName, 
                        OperationSystemEnum.Windows10,
                        message =>
                        {
                            Trace.WriteLine(message);
                        });
                    buttonSetDns.Text = ActiveString;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            
        }

        private void comboBoxNetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNetworkName = comboBoxNetworks.SelectedItem.ToString();
            var isDnsSet = NetworkHelper.IsDnsSet(selectedNetworkName,
                Constants.ShecanPreferredDnsServer,
                Constants.ShecanAlternateDnsServerShecan,
                message =>
                {
                    Trace.WriteLine(message);
                });
            if (isDnsSet)
                buttonSetDns.Text = DeactiveString;
            else 
                buttonSetDns.Text = ActiveString;
        }
    }
}
