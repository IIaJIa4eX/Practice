using System;

namespace Lesson2_Exercise1_OOP
{
    class Program
    {

        public static  string StringReverse(string rev)
        {
            char[] tmp =  rev.ToCharArray();
            Array.Reverse(tmp);
            return string.Join("",tmp);
        }



        static void Main(string[] args)
        {
            BankAccount ss = new BankAccount(45678, BankAccount.AccType.VIP);

            BankAccount ss1 = new BankAccount();

            BankAccount ss2 = new BankAccount();

            BankAccount ss3 = new BankAccount();

            BankAccount ss4 = new BankAccount(45678, BankAccount.AccType.VIP);

            ss2.AccountType = BankAccount.AccType.Slave;
            ss2.Balance = 78102;
            ss2.WithdrawAmount(78101);
            ss1.Deposit(55555);

            //Lesson 3 ex1
            ss3.MoneyTransfer(ss, 25000);
            //-------


            Console.WriteLine($"Баланс:{ss.Balance}  Тип:{ss.AccountType} Номер:{ss.AccNumb}");
            Console.WriteLine($"Баланс:{ss1.Balance}  Тип:{ss1.AccountType} Номер:{ss1.AccNumb}");
            Console.WriteLine($"Баланс:{ss2.Balance}  Тип:{ss2.AccountType} Номер:{ss2.AccNumb}");
            Console.WriteLine($"Баланс:{ss3.Balance}  Тип:{ss3.AccountType} Номер:{ss3.AccNumb}");


            //Lesson 3 ex2
            string revr = "1 2 3 4 5 6 7 8 9";
            Console.WriteLine($"{StringReverse(revr)}");

            //-------


            //Lesson 6 ex 1
            bool isEqual = ss == ss4;

            bool isNotEqual = ss != ss2;

            bool isEqualMethod = ss.Equals(ss4);

            int hashCode = ss.GetHashCode();

            string stringOutPut = ss.ToString();
            //--------------
        }
    }
}
