using System;
namespace Delegate
{
    public delegate void AccountStateHandler(string message);

    class Account
    {
        int _sum; 
        int _percentage; 

        public Account(int sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                Del?.Invoke("Сумма " + sum.ToString() + " снята со счета");
            }
            else
            {
                Del?.Invoke("Недостаточно денег на счете");
            }
        }

        public int Percentage
        {
            get { return _percentage; }
        }

        public event AccountStateHandler Del;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(200, 6);

            account.Del += Show_Message;
            account.Del += Color_Message;

            account.Withdraw(100);
            account.Withdraw(150);

            account.Del -= Color_Message;

            account.Withdraw(50);
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
        private static void Color_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
