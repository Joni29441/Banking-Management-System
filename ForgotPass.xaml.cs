using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace American_Express
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPass : ContentPage
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void SendEmailButton(object sender, EventArgs e)
        {

        }
    }
}