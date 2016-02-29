using System;
using System.Collections;

namespace FinanceManager
{
    public class Bank
    {
        private readonly Hashtable _rates = new Hashtable();
        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            _rates.Add(new Tuple<string, string>(from, to), rate);
        }
        public int Rate(string from, string to)
        {
            if (from.Equals(to))
                return 1;
            var rate = (int)_rates[new Tuple<string,string>(from,to)];
            return rate;
        }
    }
}