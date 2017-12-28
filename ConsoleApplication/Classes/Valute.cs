using System;

namespace Bank.Classes
{
    [Serializable]
    public class Valute : Account
    {
        public Valute()
        {

        }

        public Valute(decimal startBalance, int aNumber, decimal pRate = 0, bool accountStatus = true) 
            : base(startBalance, aNumber, pRate, accountStatus)
        {
        }

        public override void AddMoney(decimal inValue)
        {
            Balance += inValue;
        }
    }
}