using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class BankDatabase
    {
        //accounts array
        private Account[] accounts;

        //Constructor
        public BankDatabase()
        {
            accounts = new Account[3];
            accounts[0] = new Account(1234, 123, 1000.0M, 2000.0M);
            accounts[1] = new Account(1235, 124, 500.0M, 1000.0M);
            accounts[2] = new Account(1236, 125, 300.0M, 600.0M);
        }
        //finds the account object that contains the given account number
        private Account GetAccount(int accountNumber)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                    return accounts[i];
            }
            return null;
        }
        //checks whether the account number and PIN code entered by the user matches an account in the database.
        public bool AuthenticateUser(int userAccountNumber, int userPin)
        {
            if (GetAccount(userAccountNumber) != null)
                return GetAccount(userAccountNumber).ValidatePin(userPin);
            else
                return false;
        }
        //the account will be credited
        public void Credit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Credit(amount);
        }
        //the account will be credited
        public void Debit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Debit(amount);
        }
        public decimal getAvailableBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).AvailableBalance;
        }
        public decimal getTotalBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).TotalBalance;
        }
    }
}