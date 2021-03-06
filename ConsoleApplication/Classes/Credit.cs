﻿
using System;

namespace Bank.Classes
{
    [Serializable]
    public class Credit : Account
    {
        public Credit()
        {
            
        }

        public Credit(decimal startBalance, int aNumber, decimal pRate, bool accountStatus = true) 
            : base(startBalance, aNumber, pRate, accountStatus)
        {

        }
        
        public override void AddMoney(decimal inValue)
        {
            Balance += inValue;
        }

        public void GetPercent () 
        {
            Balance -= ((Balance / 100) * PRate);
        }
    }
}