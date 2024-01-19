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
    public partial class SignUpView : UserControl
    {
        SharedViewModel SViewModel;
        public SignUpView()
        {
            InitializeComponent();
            SViewModel = new SharedViewModel();
            this.DataContext = SViewModel;
        }

        private void ClickSignUp(object sender, RoutedEventArgs e)
        {
            if (ValidateRequiredFileds())
            {
                bool success = SViewModel.SignUp();
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
            if (SViewModel.CurrentCustomer.AccountNumber == "" || SViewModel.CurrentCustomer.AccountNumber == null)
            {
                TxtSignupResponse.Text = "Please enter an account number to register.";
                valid = false;
            }
            else if (SViewModel.CurrentCustomer.Password == "" || SViewModel.CurrentCustomer.Password == null)
            {
                TxtSignupResponse.Text = "Please enter a password to register.";
                valid = false;
            }
            else if (SViewModel.CurrentCustomer.Name == "" || SViewModel.CurrentCustomer.Name == null)
            {
                TxtSignupResponse.Text = "Please enter your name to register.";
                valid = false;
            }
            else if (SViewModel.CurrentCustomer.Balance < 500)
            {
                TxtSignupResponse.Text = "Please enter an amount of 500 or above to register.";
                valid = false;
            }
            return valid;
        }
    }
}
