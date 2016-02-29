
namespace FinanceManager
{
    public class Money : IExpression
    {
        public int Amount { get; }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        } 
        
        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public IExpression Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && Currency.Equals(money.Currency);
        }

        public string Currency { get; }

        public IExpression Plus(IExpression addend)
        {
            return new Sum(this, addend);
        }
        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount/rate, to);
        }
    }
}