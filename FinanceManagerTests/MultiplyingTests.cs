using System;
using Machine.Specifications;

namespace FinanceManager
{
    public class When_Multiplicating_Dollars
    {
        private It should_multiplie_value_by_2 = () => Money.Dollar(5).Times(2).Equals(Money.Dollar(10)).ShouldBeTrue();
    }

    public class When_Multiplicating_Dollar_Few_Times
    {
        Establish context = () => { Five = Money.Dollar(5); };

        It should_give_10 = () => { Money.Dollar(10).Equals(Five.Times(2)).ShouldBeTrue(); };
        It should_give_15 = () => { Money.Dollar(15).Equals(Five.Times(3)).ShouldBeTrue(); };
        private static Money Five;
    }

    public class When_Multiplicating_Franc_Few_Times
    {
        Establish context = () => { Five = Money.Franc(5); };

        It should_give_10 = () => { Money.Franc(10).Equals(Five.Times(2)).ShouldBeTrue(); };
        It should_give_15 = () => { Money.Franc(15).Equals(Five.Times(3)).ShouldBeTrue(); };
        private static Money Five;
    }

    public class When_Comparing_Money_Values
    {
        It should_return_true_for_same_values = () => { Money.Dollar(5).Equals(Money.Dollar(5)).ShouldBeTrue(); };
        It should_return_false_for_different_values = () => { Money.Dollar(6).Equals(Money.Dollar(5)).ShouldBeFalse(); };
    }


    public class When_Comparing_Franc_To_Dollar
    {
        It should_do_the_math = () => { Money.Franc(5).Equals(Money.Dollar(5)).ShouldBeFalse(); };
    }

    public class When_Checking_Currency_Type
    {
        It should_return_USD_for_dollar = () => { Money.Dollar(1).Currency.ShouldEqual("USD"); };
        It should_return_CHF_for_franc = () => { Money.Franc(1).Currency.ShouldEqual("CHF"); };
    }

    public class When_Adding_Money
    {
        Because of = () => { sum = Money.Dollar(5).Plus(Money.Dollar(5)); };

        It should_add_5_dollars = () => { sum.Reduce(new Bank(), "USD").Equals(Money.Dollar(10)).ShouldBeTrue(); };
        private static IExpression sum;
    }

    public class When_Adding_Different_Currency
    {
        Establish context = () => { bank = new Bank(); };

        Because of = () =>
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            reduced = bank.Reduce(sum, "USD");
        };

        It should_use_bank_and_covert = () => { Money.Dollar(7).Equals(reduced).ShouldBeTrue(); };

        private static Bank bank;
        private static Money reduced;
    }

    public class When_PlusReturnsSum
    {
        Establish context = () => { five = Money.Dollar(5); };

        Because of = () =>
        {
            var result = five.Plus(five);
            sum = result as Sum;
        };

        It should_set_augend_and_addend = () =>
        {
            five.Equals(sum.Augend).ShouldBeTrue();
            five.Equals(sum.Addend).ShouldBeTrue();
        };

        private static Money five;
        private static Sum sum;
    }

    public class When_Reduce_Money
    {
        Because of = () =>
        {
            bank = new Bank();
            result = bank.Reduce(Money.Dollar(1), "USD");
        };

        It should_reduce_usd_to_usd = () => { result.Equals(Money.Dollar(1)).ShouldBeTrue(); };

        private static Bank bank;
        private static Money result;
    }

    public class When_Reduce_Different_Currency
    {
        Establish context = () =>
        {
            bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
        };

        Because of = () => { result = bank.Reduce(Money.Franc(2), "USD"); };

        It should_use_defined_rate = () => { Money.Dollar(1).Equals(result).ShouldBeTrue(); };
        private static Bank bank;
        private static Money result;
    }

    public class When_Checking_Rate_For_The_Same_Currency
    {
        It should_return_rate_1 = () => { 1.ShouldEqual(new Bank().Rate("USD", "USD")); };
    }

    public class When_Adding_Different_Currencies
    {
        Establish context = () =>
        {
            five_bucks = Money.Dollar(5);
            ten_francs = Money.Franc(10);
            bank = new Bank();
        };

        Because of = () =>
        {
            bank.AddRate("CHF", "USD", 2);
            result = bank.Reduce(five_bucks.Plus(ten_francs), "USD");
        };

        It should_ = () => { result.Amount.ShouldEqual(Money.Dollar(10).Amount); };
        private static Bank bank;
        private static IExpression ten_francs;
        private static IExpression five_bucks;
        private static Money result;
    }

    public class When_Using_sum_plus
    {
        Establish context = () =>
        {
            fiveBucks = Money.Dollar(5);
            tenFrancs = Money.Franc(10);
            bank = new Bank();
        };

        Because of = () =>
        {
            bank.AddRate("CHF", "USD", 2);
            var sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            result = bank.Reduce(sum, "USD");
        };

        It should_ = () => { result.ShouldEqual(Money.Dollar(15)); };
        private static Bank bank;
        private static IExpression tenFrancs;
        private static IExpression fiveBucks;
        private static Money result;
    }
}