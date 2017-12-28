namespace Bank
{
    public interface IAccount
    {
        int AccountNumber { get; }

        decimal PRate { get; }

        bool AccountStatus { get; set; }

        void AddMoney(decimal inValue);

        decimal GetMoney(decimal outValue);

        decimal AccountBalance();
    }
}