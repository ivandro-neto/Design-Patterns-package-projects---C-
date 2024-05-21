using System.Collections.Generic;
using System.Formats.Asn1;
using System.Numerics;

namespace BancoINvest
{
    public abstract class Bank
    {
        protected readonly Dictionary<uint, Account> _accounts = new Dictionary<uint, Account>();

        public abstract void AddAccount(uint id);
        public abstract void AddBalance(uint id, uint amount);
        public abstract void TransferBalance(uint from, uint to, uint balance);
        public abstract void Withdraw(uint id, uint amount);
        public int this[uint id]
        {
            get { return _accounts[id].GetBalance(); }
        }
    }
    public class Account(uint id)
    {
        private readonly uint _id = id;
        private int _balance = 0;

        public uint Id => _id;

        public void AddBalance(uint balance)
        {
            //Was Added {balance}

            _balance += (int)balance;
        }
        public void SubtractBalance(uint balance)
        {
            //Was Debitated {balance}
            _balance -= (int)balance;
        }
        public int GetBalance()
        {
            return _balance;
        }
    }
    public class INvest : Bank
    {
        private static readonly INvest _instance;
        public Dictionary<uint, Account> Accounts => _accounts;

        public static INvest GetInstance()
        {
            if(_instance  == null)
            {
                return new INvest();
            }
            return _instance;
        }
        private INvest()
        {

        }
        public override void AddAccount(uint id)
        {
            if (!_accounts.ContainsKey(id))
            {
                //SUCCESS
                _accounts.Add(id,new(id));
            }
            else
            {
                //Error cannot add this account with this ID number
            }
        }

        public override void AddBalance(uint id, uint amount)
        {
            if (Accounts.TryGetValue(id, out Account? value))
            {
                value.AddBalance(amount);
            }
            else
            {
                //Error cannot add this account with this ID number

            }
        }

        public override void TransferBalance(uint from, uint to, uint balance)
        {
            if (Accounts.TryGetValue(from, out Account? valueFrom) && Accounts.TryGetValue(to, out Account? valueTo))
            {
                if (valueFrom.GetBalance() > balance)
                {
                    valueFrom.SubtractBalance(balance);
                    valueTo.AddBalance(balance);
                }
                else
                {
                    //Error not enough balance to this transation
                }

            }
            else
            {
                //Error cannot find any account with provied IDs to this transation
            }
        }

        public override void Withdraw(uint id, uint amount)
        {
            if (Accounts.ContainsKey(id))
            {
                if (Accounts[id].GetBalance() > amount)
                {
                    //Success
                    Accounts[id].SubtractBalance(amount);
                }
                else
                {
                    //Error not enough balance to this transation
                }
            }
            else
            {
                //Error cannot find this account
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            INvest invest = INvest.GetInstance();
            invest.AddAccount(12345);
            invest.AddAccount(12453);
            invest.AddBalance(12345, 3000);
            invest.TransferBalance(12345, 12453, 500);
            invest.Withdraw(12345, 1000);
            Console.WriteLine($"BALANCE account 1:{invest[12345]}\nBALANCE account 2: {invest[12453]}");

            Console.ReadKey();
        }
    }
}
