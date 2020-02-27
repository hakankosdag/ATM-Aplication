using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public abstract class Transaction
    {
        private int accountNumber;
        private Screen userScreen;
        private BankDatabase bankDatabase;

        //Parameter constructor
        public Transaction(int accountNumber, Screen userScreen, BankDatabase bankDatabase)
        {
            this.accountNumber = accountNumber;
            this.userScreen = userScreen;
            this.bankDatabase = bankDatabase;
        }

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public Screen UserScreen
        {
            get
            {
                return userScreen;
            }
        }

        public BankDatabase Database
        {
            get
            {
                return bankDatabase;
            }
        }

        public abstract void Execute();
    }
}
