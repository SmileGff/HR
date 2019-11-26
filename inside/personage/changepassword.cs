using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using HR.outer;

namespace HR.inside.personage
{
    public partial class changepassword : UserControl
    {
        public changepassword()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        //连接字符串 获取配置文件里的连接路径
        string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        //修改密码
        private void button1_Click(object sender, EventArgs e)
        {
            opendata();
            string sql = "select password from administrator where username ='" + txtUsername.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string oldPwd = sdr.GetString(0).Trim();
                if (oldPwd == txtOldPwd.Text)
                {
                    if (txtNewPwd.Text.Trim() == "" || txtNewPwdConfird.Text.Trim() == "")
                    {
                        MessageBox.Show("新密码确认不能为空!");
                        return;
                    }
                    else if (txtNewPwd.Text.Trim() != txtNewPwdConfird.Text.Trim())
                    {
                        MessageBox.Show("2次输入的新密码不一样,请重新输入!");
                        txtNewPwd.Text = "";
                        txtNewPwdConfird.Text = "";
                        return;
                    }
                    else
                    {
                        sdr.Close();
                        string sqlUpdate = "update administrator set password ='" + txtNewPwdConfird.Text +"' where username ='" + txtUsername.Text + "'";
                        SqlCommand cmdUp = new SqlCommand(sqlUpdate, conn);
                        if (cmdUp.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("未知错误!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("密码修改成功!正在返回登录界面");
                            //将当前用户的登录信息添加到DataGridView里面
                            login login = new login();
                            login.Show();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("旧密码错误或者为空");
                    txtOldPwd.Text = "";
                    txtNewPwd.Text = "";
                    txtNewPwdConfird.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("用户名不存在,请重新输入!");
                txtUsername.Text = "";
                txtOldPwd.Text = "";
                txtNewPwd.Text = "";
                txtNewPwdConfird.Text = "";
                return;
            }
            conn.Close();
        }
        //连接数据库
        private void opendata()
        {
            string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
        }

    }
}
