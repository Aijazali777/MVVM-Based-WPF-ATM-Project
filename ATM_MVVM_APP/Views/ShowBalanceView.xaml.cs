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
    public partial class ShowBalanceView : UserControl
    {
        SharedViewModel SViewModel;
        public ShowBalanceView()
        {
            InitializeComponent();
            SViewModel = new SharedViewModel();
            this.DataContext = SViewModel;
            ShowBalance();
        }

        private void ShowBalance()
        {
            string tempAcct = Application.Current.Properties["AcctNum"] as string;
            string tempPass = Application.Current.Properties["CurrentPass"] as string;
            SViewModel.ShowBalance(tempAcct, tempPass);
            TxtBalance.Text = "Your available balance is " + SViewModel.currentCustomerBalance;
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
