namespace Bank.Classes
{
    public class Depisite : Account
    {  
        public Depisite(decimal startBalance, int aNumber, decimal pRate, bool accountStatus = true) 
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