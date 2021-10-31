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
    public partial class RegistrationForm : Form
    {
        LoginForm lF = new LoginForm();
        private User user;
        private static readonly HttpClient client = new HttpClient();


        public RegistrationForm()
        {
            user = new User();
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }


        private void returnLbl_Click(object sender, EventArgs e)
        {
            LoginForm lF = new LoginForm();
            this.Close();
            lF.Show();
        }

        private async void registerBtn_Click_1(object sender, EventArgs e)
        {
            user.userName = userNameTbx.Text;
            user.password = passwordTbx.Text;
            user.reEnterPassowrd = reEnterPasswordTbx.Text;

            if (user.userName != "" && user.password != "" && user.reEnterPassowrd != "")
            {

                if (user.password != user.reEnterPassowrd)
                {
                    errorLbl.ForeColor = Color.Red;
                    errorLbl.Text = "The Entered Password Don't Match !";
                }
                else
                {

                    var values = new Dictionary<string, string>
                {
                    { "userId", "0" },
                    { "userName", user.userName },
                    { "password", user.password },
                };

                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("http://localhost:3000/addUser", content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<Result>(responseString);

                    if (model.result == "true")
                    {

                        errorLbl.ForeColor = Color.Green;
                        errorLbl.Text = "User Added Successfully";
                    }
                    else
                    {
                        errorLbl.ForeColor = Color.Red;
                        errorLbl.Text = "An Error Occured, Please Try Again";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill The Whole Parts");
            }
        }
    }
}
