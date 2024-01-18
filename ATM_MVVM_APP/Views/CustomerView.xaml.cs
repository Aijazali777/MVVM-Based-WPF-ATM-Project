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
    public partial class CustomerView : UserControl
    {
        bool isBtnDepositClicked = false;
        bool isBtnWithDrawClicked = false;
        bool isBtnShowBalanceClicked = false;
        bool isBtnExitClicked = false;

        CustomerViewModel ViewModel;
        public CustomerView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;
            Welcome();
        }

        private void Welcome()
        {
            TxtWelcome.Text = "Welcome to Alfa E-Wallet";
            TxtMainOption.Text = "Please Select any option below to continue";
        }

        private void ExistingUser(object sender, RoutedEventArgs e)
        {
            contentContainer.Children.Clear();
            contentContainer.Children.Add(new LoginView());
            TxtMainOption.Text = "Login";
        }

        private void NewUser(object sender, RoutedEventArgs e)
        {
            contentContainer.Children.Clear();
            contentContainer.Children.Add(new SignUpView());
            //SPSignUp.Visibility = Visibility.Visible;

            //TxtMainOption.Text = "SignUp";
            //FldNewAccountNum.Text = "";
            //FldNewPassword.Text = "";
            //FldNewName.Text = "";
            //FldNewBalance.Text = "";
            TxtSignupResponse.Text = "";
            TxtSignupResponse.Visibility = Visibility.Visible;
        }

        private void Clicklogin(object sender, RoutedEventArgs e)
        {
            TxtSignupResponse.Visibility = Visibility.Collapsed;
            bool isAccount = false;

            isAccount = ViewModel.Login();
       
            if (!isAccount)
            {
               // TxtResponse.Text = "Incorrect account number or password";
            }
            else
            {
              //  TxtResponse.Text = "Login Successed";
                Menu();
            }
        }

        void Menu()
        {
         ////   SPLogin.Visibility = Visibility.Collapsed;
          //  SPMenu.Visibility = Visibility.Visible;
        //    FldAmount.Text = "";
          //  TxtMainOption.Text = "Welcome " + ViewModel.currentCustomerName + " :) ";
        }

    }
}
