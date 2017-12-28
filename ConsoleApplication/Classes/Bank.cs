using System;
using System.Collections.Generic;

namespace Bank.Classes
{
    public class Banks
    {
        private readonly Random _random = new Random();

        public Dictionary<int, IAccount> Accounts { get; set; } = new Dictionary<int, IAccount>();
     
        public void CreateAccount(int type, decimal balance, decimal pRate = 0)
        {
            var account = GetAccountType(type, balance, pRate);
            Accounts[account.AccountNumber] = account;
        }

        public void CloseAccount(int number)
        {
            Accounts[number].AccountStatus = false;
        }

        public void AddMoney(int number,int value)
        {
            Accounts[number].AddMoney(value);
        }

        private IAccount GetAccountType(int type, decimal balance,  decimal pRate = 0)
        {
            switch (type)
            {
                case  1: return new  Depisite(balance, NumberGnerator() ,pRate);
                case  2: return new  Credit(balance,NumberGnerator(), pRate);
                case  3: return new  Valute(balance, NumberGnerator(), pRate);
                default: return new  Valute(balance, NumberGnerator(), pRate);
            }
        }

        private  int NumberGnerator()
        {
            var aNumber = default(int);
            while (true)
            {
                aNumber = _random.Next(1000, 9999);
                if(!Accounts.ContainsKey(aNumber))
                    break;
            }
            
            return aNumber;
        }

        public void ShoveAllAccounts()
        {
            
                Console.WriteLine(Accounts.ToStringTable(new []{"Account Number", "Balance","Account type","Percent rate","Status"}, 
                    account => account.Value.AccountNumber, 
                    account => account.Value.AccountBalance(),
                    account => AccountType(account.Value),
                    account => account.Value.PRate,
                    account => account.Value.AccountStatus)
                );
            
        }

        private string AccountType(IAccount type) => type.GetType().Name;
    }
}