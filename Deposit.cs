using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Deposit : Transaction
    {
        private decimal amount;
        private Keypad keypad;
        private DepositSlot depositSlot;

        private const int CANCELED = 0;

        //parameter constructor
        public Deposit(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase, Keypad atmKeypad, DepositSlot atmDepositSlot)
            : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            depositSlot = atmDepositSlot;
        }

        //overrides Transaction method
        public override void Execute()
        {
            amount = PromptForDepositAmount();

            if (amount != CANCELED)
            {
                UserScreen.DisplayMessage(
                 "\nPlease insert a deposit envelope containing ");
                UserScreen.DisplayDollarAmount(amount);
                UserScreen.DisplayMessageLine(" in the deposit slot.");

                bool envelopeReceived = depositSlot.IsDepositEnvelopeReceived();

                if (envelopeReceived)
                {
                    UserScreen.DisplayMessageLine(
                        "\nYour envelope has been received.\n" +
                        "The money just deposited will not be available " +
                        "until we \nverify the amount of any " +
                        "enclosed cash, and any enclosed checks clear.");

                    Database.Credit(AccountNumber, amount);
                }
                else
                {
                    UserScreen.DisplayMessageLine("\nYou did not insert an envelope, so the ATM has canceled your transaction.");
                }
            }
            else
            {
                UserScreen.DisplayMessageLine("\nCanceling transaction.");
            }
        }

        //
        private decimal PromptForDepositAmount()
        {
            UserScreen.DisplayMessage("\nPlease input a deposit amount in CENTS (or 0 to cancel): ");
            int input = keypad.GetInput();

            if (input == CANCELED)
                return CANCELED;
            else
                return input / 100.00M;
        }
    }
}
