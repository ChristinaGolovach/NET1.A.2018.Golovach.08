using System;
using System.Text;

namespace BankAccountLogic.NumberGenerator
{
    public class AccountNumberGenerator : INumberGenerator<string>
    {
        private const string  SYMBOLS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string GenerateNumber(int numberLength = 10)
        {
            Random random = new Random();
            StringBuilder number = new StringBuilder(numberLength);
            
            for (int i = 0; i < numberLength; i++)
            {
                int index = random.Next(0, SYMBOLS.Length - 1);
                number.Append(SYMBOLS[index]);
            }

            return number.ToString();            
        }
    }
}
