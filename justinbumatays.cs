using System.Net.Http.Headers;

namespace dassboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            DBConnect db = new DBConnect();

            try
            {
                db.Open();
                string query = "SELECT COUNT(*) FROM tudent_management where username=@usernameValue and password=@passwordValue";

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@usernameValue", username);
                cmd.Parameters.AddWithValue("@passwordValue", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show("Wrong username or password");
                }
                else
                {
                    MessageBox.Show("Login successfully!");
                    new Dashbord().Show();
                    this.Hide();
                }


            }
            catch
            {
                MessageBox.Show("Something went wrong!");

            }
            finally 
            {
                db.Close();
            
            }
        }
    }
}
