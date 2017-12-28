using System;
using System.Xml;
using System.Xml.Serialization;

namespace Bank.Classes
{
    [Serializable]
    public class Account : IAccount
    {
        public Account()
        {

        }

        public Account(decimal startBalance, int aNumber, decimal pRate, bool accountStatus)
        {
            Balance = startBalance;
            AccountNumber = aNumber;
            PRate = pRate;
            AccountStatus = accountStatus;
        }

        [XmlAttribute]
        public decimal Balance { get; set; }

        [XmlAttribute]
        public int AccountNumber { get; set; }

        [XmlAttribute]
        public decimal PRate { get; set; }

        [XmlAttribute]
        public bool AccountStatus { get; set; }

        public virtual void AddMoney(decimal inValue)
        {
            throw new NotImplementedException();
        }

        public virtual decimal GetMoney(decimal outValue) => Balance -= outValue;

        public virtual decimal AccountBalance() => Balance;
    }
}