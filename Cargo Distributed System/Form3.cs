using Cargo_Distributed_System.Entity;
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
    public partial class UpdatePasswordForm : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        private void UpdatePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            string name = userNameTbx.Text;
            string oldPassword = oldPasswordTbx.Text;
            string newPassword = newPasswordTbx.Text;

            if (name != "" && oldPassword != "" && newPassword != "")
            {

                var values = new Dictionary<string, string>
            {
                { "userName", name },
                { "oldUserPassword", oldPassword },
                { "newUserPassword", newPassword },
            };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://localhost:3000/changePassword", content);
                var responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<Result>(responseString);
                if (model.result == "false")
                {
                    errorLabel.ForeColor = Color.Red;
                    errorLabel.Text = "An Error Occoured While Changing Password , Please Check Your Values.";
                }
                else
                {
                    errorLabel.ForeColor = Color.Green;
                    errorLabel.Text = "Password Changed Successfully";
                }
            }
            else
            {
                MessageBox.Show("Please Fill The Whole Parts");
            }

        }

        private void returnLbl_Click(object sender, EventArgs e)
        {
            LoginForm lF = new LoginForm();
            this.Close();
            lF.Show();
        }
    }
}
