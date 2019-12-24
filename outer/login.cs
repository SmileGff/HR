using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using HR.inside;

namespace HR.outer
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        //连接字符串 获取配置文件里的连接路径
        string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        private void login_Load(object sender, EventArgs e)
        {

        }
        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            //使用SqlConnection 来连接数据库
            using (SqlConnection conn = new SqlConnection(connStr)) {
                //创建sql 查询语句  
                string sql = "select username,password from [administrator] where username ='" + textBox1.Text + "'";
                //创建 SqlCommand 执行指令
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //打开数据库连接
                    conn.Open();
                    //使用 SqlDataReader 来 读取数据库  
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        //SqlDataReader 在数据库中为 从第1条数据开始 一条一条往下读 
                        if (sdr.Read())  //如果读取账户成功(文本框中的用户名在数据库中存在)
                        {
                            //则将第1条 密码 赋给 字符串pwd  ,并且依次往后读取 所有的密码
                            //Trim()方法为移除字符串前后的空白
                            string pwd = sdr["password"].ToString();
                            //如果 文本框中输入的密码 ==数据库中的密码
                            //则将对应该用户名下的 第一个字段 即使密码(MUserPwd为select的第一个字段) 赋给 字符串pwd  ,并且依次往后读取 所有的密码
                            //Trim()方法为移除字符串前后的空
                            //读取器sdr获取了2列数据 第1列为密码 第2列 即索引为1的是用户类型
                            if (pwd == textBox2.Text)
                            {
                                //说明在该账户下 密码正确, 系统登录成功
                                homepage main = new homepage();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                //否则密码错误 再次输入密码
                                label3.Text = "密码错误,请重新输入!";
                                //并自动将当前密码 清空
                                textBox2.Text = "";
                            }
                        }
                        else
                        {
                            //如果读取账户数据失败, 则用户名不存在
                            label3.Text="用户名不存在,请重新输入!";
                            //并自动清空账户名
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                    }
                }
            }
        }
        //修改密码
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("请联系管理员（电话：17674718872）修改密码！！！");
        }
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //跳转到注册界面
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            apply main = new apply();
            main.Show();
            this.Hide();
        }


    }
}
