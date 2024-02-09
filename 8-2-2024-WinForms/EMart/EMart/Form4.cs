using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMart {
    public partial class Form4 : Form {
        public Form4() {
            InitializeComponent();
        }

        private async void Form4_Load(object sender, EventArgs e) {
            webBrowser1.Navigate("https://news.google.com/home");
            webBrowser1.ScriptErrorsSuppressed = true;

            var soundPlayer = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
            soundPlayer.Play();
            await Task.Delay(1800);
            soundPlayer.Play();

        }
    }
}
