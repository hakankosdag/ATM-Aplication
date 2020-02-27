using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Account
    {
        private int accountNumber;
        private int pin;
        private decimal availableBalance;
        private decimal totalBalance;

        //parameter constructor
        public Account(int accountNumber, int pin, decimal availableBalance, decimal totalBalance)
        {
            this.accountNumber = accountNumber;
            this.pin = pin;
            this.availableBalance = availableBalance;
            this.totalBalance = totalBalance;
        }
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        private int Pin
        {
            get
            {
                return pin;
            }
        }
        public decimal AvailableBalance
        {
            get
            { 
                return availableBalance; 
            }
        }
        public decimal TotalBalance
        {
            get
            {
                return totalBalance;
            }
        }
        //credits the account
        public void Credit(decimal amount)
        {
            totalBalance += amount;
        }
        //debit the account
        public void Debit(decimal amount)
        {
            availableBalance -= amount;
            totalBalance -= amount;
        }
        //a PIN determined by a user determines whether it matches the PIN in the account
        public bool ValidatePin(int pin)
        {
            if (this.pin == pin)
                return true;
            else
                return false;
        }
    }
}
