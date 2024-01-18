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
using ATM_MVVM_APP.Views;
namespace ATM_MVVM_APP.Views
{
    public partial class EndView : UserControl
    {
        MainMenu objMainMenu = new MainMenu();
        CustomerViewModel ViewModel;
        public EndView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;

            if(objMainMenu.isBtnDepositClicked)
            {
                TxtBalance.Text = "";
                TxtBalance.Visibility = Visibility.Collapsed;
                BtnDone.Content = "Deposit";
                TxtDepositWithdraw.Text = "Please enter an amount to deposit!";
            }
            else if(objMainMenu.isBtnDepositClicked)
            {
                    TxtBalance.Text = "";
                    TxtBalance.Visibility = Visibility.Collapsed;
                    BtnDone.Content = "Deposit";
                    TxtDepositWithdraw.Text = "Please enter an amount to deposit!";
            }
            else if(objMainMenu.isBtnShowBalanceClicked)
            {
                TxtEndViewResponse.Text = "";
                TxtBalance.Text = "Your available Balance is " + ViewModel.currentCustomerBalance;
                objMainMenu.isBtnShowBalanceClicked = false;
            }
            else if(objMainMenu.isBtnExitClicked)
            {

            }

        }

        private void ClickDone(object sender, RoutedEventArgs e)
        {
            FldAmount.Visibility = Visibility.Collapsed;
            BtnDone.Visibility = Visibility.Collapsed;
            TxtBalance.Visibility = Visibility.Visible;
            BtnBack.Visibility = Visibility.Visible;
            bool success = false;

            if (objMainMenu.isBtnDepositClicked)
            {
                success = ViewModel.Deposit();
                if (success)
                {
                    TxtEndViewResponse.Text = "Amount Added Successfully!";
                    TxtBalance.Text = "Your new Balance is " + ViewModel.currentCustomerBalance;
                    objMainMenu.isBtnDepositClicked = false;
                }
                else
                {
                    TxtEndViewResponse.Text = "Please enter an amount of 500 or above to deposit";
                    TxtBalance.Visibility = Visibility.Collapsed;
                    FldAmount.Visibility = Visibility.Visible;
                    BtnDone.Visibility = Visibility.Visible;
                }
                ViewModel.CurrentCustomer.Balance = 0;

            }
            else if (objMainMenu.isBtnWithDrawClicked)
            {
                success = ViewModel.WithDraw();
                if (success)
                {
                    TxtEndViewResponse.Text = "Amount withdrawn successfully!";
                    TxtBalance.Text = "Your new Balance is " + ViewModel.currentCustomerBalance;
                    objMainMenu.isBtnWithDrawClicked = false;
                }
                else
                {
                    if (ViewModel.CurrentCustomer.Balance > ViewModel.currentCustomerBalance)
                    {
                        TxtEndViewResponse.Text = "You have insufficient balance. Please try another amount";
                    }
                    else
                    {
                        TxtEndViewResponse.Text = "Please enter an amount of 500 or above to withdraw";
                    }

                    TxtBalance.Visibility = Visibility.Collapsed;
                    SPDepositAndWithdraw.Visibility = Visibility.Visible;
                }
                ViewModel.CurrentCustomer.Balance = 0;
            }
            else if (objMainMenu.isBtnShowBalanceClicked)
            {
                TxtEndViewResponse.Text = "";
                TxtBalance.Text = "Your available Balance is " + ViewModel.currentCustomerBalance;
                objMainMenu.isBtnShowBalanceClicked = false;
            }
            else if (objMainMenu.isBtnExitClicked)
            {
                SPDepositAndWithdraw.Visibility = Visibility.Collapsed;
                TxtBalance.Visibility = Visibility.Collapsed;
                BtnBack.Visibility = Visibility.Collapsed;

                objMainMenu.isBtnExitClicked = false;

                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    ((Grid)parentWindow.Content).Children.Clear();
                    ((Grid)parentWindow.Content).Children.Add(new CustomerView());
                }
            }
            ViewModel.CurrentCustomer.serilization(ViewModel.desCustomer);
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            //SPSignUp.Visibility = Visibility.Collapsed;
            TxtEndViewResponse.Text = "";

            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                ((Grid)parentWindow.Content).Children.Clear();
                ((Grid)parentWindow.Content).Children.Add(new MainMenu());
            }
        }
    }
}
