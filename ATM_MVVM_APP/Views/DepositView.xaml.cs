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
    public partial class DepositView : UserControl
    {
        SharedViewModel SViewModel;
        public DepositView()
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
            TxtDeposit.Visibility = Visibility.Collapsed;
            BtnDone.Visibility = Visibility.Collapsed;
            TxtBalance.Visibility = Visibility.Visible;
           
            BtnBack.Visibility = Visibility.Visible;
            bool success = false;

            success = SViewModel.Deposit(tempAcct, tempPass, tempBalance);
            if (success)
            {
                TxtDepositResponse.Text = "Amount Added Successfully!";
                TxtBalance.Text = "Your new Balance is " + SViewModel.currentCustomerBalance;
            }
            else
            {
                TxtDepositResponse.Text = "Please enter an amount of 500 or above to deposit";
                TxtBalance.Visibility = Visibility.Collapsed;
                TxtDepositResponse.Text = "Failed";
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
