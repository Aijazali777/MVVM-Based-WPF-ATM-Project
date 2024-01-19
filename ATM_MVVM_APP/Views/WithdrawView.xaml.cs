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
    public partial class WithdrawView : UserControl
    {
        SharedViewModel SViewModel;
        public WithdrawView()
        {
            InitializeComponent();
            SViewModel = new SharedViewModel();
            this.DataContext = SViewModel;
        }

        private void ClickDone(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["CurrentBalance"] = FldAmount.Text;
            string tempAcct = Application.Current.Properties["AcctNum"] as string;
            string tempPass = Application.Current.Properties["CurrentPass"] as string;
            string temB = Application.Current.Properties["CurrentBalance"] as string;
            double tempBalance = double.Parse(temB);
            FldAmount.Visibility = Visibility.Collapsed;
            TxtWithdraw.Visibility = Visibility.Collapsed;
            BtnDone.Visibility = Visibility.Collapsed;
            TxtBalance.Visibility = Visibility.Visible;

            BtnBack.Visibility = Visibility.Visible;
            bool success = false;

            success = SViewModel.Withdraw(tempAcct, tempPass, tempBalance);
            if (success)
            {
                TxtWithdrawResponse.Text = "Amount Withdrawn Successfully!";
                TxtBalance.Text = "Your new Balance is " + SViewModel.currentCustomerBalance;
            }
            else
            {
                if (tempBalance > SViewModel.currentCustomerBalance)
                {
                    TxtWithdrawResponse.Text = "You have insufficient balance. Please try another amount";
                }
                else
                {
                    TxtWithdrawResponse.Text = "Please enter an amount of 500 or above to withdraw";
                }
  
                TxtBalance.Visibility = Visibility.Collapsed;
                FldAmount.Visibility = Visibility.Visible;
                BtnDone.Visibility = Visibility.Visible;
            }
            SViewModel.CurrentCustomer.Balance = 0;

            SViewModel.CurrentCustomer.serilization(SViewModel.desCustomer);
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                ((Grid)parentWindow.Content).Children.Clear();
                ((Grid)parentWindow.Content).Children.Add(new MainMenu());
            }
        }
    }
}
