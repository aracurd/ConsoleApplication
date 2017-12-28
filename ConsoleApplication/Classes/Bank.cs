using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Bank.Classes
{
    public class Banks
    {
        private readonly Random _random = new Random();

        [XmlIgnore]
        public Dictionary<int, IAccount> Accounts { get; set; } = new Dictionary<int, IAccount>();

        public List<IAccount> AccountCollection
        {
            get { return Accounts.Values.ToList(); }
            set { Accounts = new Dictionary<int, IAccount>(value.ToDictionary(k=> k.AccountNumber)); }
        }

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
                case  1: return new  Deposite(balance, NumberGnerator() ,pRate);
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

        public void ToXml<T>()
        {
            XmlSerializer s = new XmlSerializer(typeof(List<T>), extraTypes: new [] {typeof(Deposite), typeof(Credit), typeof(Valute)});
            using (FileStream fs = new FileStream(@"BankData.xml", FileMode.OpenOrCreate))
            {
                s.Serialize(fs, AccountCollection.OfType<T>().ToList());
            }
        }

        public void ToBin<T>() {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"BinBankData.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, AccountCollection.OfType<T>().ToList());
            }
        }

        private string AccountType(IAccount type) => type.GetType().Name;
    }
}