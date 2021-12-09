using System.Linq;
using FluentAssertions;
using FluentAssertions.Collections;

namespace ServiceCollectionPlusTests.Extensions
{
    public static class GenericCollectionAssertionsExtensions
    {
        public static AndConstraint<GenericCollectionAssertions<T>> AllBeSame<T>(this GenericCollectionAssertions<T> assertions)
        {
            var expected = assertions.Subject.FirstOrDefault();

            return assertions.AllBeSameAs(expected);
        }

        public static AndConstraint<GenericCollectionAssertions<T>> AllBeSameAs<T>(this GenericCollectionAssertions<T> assertions, T expected)
        {
            if (assertions.Subject?.Count() > 0)
            {
                foreach (var actual in assertions.Subject)
                {
                    actual.Should().BeSameAs(expected);
                }
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(assertions);
        }

        public static AndConstraint<GenericCollectionAssertions<T>> AllNotBeSame<T>(this GenericCollectionAssertions<T> assertions)
        {
            if (assertions.Subject?.Count() > 0)
            {
                var expected = assertions.Subject.FirstOrDefault();
                for (int index = 1; index < assertions.Subject.Count(); index++)
                {
                    assertions.Subject.ElementAt(index).Should().NotBeSameAs(expected);
                }
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(assertions);
        }

        public static AndConstraint<GenericCollectionAssertions<T>> AllNotBeSameAs<T>(this GenericCollectionAssertions<T> assertions, T expected)
        {
            if (assertions.Subject?.Count() > 0)
            {
                foreach (var actual in assertions.Subject)
                {
                    actual.Should().NotBeSameAs(expected);
                }
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(assertions);
        }
    }
}