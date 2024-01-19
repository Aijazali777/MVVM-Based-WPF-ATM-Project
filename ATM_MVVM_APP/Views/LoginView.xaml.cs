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
    public partial class LoginView : UserControl
    {
        SharedViewModel SViewModel;
        public LoginView()
        {
            InitializeComponent();
            SViewModel = new SharedViewModel();
            this.DataContext = SViewModel;
        }

        private void Clicklogin(object sender, RoutedEventArgs e)
        {
            bool isAccount = false;

            Application.Current.Properties["AcctNum"] = FldAccountNum.Text;
            Application.Current.Properties["CurrentPass"] = FldPassword.Text;

            isAccount = SViewModel.Login();

            if (!isAccount)
            {
                TxtResponse.Text = "Incorrect account number or password";
            }
            else
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
}
