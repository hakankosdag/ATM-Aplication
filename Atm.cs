using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Atm
    {
        private BankDatabase bankDatabase;
        private CashDispenser cashDispenser;
        private int currentAccountNumber;
        private DepositSlot depositSlot;
        private Keypad keypad;
        private Screen screen;
        private bool userAuthentcated;

        //Constructor
        public Atm()
        {
            bankDatabase = new BankDatabase();
            cashDispenser=new CashDispenser();
            currentAccountNumber = 0;
            depositSlot = new DepositSlot();
            keypad = new Keypad();
            screen = new Screen();
            userAuthentcated = false;
        }
        //authentication in the database
        public void AuthenticateUser()
        { 
            screen.DisplayMessage("\nPlease enter your account number: ");
            int tempAccountNumber = keypad.GetInput();

            screen.DisplayMessage("\nPlease enter your pin:");
            int tempPin = keypad.GetInput();

            userAuthentcated = bankDatabase.AuthenticateUser(tempAccountNumber, tempPin);
            if (userAuthentcated)
                currentAccountNumber = tempAccountNumber;
            else
                screen.DisplayMessageLine("Invalid account or PIN.Please try again.");
        }
        //display the main menu and return a selection
        private int DisplayMainMenu()
        {
            screen.DisplayMessageLine("\nMain:");
            screen.DisplayMessageLine("1 - View my balance");
            screen.DisplayMessageLine("2 - Withdraw cash");
            screen.DisplayMessageLine("3 - Deposit funds");
            screen.DisplayMessageLine("4 - Exit\n");
            screen.DisplayMessage("Enter a choice: ");

            return keypad.GetInput();
        }
        //Return object of the specified derived class
        private Transaction CreateTransaction(MenuOption type)
        {
            Transaction temp = null;

            switch ((MenuOption)type)
            { 
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceInquiry(currentAccountNumber, screen, bankDatabase);
                    break;
                case MenuOption.WITHDRAWAL:
                    temp = new Withdrawal(currentAccountNumber, screen, bankDatabase, keypad, cashDispenser);
                    break;
                case MenuOption.DEPOSIT:
                    temp = new Deposit(currentAccountNumber, screen, bankDatabase, keypad, depositSlot);
                    break;
            }
            return temp;
        }
        //display and perform transaction main menu
        private void PerformTransactions()
        {
            Transaction currentTransaction;
            bool exit = false;

            while (!exit)
            {
                MenuOption mainMenuSelection = (MenuOption)DisplayMainMenu();

                switch ((MenuOption)mainMenuSelection)
                {
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAWAL:
                    case MenuOption.DEPOSIT:
                        currentTransaction = CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.EXIT_ATM:
                        screen.DisplayMessageLine("\nExiting the system");
                        exit = true;
                        break;
                    default:
                        screen.DisplayMessageLine("\nYou did not enter a valid selection.Try again.");
                        break;
                }
            }
        }
        //run for atm
        public void Run()
        {
            while (true)
            {
                while (!userAuthentcated)
                {
                    screen.DisplayMessageLine("\nWelcome!");
                    AuthenticateUser();
                }
                PerformTransactions();
                userAuthentcated = false;
                currentAccountNumber = 0;
                screen.DisplayMessageLine("\nThank you! Goodbye!");
            }
        }
        private enum MenuOption
        { 
            BALANCE_INQUIRY=1,
            WITHDRAWAL=2,
            DEPOSIT=3,
            EXIT_ATM=4
        }
    }
}
