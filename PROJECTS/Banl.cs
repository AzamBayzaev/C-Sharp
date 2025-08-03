using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Main
{

    interface ITransaction
    {
        void PerformTransaction(decimal amount);
    }
    abstract class BankAccount : ITransaction
    {
        public string Name { get; }
        public decimal Balance { get; protected set; }
        public long Id { get; }
        public decimal Fee { get; }

        private static long NextId = 100000;
        private readonly List<string> transactionHistory = new();

        public BankAccount(string name, decimal initialBalance, decimal fee)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (fee < 0)
                throw new ArgumentException("Fee cannot be negative.");

            Name = name;
            Balance = initialBalance >= 0 ? initialBalance : 0;
            Fee = fee;

            Id = Interlocked.Increment(ref NextId);
        }

        public abstract void PerformTransaction(decimal amount);

        public virtual void PrintInformation()
        {
            Console.WriteLine($"\n[{GetType().Name}] Account Info:");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Owner: {Name}");
            Console.WriteLine($"Balance: {Balance} USD");
        }

        protected void Deposit(decimal amount)
        {
            Balance += amount;
            LogTransaction($"Deposited: {amount} USD");
        }

        protected void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
            LogTransaction($"Withdrew: {amount} USD");
        }

        protected void LogTransaction(string message)
        {
            transactionHistory.Add($"{DateTime.Now}: {message}");
            Console.WriteLine(message);
        }

        public void ShowTransactionHistory()
        {
            Console.WriteLine("\nTransaction History:");
            foreach (var log in transactionHistory)
            {
                Console.WriteLine(log);
            }
        }
    }
    class DepositAccount : BankAccount
    {
        public DepositAccount(string name, decimal balance, decimal fee)
            : base(name, balance, fee) { }

        public override void PerformTransaction(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            decimal netAmount = amount - Fee;
            if (netAmount <= 0)
                throw new InvalidOperationException("Amount after fee must be positive.");

            Deposit(netAmount);
            LogTransaction($"Deposit transaction completed. Fee: {Fee} USD.");
        }
    }
    class WithdrawalAccount : BankAccount
    {
        public WithdrawalAccount(string name, decimal balance, decimal fee)
            : base(name, balance, fee) { }

        public override void PerformTransaction(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            decimal totalAmount = amount + Fee;
            if (totalAmount > Balance)
                throw new InvalidOperationException("Insufficient funds for withdrawal and fee.");

            Withdraw(totalAmount);
            LogTransaction($"Withdrawal transaction completed. Fee: {Fee} USD.");
        }
    }
    class BankManager
    {
        private readonly List<BankAccount> accounts = new();

        public void AddAccount(BankAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            accounts.Add(account);
        }

        public void ProcessTransaction(BankAccount account, decimal amount)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            if (!accounts.Contains(account))
            {
                Console.WriteLine("Account not found in manager.");
                return;
            }

            try
            {
                account.PrintInformation();
                account.PerformTransaction(amount);
                account.PrintInformation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
            }

            Console.WriteLine("--------------------------");
        }

        public void ProcessAllSampleTransactions()
        {
            foreach (var acc in accounts)
            {
                decimal testAmount = acc is DepositAccount ? 500 : 300;
                ProcessTransaction(acc, testAmount);
            }
        }
    }

    class Device
    {
        private readonly string Name;
        private readonly string IsOn;
        public Device(string name, string isOn)
        {
            if (name == "Light" || name == "AirConditioner")
            {
                Name = name;
            }
            else
            {
                Name = "INVALID_NAME";
            }

            if (isOn == "On" || isOn == "Off")
                IsOn = isOn;
            else
                IsOn = "INVALID_IsOn";
        }
        public virtual void TurnOn()
        {
            Console.WriteLine($"{Name} {IsOn}");
        }
        public virtual void TurnOff()
        {
            Console.WriteLine($"{Name} Off");
        }
        public virtual void GetStatus()
        {
            Console.WriteLine($"{Name} is {IsOn}");
        }
    }
    class Light : Device
    {
        private readonly int Level_Ligth;
        public Light(string name, string ison, int level) : base(name, ison)
        {
            if (level >= 1 && level <= 5)
            {
                Level_Ligth = level;
            }
            else
            {
                Console.WriteLine("INVALID_Level_Ligth");
            }
        }
        public override void GetStatus()
        {
            base.GetStatus();
            Console.WriteLine($"Level ligth: {Level_Ligth}");
        }

    }
    class AirConditioner : Device
    {
        private readonly int Level_AirConditioner;
        private readonly string Lev_Conditioner;
        public AirConditioner(string name, string ison,int level_con, string lev_con) : base(name, ison) 
        {
            if (level_con >= 16 && level_con <= 32) 
            {
                Level_AirConditioner = level_con;
            }
            else
            {
                Console.WriteLine("INVALID_Level_AirConditioner");
            }
            if (lev_con == "hot" || lev_con == "cold")
            {
                Lev_Conditioner = lev_con;
            }
            else
            {
                Console.WriteLine("INVALID_Lev_Conditioner");
            }
        }
    }



} 