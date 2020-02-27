using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Withdrawal : Transaction
    {
        private decimal amount;
        private CashDispenser cashDispenser;
        private Keypad keypad;

        //Constant equal to the menu option to cancel
        private const int CANCELED = 6;

        //parameter constructor
        public Withdrawal(int userAccount, Screen screen, BankDatabase bankDatabase, Keypad keypad, CashDispenser cashDispenser)
            : base(userAccount, screen, bankDatabase)
        {
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
        }
        //override transaction's method
        public override void Execute()
        {
            bool cashDispensed = false;

            bool transactionCanceled = false;

            while ((!cashDispensed) && (!transactionCanceled))
            {
                int selection = DisplayMenu();

                if (selection != CANCELED)
                {
                    amount = selection;

                    decimal availableBalance = Database.getAvailableBalance(AccountNumber);

                    if (amount <= availableBalance)
                    {
                        if (cashDispenser.IsSufficiantCashAvailable(amount))
                        {
                            Database.Debit(AccountNumber, amount);

                            cashDispenser.DispenseCash(amount);
                            cashDispensed = true;

                            UserScreen.DisplayMessageLine("\nPlease take your money.");
                            UserScreen.DisplayMessage("\n-------------------------------------------");
                        }
                        else
                            UserScreen.DisplayMessageLine("\nThere is insufficient cash in the ATM. \n" + "\nEnter a smaller amount.");
                    }
                    else
                        UserScreen.DisplayMessageLine("There is insufficient cash in yor accont.\n" + "Enter a smaller amount");
                }
                else
                {
                    UserScreen.DisplayMessageLine("\nThe transaction is canceled.");
                    UserScreen.DisplayMessage("\n-------------------------------------------");
                    transactionCanceled = true;
                }
            }
        }
        private int DisplayMenu()
        {
            int userChoice = 0;

            int[] amounts = { 0, 20, 40, 60, 100, 200 };

            while (userChoice == 0)
            {
                UserScreen.DisplayMessage("\n-------------------------------------------");
                UserScreen.DisplayMessageLine("\nWithdrawal options: ");
                UserScreen.DisplayMessageLine("1 - $20");
                UserScreen.DisplayMessageLine("2 - $40");
                UserScreen.DisplayMessageLine("3 - $60");
                UserScreen.DisplayMessageLine("4 - $100");
                UserScreen.DisplayMessageLine("5 - $200");
                UserScreen.DisplayMessageLine("6 - Cancel transaction");
                UserScreen.DisplayMessage("\nChoose a withdrawal option(1-6): ");

                int input = keypad.GetInput();

                switch (input)
                { 
                    case 1: case 2: case 3: case 4: case 5:
                        userChoice = amounts[input];
                        break;
                    case CANCELED:
                        userChoice = CANCELED;
                        break;
                    default:
                        UserScreen.DisplayMessageLine("\nInvalid selection.Try again.");
                        break;
                  
                }
            }

            return userChoice;
        }
    }
}