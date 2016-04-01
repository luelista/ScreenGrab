using net.kvdb.webdav;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrab6.HelperLib {
    public partial class WebDavConnectionDialog : Form {
        WebDAVClient client;

        public WebDAVClient Client {
            get
            {
                return client;
            }
            set
            {
                client = value;
                textBox1.Text = client.ConnectionName;
                textBox2.Text = client.URL.ToString();
                textBox3.Text = client.User;
                textBox4.Text = client.Pass;
            }
        }

        public WebDavConnectionDialog() {
            InitializeComponent();
            client = new WebDAVClient();
        }

        private void WebDavConnectionDialog_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                client.ConnectionName = textBox1.Text;
                client.URL = new Uri(textBox2.Text);
                client.User = textBox3.Text;
                client.Pass = textBox4.Text;
                DialogResult = DialogResult.OK;
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
