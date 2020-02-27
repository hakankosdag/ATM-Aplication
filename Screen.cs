using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Screen
    {
        public void DisplayMessage(string p)
        {
            Console.Write(p);        
        }
        public void DisplayMessageLine(string p)
        {
            Console.WriteLine(p);
        }
        public void DisplayDollarAmount(decimal amount)
        {
            Console.WriteLine(amount);
        }
    }
}
