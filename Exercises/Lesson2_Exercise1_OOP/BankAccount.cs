using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Exercise1_OOP
{
    class BankAccount
    {
        public enum AccType { Default, VIP, Slave }

        private int _accNumber;

        private static int _numbGenerator;

        private int _balance;

        private AccType _accT;



        public BankAccount()
        {
            _accNumber = _numbGenerator++;
        }

        public BankAccount(int balance)
        {
            _balance = balance;
            _accNumber = _numbGenerator++;
        }

        public BankAccount(AccType accType)
        {
            _accT = accType;
            _accNumber = _numbGenerator++;
        }

        public BankAccount(int balance, AccType accType)
        {
            _balance = balance;
            _accT = accType;
            _accNumber = _numbGenerator++;// не стал делать метод.
        }


        public int AccNumb
        {
            get
            {
                return _accNumber;
            }
        }

        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }


        public AccType AccountType
        {
            get
            {
                return _accT;
            }
            set
            {
                _accT = value;
            }
        }

        public void WithdrawAmount(int amount)
        {
            if (_balance - amount < 0)
                return;
            _balance -= amount;

        }

        public void Deposit(int amount)
        {
            _balance += amount;

        }

        //public int GetAccNumber()
        //{
        //    return _accNumber;
        //}




        //public void SetAccNumber()
        //{
        //     _accNumber += 1;

        //}

        //public int GetBalance()
        //{
        //    return _balance;
        //}



        //public void Setbalance(int balance)
        //{
        //    this._balance += balance;

        //}




        //public AccType GetAccType()
        //{

        //    return _accT;
        //}

        //public void SetAccType(AccType accType)
        //{
        //    if (accType.Equals(AccType.Slave))
        //        _accT = AccType.Slave;

        //    if(accType.Equals(AccType.VIP))
        //        _accT = AccType.VIP;

        //}
    }
}
