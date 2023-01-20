using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for PIN.xaml
    /// </summary>
    public partial class PIN : Window
    {
        public PIN()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["BankSystemEntities"].ConnectionString;
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Main();
            newForm.Show();
            this.Close();
            System.Windows.MessageBox.Show("The card has been ejected");
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string pin = Pin.Text;
                string pi=Opin.Text;
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT PIN As data FROM Customer Where PIN=@pin ", connection))
                {
                    command.Parameters.AddWithValue("@pin", pi);
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "Update Customer set PIN=@p where PIN=@d";
                    SqlCommand com = new SqlCommand(query, connection);
                    com.Parameters.AddWithValue("@p", pin);
                    string da=data.ToString();
                    com.Parameters.AddWithValue("@d", da);
                    com.ExecuteNonQuery();
                    MessageBox.Show("PIN changed");
                }
                connection.Close();

            }
        }
    }
}
