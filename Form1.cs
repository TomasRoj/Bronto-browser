using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace BRONTO
{
    public partial class Form1 : Form
    {

        public ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("www.google.com");
            // Add it to the form and fill it to the form window.
            this.pBrowser.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            chromeBrowser.Forward();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
            chromeBrowser.Load(url);
            this.Text = "Bronto - browser:" + " " + url;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chromeBrowser.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            chromeBrowser.Load("www.google.com");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void urlTextBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                string url = urlTextBox.Text;
                chromeBrowser.Load(url);
                this.Text = "Bronto - browser:" + " " + url;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Form().Show();
        }
    }
}
