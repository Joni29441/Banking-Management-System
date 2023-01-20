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
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Other_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Other();
            newForm.Show();
            this.Close();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["BankSystemEntities"].ConnectionString;
        private void A5_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 PIN As data FROM Lastl ORDER BY id DESC ", connection))
                {
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "SELECT Id As id From Customer where PIN=@pin";
                    SqlCommand com = new SqlCommand(query, connection);
                    string da = data.ToString();
                    com.Parameters.AddWithValue("@pin", da);
                    var id = (int)com.ExecuteScalar();
                    string query1 = "SELECT Balance As Bal From Account where CustId=@p";
                    SqlCommand comm = new SqlCommand(query1, connection);
                    comm.Parameters.AddWithValue("@p", id);
                    float Bal = (float)comm.ExecuteScalar();
                    int a = 500;
                    if (Bal < a)
                    {
                        MessageBox.Show("The Account dosent have the amount your requested\n");
                    }
                    else
                    {
                        string B = Bal.ToString();
                        int Ba = int.Parse(B);
                        int NewA = Ba - a;
                        string query2 = "Update Account set Balance=@p where CustId=@d";
                        SqlCommand co = new SqlCommand(query2, connection);
                        co.Parameters.AddWithValue("@p", NewA);
                        co.Parameters.AddWithValue("@d", id);
                        co.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
        }
    

        private void A10_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 PIN As data FROM Lastl ORDER BY id DESC ", connection))
                {
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "SELECT Id As id From Customer where PIN=@pin";
                    SqlCommand com = new SqlCommand(query, connection);
                    string da = data.ToString();
                    com.Parameters.AddWithValue("@pin", da);
                    var id = (int)com.ExecuteScalar();
                    string query1 = "SELECT Balance As Bal From Account where CustId=@p";
                    SqlCommand comm = new SqlCommand(query1, connection);
                    comm.Parameters.AddWithValue("@p", id);
                    float Bal = (float)comm.ExecuteScalar();
                    int a = 1000;
                    if (Bal < a)
                    {
                        MessageBox.Show("The Account dosent have the amount your requested\n");
                    }
                    else
                    {
                        string B = Bal.ToString();
                        int Ba = int.Parse(B);
                        int NewA = Ba - a;
                        string query2 = "Update Account set Balance=@p where CustId=@d";
                        SqlCommand co = new SqlCommand(query2, connection);
                        co.Parameters.AddWithValue("@p", NewA);
                        co.Parameters.AddWithValue("@d", id);
                        co.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
        }

        private void A20_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 PIN As data FROM Lastl ORDER BY id DESC ", connection))
                {
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "SELECT Id As id From Customer where PIN=@pin";
                    SqlCommand com = new SqlCommand(query, connection);
                    string da = data.ToString();
                    com.Parameters.AddWithValue("@pin", da);
                    var id = (int)com.ExecuteScalar();
                    string query1 = "SELECT Balance As Bal From Account where CustId=@p";
                    SqlCommand comm = new SqlCommand(query1, connection);
                    comm.Parameters.AddWithValue("@p", id);
                    float Bal = (float)comm.ExecuteScalar();
                    int a = 2000;
                    if (Bal < a)
                    {
                        MessageBox.Show("The Account dosent have the amount your requested\n");
                    }
                    else
                    {
                        string B = Bal.ToString();
                        int Ba = int.Parse(B);
                        int NewA = Ba - a;
                        string query2 = "Update Account set Balance=@p where CustId=@d";
                        SqlCommand co = new SqlCommand(query2, connection);
                        co.Parameters.AddWithValue("@p", NewA);
                        co.Parameters.AddWithValue("@d", id);
                        co.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
        }

        private void A30_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 PIN As data FROM Lastl ORDER BY id DESC ", connection))
                {
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "SELECT Id As id From Customer where PIN=@pin";
                    SqlCommand com = new SqlCommand(query, connection);
                    string da = data.ToString();
                    com.Parameters.AddWithValue("@pin", da);
                    var id = (int)com.ExecuteScalar();
                    string query1 = "SELECT Balance As Bal From Account where CustId=@p";
                    SqlCommand comm = new SqlCommand(query1, connection);
                    comm.Parameters.AddWithValue("@p", id);
                    float Bal = (float)comm.ExecuteScalar();
                    int a = 3000;
                    if (Bal < a)
                    {
                        MessageBox.Show("The Account dosent have the amount your requested\n");
                    }
                    else
                    {
                        string B = Bal.ToString();
                        int Ba = int.Parse(B);
                        int NewA = Ba - a;
                        string query2 = "Update Account set Balance=@p where CustId=@d";
                        SqlCommand co = new SqlCommand(query2, connection);
                        co.Parameters.AddWithValue("@p", NewA);
                        co.Parameters.AddWithValue("@d", id);
                        co.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
        }

        private void A40_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 PIN As data FROM Lastl ORDER BY id DESC ", connection))
                {
                    decimal data = (decimal)command.ExecuteScalar();
                    string query = "SELECT Id As id From Customer where PIN=@pin";
                    SqlCommand com = new SqlCommand(query, connection);
                    string da = data.ToString();
                    com.Parameters.AddWithValue("@pin", da);
                    var id = (int)com.ExecuteScalar();
                    string query1 = "SELECT Balance As Bal From Account where CustId=@p";
                    SqlCommand comm = new SqlCommand(query1, connection);
                    comm.Parameters.AddWithValue("@p", id);
                    float Bal = (float)comm.ExecuteScalar();
                    int a = 4000;
                    if (Bal < a)
                    {
                        MessageBox.Show("The Account dosent have the amount your requested\n");
                    }
                    else
                    {
                        string B = Bal.ToString();
                        int Ba = int.Parse(B);
                        int NewA = Ba - a;
                        string query2 = "Update Account set Balance=@p where CustId=@d";
                        SqlCommand co = new SqlCommand(query2, connection);
                        co.Parameters.AddWithValue("@p", NewA);
                        co.Parameters.AddWithValue("@d", id);
                        co.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
        }
    }
}
