using HR.inside.function;
using HR.inside.manage;
using HR.inside.personage;
using HR.outer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR.inside
{
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }
        //定义窗口变量
        private organization organization;
        private personal personal;
        private feedback feedback;
        private administrator administrator;
        private help help;
        private changepassword changepassword;

        private void homepage_Load(object sender, EventArgs e)
        {
            //窗口变量赋值
            organization = new organization();
            personal = new personal();
            feedback = new feedback();
            administrator = new administrator();
            help = new help();
            changepassword = new changepassword();
        }
        //连接字符串 获取配置文件里的连接路径
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        //打开组织架构
        private void zuzhi_Click(object sender, EventArgs e)
        {
            organization.Show();
            panel.Controls.Clear();
            panel.Controls.Add(organization);
        }
        //打开人事
        private void renshi_Click(object sender, EventArgs e)
        {
            personal.Show();
            panel.Controls.Clear();
            panel.Controls.Add(personal);
        }
        //打开管理员
        private void button1_Click(object sender, EventArgs e)
        {
            administrator.Show();
            panel.Controls.Clear();
            panel.Controls.Add(administrator);
        }
        //打开反馈
        private void fankui_Click(object sender, EventArgs e)
        {
            feedback.Show();
            panel.Controls.Clear();
            panel.Controls.Add(feedback);
        }
        //打开帮助
        private void bangzhu_Click(object sender, EventArgs e)
        {
            help.Show();
            panel.Controls.Clear();
            panel.Controls.Add(help);
        }
        //打开修改密码
        private void xiugaimima_Click(object sender, EventArgs e)
        {
            changepassword.Show();
            panel.Controls.Clear();
            panel.Controls.Add(changepassword);
        }
        //退出登录
        private void tuichudegnlu_Click(object sender, EventArgs e)
        {
            login main = new login();
            main.Show();
            Close();
           
        }
        //退出系统
        private void tuichuxitong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kaoqin_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
