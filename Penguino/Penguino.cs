using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Penguino
{
    public partial class Penguino : Form
    {
        public Penguino()
        {
            InitializeComponent();
            addressBar.Select();
            addressBar.KeyPress += addressBar_KeyPress;
        }

        // Load the specified URL in the browser
        public void Browse()
        {
            chromiumWebBrowser1.Load(addressBar.Text);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Browse();
        }

        // Allow user to go visit a webpage by pressing the Enter key
        private void addressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the Enter key from producing a beep sound
                Browse(); // Call to load the specified URL
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Back();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Forward();
        }

        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Update the address bar text when the browser is loading a new page
            if (e.IsLoading)
            {
                Invoke((MethodInvoker)(() =>
                {
                    addressBar.Text = e.Browser.MainFrame.Url;
                }));
            }
            // Update the address bar text when the browser finishes loading a page
            Invoke((MethodInvoker)(() =>
            {
                addressBar.Text = e.Browser.MainFrame.Url;
            }));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application when the "Exit" menu option is clicked
            Application.Exit();
        }

        private void v100SinnedpenguinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 
            string url = "https://github.com/sinnedpenguin";
            addressBar.Text = url;
            Browse();
            //
        }
    }
}