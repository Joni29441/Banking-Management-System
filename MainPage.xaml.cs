using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace American_Express
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            string srvrdbname = "BANKING_SYSTEM";
            string srvrname = "192.168.0.33";
            string srvrusername = "Gori";
            string srvrpassword = "Goni_m20";
            string sqlcon = $"Data Source={srvrname};Initial Catalog={srvrdbname};User Id={srvrusername};Password={srvrpassword};Trusted_Connection=true";
            SqlConnection sqlConnection = new SqlConnection(sqlcon);
            sqlConnection.Open();
        }
        private void LogInButton(object sender, EventArgs e)
        { }
            }
        private async void ForgotButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPass());
        }
    }
}
