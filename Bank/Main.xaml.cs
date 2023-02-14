using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace Bank
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["BankSystemEntities"].ConnectionString;
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Main();
            newForm.Show();
            this.Close();
            System.Windows.MessageBox.Show("The card has been ejected");
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            string pin = Pin.Password;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Customer WHERE PIN = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@password", pin);

                int result = (int)command.ExecuteScalar();
               
                if (result > 0)
                {   int p= int.Parse(pin);
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string Q = "insert into Lastl(PIN) values (@pin)";
                        SqlCommand com = new SqlCommand(Q, con);
                        com.Parameters.AddWithValue("@pin", p);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                    System.Windows.MessageBox.Show("Weclome");
                    var loged = new Selection();
                    loged.Show();
                    this.Close();
                    
                }
                else
                {
                    System.Windows.MessageBox.Show("Incorect PIN");
                }
                connection.Close();
            }
        }
    }
}
