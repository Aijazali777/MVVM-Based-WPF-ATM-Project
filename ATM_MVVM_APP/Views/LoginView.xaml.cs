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

using ATM_MVVM_APP.ViewModels;
namespace ATM_MVVM_APP.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        CustomerViewModel ViewModel;
        public LoginView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;
        }

        private void Clicklogin(object sender, RoutedEventArgs e)
        {
            TxtSignupResponse.Visibility = Visibility.Collapsed;
            bool isAccount = false;

            isAccount = ViewModel.Login();

            if (!isAccount)
            {
                TxtResponse.Text = "Incorrect account number or password";
            }
            else
            {
                TxtLogin.Text = "Welcome " + ViewModel.currentCustomerName + " :) ";
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    ((Grid)parentWindow.Content).Children.Clear();
                    ((Grid)parentWindow.Content).Children.Add(new MainMenu());
                }
            }
        }
    }
}
