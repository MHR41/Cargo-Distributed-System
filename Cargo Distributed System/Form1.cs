
using Cargo_Distributed_System.Entity;
using MySql.Data.MySqlClient.Memcached;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cargo_Distributed_System
{
    public partial class LoginForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private static DeliveryAdressScreenForm mapForm = new DeliveryAdressScreenForm();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationform = new RegistrationForm();
            this.Close();
            registrationform.Show();

        }

        private void lblClick(object sender, EventArgs e)
        {
            UpdatePasswordForm uF = new UpdatePasswordForm();
            this.Close();
            uF.Show();
        }

        private async void loginBtn_ClickAsync(object sender, EventArgs e)
        {

            string userName = userNameTxb.Text;
            string password = passwordTbx.Text;

            if (userName != "" && password != "") {

                var values = new Dictionary<string, string>
                {
                    { "userName", userName },
                    { "password", password },

                };


                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://localhost:3000/login", content);
                var responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<Result>(responseString);

                

                if (model.result == "true")
                {

                    MessageBox.Show("Login Done Successfully");
                    userNameTxb.Text = "";
                    passwordTbx.Text = "";

                    this.Close();
                    mapForm.Show();

                }
                else
                {
                    MessageBox.Show("Authentication failed");

                }

            } 
            else {

                MessageBox.Show("Please Fill The Whole Necessary Fields !");
            }

           
        }
    }
}
