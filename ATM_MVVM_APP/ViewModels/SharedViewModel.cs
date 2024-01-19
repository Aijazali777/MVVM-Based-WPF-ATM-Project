using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATM_MVVM_APP.Models;
namespace ATM_MVVM_APP.ViewModels
{
    public class SharedViewModel
    {
        public string currentCustomerName;
        public double currentCustomerBalance;
        public List<Customer> desCustomer = new List<Customer>();

        public SharedViewModel()
        {
            CurrentCustomer = new Customer();
            CurrentCustomer.AccountNumber = null;
            CurrentCustomer.Password = null;
            desCustomer = CurrentCustomer.deserilization();
        }

        public string currentPass;
        public string CurrentPass
        {
            get { return currentPass; }
            set { currentPass = value; }
        }

        public string acctNum;
        public string AcctNum
        {
            get { return acctNum; }
            set { acctNum = value; }
        }

        public double currentBalance;
        public double CurrentBalance
        {
            get { return currentBalance; }
            set { currentBalance = value; }
        }

        private Customer currentCustomer;
        public Customer CurrentCustomer { get { return currentCustomer; } set { currentCustomer = value; } }

        public bool SignUp()
        {
            bool notExistingAccount = true;
            foreach (Customer arg in desCustomer)
            {
                if (CurrentCustomer.AccountNumber == arg.AccountNumber)
                {
                    notExistingAccount = false;
                    return notExistingAccount;
                }
            }

            if (notExistingAccount)
            {
                Customer newCustomer = new Customer();
                newCustomer.AccountNumber = CurrentCustomer.AccountNumber;
                newCustomer.Password = CurrentCustomer.Password;
                newCustomer.Name = CurrentCustomer.Name;
                newCustomer.Balance = CurrentCustomer.Balance;

                desCustomer.Add(newCustomer);
                CurrentCustomer.serilization(desCustomer);
            }

            return notExistingAccount;
        }

        public bool Login()
        {
            bool isAccount = false;
            foreach (Customer arg in desCustomer)
            {
                if (AcctNum == arg.AccountNumber)
                {
                    if (CurrentPass == arg.Password)
                    {
                        currentCustomerName = arg.Name;
                        currentCustomerBalance = arg.Balance;
                        isAccount = true;
                        return isAccount;
                    }
                }
            }
            return isAccount;
        }

        public bool Deposit(string tempAcct, string tempPass, double tempBalance)
        {
            bool isSuccess = false;
            foreach (Customer arg in desCustomer)
            {
                if (tempAcct == arg.AccountNumber)
                {
                    if (tempPass == arg.Password)
                    {
                        if (tempBalance >= 500)
                        {
                            arg.Balance = arg.Balance + tempBalance;
                            currentCustomerBalance = arg.Balance;
                            isSuccess = true;
                            return isSuccess;
                        }
                    }
                }
            }
            return isSuccess;
        }

        public bool Withdraw(string tempAcct, string tempPass, double tempBalance)
        {
            bool isSuccess = false;
            foreach (Customer arg in desCustomer)
            {
                if (tempAcct == arg.AccountNumber)
                {
                    if (tempPass == arg.Password)
                    {
                        if (tempBalance < arg.Balance)
                        {
                            if (tempBalance >= 500)
                            {
                                arg.Balance = arg.Balance - tempBalance;
                                currentCustomerBalance = arg.Balance;
                                isSuccess = true;
                                return isSuccess;
                            }
                        }
                    }
                }
            }
            return isSuccess;
        }

        public void ShowBalance(string tempAcct, string tempPass)
        {
            foreach (Customer arg in desCustomer)
            {
                if (tempAcct == arg.AccountNumber)
                {
                    if (tempPass == arg.Password)
                    {
                        currentCustomerBalance = arg.Balance;
                    }
                }
            }
        }
    }
}
