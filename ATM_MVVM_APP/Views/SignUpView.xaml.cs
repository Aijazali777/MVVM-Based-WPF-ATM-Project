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
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        CustomerViewModel ViewModel;
        public SignUpView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;
        }

        private void ClickSignUp(object sender, RoutedEventArgs e)
        {
            if (ValidateRequiredFileds())
            {
                bool success = ViewModel.SignUp();
                if (success)
                {
                    TxtSignupResponse.Text = "Account created successfully!";
                    Window parentWindow = Window.GetWindow(this);
                    if (parentWindow != null)
                    {
                        ((Grid)parentWindow.Content).Children.Clear();
                        ((Grid)parentWindow.Content).Children.Add(new LoginView());
                    }
                }
                else
                {
                    TxtSignupResponse.Text = "This account number already exists. Try another one.";
                }
            }
        }

        bool ValidateRequiredFileds()
        {
            bool valid = true;
            if (ViewModel.CurrentCustomer.AccountNumber == "" || ViewModel.CurrentCustomer.AccountNumber == null)
            {
                TxtSignupResponse.Text = "Please enter an account number to register.";
                valid = false;
            }
            else if (ViewModel.CurrentCustomer.Password == "" || ViewModel.CurrentCustomer.Password == null)
            {
                TxtSignupResponse.Text = "Please enter a password to register.";
                valid = false;
            }
            else if (ViewModel.CurrentCustomer.Name == "" || ViewModel.CurrentCustomer.Name == null)
            {
                TxtSignupResponse.Text = "Please enter your name to register.";
                valid = false;
            }
            else if (ViewModel.CurrentCustomer.Balance < 500)
            {
                TxtSignupResponse.Text = "Please enter an amount of 500 or above to register.";
                valid = false;
            }
            return valid;
        }
    }
}
