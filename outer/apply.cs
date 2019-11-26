using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR.outer
{
    public partial class apply : Form
    {
        public apply()
        {
            InitializeComponent();
        }
        //返回登录
        private void button3_Click(object sender, EventArgs e)
        {
            login main = new login();
            main.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("申请已提交，请注意短信通知！！！");
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void lblPwdMsg_Click(object sender, EventArgs e)
        {

        }

        private void lblUidMsg_Click(object sender, EventArgs e)
        {

        }

        private void lblPwdConfirmMsg_Click(object sender, EventArgs e)
        {

        }
    }
}
