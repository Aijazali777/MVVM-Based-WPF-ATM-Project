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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_MVVM_APP.Views
{
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            TxtWelcome.Text = "Welcome to Alfa E-Wallet";
            TxtMainOption.Text = "Please Select any option below to continue";
        }

        private void ExistingUser(object sender, RoutedEventArgs e)
        {
            contentContainer.Children.Clear();
            contentContainer.Children.Add(new LoginView());
        }

        private void NewUser(object sender, RoutedEventArgs e)
        {
            contentContainer.Children.Clear();
            contentContainer.Children.Add(new SignUpView());
        }
    }
}
