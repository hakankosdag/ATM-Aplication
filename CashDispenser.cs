using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class CashDispenser
    {
        private int billCount;

        //the first default invoice in the cash dispenser
        private const int INITIAL_COUNT = 1000;

        //constructor
        public CashDispenser()
        {
            billCount = INITIAL_COUNT;
        }
        //Distribute cash at the specified amount
        public void DispenseCash(decimal amount)
        {
            billCount -= (int)amount/20;
        }
        //It checks that the cash dispenser can give the desired amount.
        public bool IsSufficiantCashAvailable(decimal amount)
        {
            if (billCount >= (int)(amount / 20))
                return true;
            else
                return false;
        }
    }
}
