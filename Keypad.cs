using System;
using System.Collections.Generic;
using System.Text;

namespace Project_ATM
{
    public class Keypad
    {
        //Returns the number entered by the user.
        public int GetInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
    }
}
