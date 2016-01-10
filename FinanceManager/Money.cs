namespace FinanceManager
{
    public class Money
    {
        public int Amount { get; private set; }
        private readonly string _currency;

        protected Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        } 
        
        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency());
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && Currency().Equals(money.Currency());
        }

        public string Currency()
        {
            return _currency;
        }

        public Money Plus(Money addend)
        {
            return new Money(Amount + addend.Amount, Currency());
        }
    }
}