namespace Bank.Classes
{
    public abstract class Account : IAccount
    {
        internal decimal Balance { get; set; }

        public int AccountNumber { get; }
        
        public decimal PRate { get; }

        public bool AccountStatus { get; set; }

        protected Account(decimal startBalance, int aNumber, decimal pRate, bool accountStatus = true)
        {
            Balance = startBalance;
            AccountNumber = aNumber;
            PRate = pRate;
            AccountStatus = accountStatus;
        }

        public abstract void AddMoney(decimal inValue);

        public virtual decimal GetMoney(decimal outValue) => Balance -= outValue;

        public virtual decimal AccountBalance() => Balance;
    }
}