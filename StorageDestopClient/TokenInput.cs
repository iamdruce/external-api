using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageDestopClient
{
    public partial class TokenInput : Form
    {
        public string Token { get => token_tb.Text; }
        public TokenInput()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
