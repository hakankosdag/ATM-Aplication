using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class BalanceInquiry : Transaction
    {
        //Parameter constructor
        public BalanceInquiry(int accountNumber, Screen screen, BankDatabase bankDatabase):base(accountNumber,screen,bankDatabase) {  }

        //override transaction's method
        public override void Execute()
        {
            decimal availableBalence = Database.getAvailableBalance(AccountNumber);

            decimal totalBalance = Database.getTotalBalance(AccountNumber);

            UserScreen.DisplayMessage("\n-------------------------------------------");
            UserScreen.DisplayMessageLine("\nBalance Information: ");
            UserScreen.DisplayMessage(" - Available Balance: ");
            UserScreen.DisplayDollarAmount(availableBalence);
            UserScreen.DisplayMessage("\n - Total Balance: ");
            UserScreen.DisplayDollarAmount(totalBalance);
            UserScreen.DisplayMessageLine("-------------------------------------------");
        }
    }
}
