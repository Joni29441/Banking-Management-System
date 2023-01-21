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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        public Transfer()
        {
            InitializeComponent();

        }
        string connectionString = ConfigurationManager.ConnectionStrings["BankSystemEntities"].ConnectionString;
        private void Countinue_Click(object sender, RoutedEventArgs e)
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
                    String A = Amount.Text;
                    int a = int.Parse(A);
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
                        string An = Account.Text;
                        int an= int.Parse(An);
                        string query3 = "SELECT Balance As Ab From Account where AccNumber=@An";
                        SqlCommand c = new SqlCommand(query3, connection);
                        c.Parameters.AddWithValue("@An", an);
                        float Ab = (float)c.ExecuteScalar();
                        string aaa=Ab.ToString();
                        int ab = int.Parse(aaa);
                        int Newab = ab + a;
                        string query4 = "Update Account set Balance=@bb where AccNumber=@An";
                        SqlCommand ac = new SqlCommand(query4, connection);
                        ac.Parameters.AddWithValue("@bb", Newab);
                        ac.Parameters.AddWithValue("@An", an);
                        ac.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }
    

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Main();
            newForm.Show();
            this.Close();
            System.Windows.MessageBox.Show("The card has been ejected");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Selection();
            newForm.Show();
            this.Close();
        }
    }
}
