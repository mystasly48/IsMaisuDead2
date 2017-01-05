using System;
using System.Windows.Forms;
using System.Net.NetworkInformation; 

namespace IsMaisuDead2 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    Twitter twitter;

    private void Form1_Load(object sender, EventArgs e) {
      this.ShowInTaskbar = false;
      this.ShowIcon = false;
      this.Visible = false;
      if (NetworkInterface.GetIsNetworkAvailable()) {
        Initial();
      } else {
        NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
      if (NetworkInterface.GetIsNetworkAvailable()) {
        twitter.Offline();
      }
    }

    private void Initial() {
      twitter = new Twitter(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, SecretKeys.AccessToken, SecretKeys.AccessTokenSecret);
      twitter.Online();
      timer1.Enabled = false;
    }

    private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e) {
      if (e.IsAvailable) {
        Initial();
      }
    }
  }
}
