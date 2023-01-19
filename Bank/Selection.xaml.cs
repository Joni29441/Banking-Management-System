using System;
using System.Collections.Generic;
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
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : Window
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Main();
            newForm.Show();
            this.Close();
            System.Windows.MessageBox.Show("The card has been ejected");
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            var Form = new Balance();
            Form.Show();
            this.Close();

        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            var Form = new Withdraw();
            Form.Show();
            this.Close();
        }

        private void PinCh_Click(object sender, RoutedEventArgs e)
        {
            var Form = new PIN();
            Form.Show();
            this.Close();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            var Form = new Transfer();
            Form.Show();
            this.Close();
        }
    }
}
