using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
      timer1.Interval = 1000 * 60 * 10; // 10 minutes
      try {
        twitter = new Twitter(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, SecretKeys.AccessToken, SecretKeys.AccessTokenSecret);
        twitter.Online();
      } catch {
        timer1.Enabled = true;
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
      try {
        twitter.Offline();
      } catch {

      }
    }

    private void timer1_Tick(object sender, EventArgs e) {
      try {
        twitter = new Twitter(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, SecretKeys.AccessToken, SecretKeys.AccessTokenSecret);
        twitter.Online();
        timer1.Enabled = false;
      } catch {

      }
    }
  }
}
