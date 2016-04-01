using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrab6.HelperLib {
    public partial class InputDlg : Form {
        public InputDlg() {
            InitializeComponent();
        }

        public String GetInput() {
            return textBox1.Text;
        }

        public static string InputBox(string title, string defValue) {
            var f = new InputDlg();
            f.Text = title;
            f.textBox1.Text = defValue;
            if (f.ShowDialog() == DialogResult.OK) {
                return f.textBox1.Text;
            } else {
                return null;
            }
        }

        private void InputDlg_Load(object sender, EventArgs e) {

        }
    }
}
