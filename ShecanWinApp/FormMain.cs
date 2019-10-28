using System.Windows.Forms;
using ShecanWinApp.Helpers;

namespace ShecanWinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            label1.Text = NetworkHelper.GetActiveEthernetOrWifiNetworkInterface().Name;
            NetworkHelper.SetDns(label1.Text, "1.1.1.1", "2.2.2.2", OperationSystemEnum.Windows10, null);
        }
    }
}
