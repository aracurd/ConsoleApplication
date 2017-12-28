using System;

namespace Bank.Classes
{
    [Serializable]
    public class Deposite : Account
    {
        public Deposite()
        {
            
        }

        public Deposite(decimal startBalance, int aNumber, decimal pRate, bool accountStatus = true) 
            : base(startBalance, aNumber, pRate, accountStatus)
        {
        }

        public override void AddMoney(decimal inValue)
        {
            Balance = inValue;
        }

        public void AddPercent()
        {
            Balance += ((Balance / 100) * PRate);
        }
    }
}