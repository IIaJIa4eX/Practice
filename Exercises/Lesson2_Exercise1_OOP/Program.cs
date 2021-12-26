using System;

namespace Lesson2_Exercise1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount ss = new BankAccount(45678, BankAccount.AccType.VIP);

            BankAccount ss1 = new BankAccount();

            BankAccount ss2 = new BankAccount();
            ss2.AccountType = BankAccount.AccType.Slave;
            ss2.Balance = 78102;
            ss2.WithdrawAmount(78101);
            ss1.Deposit(55555);

            Console.WriteLine($"Баланс:{ss.Balance}  Тип:{ss.AccountType} Номер:{ss.AccNumb}");
            Console.WriteLine($"Баланс:{ss1.Balance}  Тип:{ss1.AccountType} Номер:{ss1.AccNumb}");
            Console.WriteLine($"Баланс:{ss2.Balance}  Тип:{ss2.AccountType} Номер:{ss2.AccNumb}");
        }
    }
}
