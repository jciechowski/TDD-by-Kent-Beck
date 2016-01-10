using FinanceManager;
using Machine.Specifications;

namespace FinanceManagerTests
{
    public class When_Multiplicating_Dollars
    {
        private It should_multiplie_value_by_2 = () => Money.Dollar(5).Times(2).Equals(Money.Dollar(10)).ShouldBeTrue();
    }

    public class When_Multiplicating_Dollar_Few_Times
    {
        Establish context = () =>
        {
            Five = Money.Dollar(5);
        };

        It should_give_10 = () => { Money.Dollar(10).Equals(Five.Times(2)).ShouldBeTrue(); };
        It should_give_15 = () => { Money.Dollar(15).Equals(Five.Times(3)).ShouldBeTrue(); };
        private static Money Five;
    }

    public class When_Multiplicating_Franc_Few_Times
    {
        Establish context = () =>
        {
            Five = Money.Franc(5);
        };

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
        It should_return_USD_for_dollar = () => { Money.Dollar(1).Currency().ShouldEqual("USD"); };
        It should_return_CHF_for_franc = () => { Money.Franc(1).Currency().ShouldEqual("CHF"); };
    }

    public class When_Adding_Money
    {
        Because of = () => { sum = Money.Dollar(5).Plus(Money.Dollar(5)); };

        It should_add_5_dollars = () => { sum.Equals(Money.Dollar(10)).ShouldBeTrue(); };
        private static Money sum;
    }
}
