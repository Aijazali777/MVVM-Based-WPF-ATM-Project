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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public bool isBtnDepositClicked = false;
        public bool isBtnWithDrawClicked = false;
        public bool isBtnShowBalanceClicked = false;
        public bool isBtnExitClicked = false;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void ClickDeposit(object sender, RoutedEventArgs e)
        {
            isBtnDepositClicked = true;
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                ((Grid)parentWindow.Content).Children.Clear();
                ((Grid)parentWindow.Content).Children.Add(new EndView());
            }
        }


        private void ClickWithdraw(object sender, RoutedEventArgs e)
        {
            //BtnBack.Visibility = Visibility.Visible;
            //TxtBalance.Text = "";
            //BtnDone.Content = "Withdraw";
            //TxtMainOption.Text = "Please enter an amount to Withdraw!";
            isBtnWithDrawClicked = true;
        }

        private void ClickShowBalance(object sender, RoutedEventArgs e)
        {
            //TxtBalance.Visibility = Visibility.Visible;
            //BtnBack.Visibility = Visibility.Visible;
            isBtnShowBalanceClicked = true;
            isBtnDepositClicked = false;
            isBtnWithDrawClicked = false;
          //  ClickDone(sender, e);
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            //   SPMenu.Visibility = Visibility.Collapsed;
            isBtnExitClicked = true;
          //  ClickDone(sender, e);
        }

    }
}
