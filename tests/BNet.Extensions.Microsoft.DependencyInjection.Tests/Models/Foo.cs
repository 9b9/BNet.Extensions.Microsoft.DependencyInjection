namespace ServiceCollectionPlusTests.Models
{
#pragma warning disable SA1649 // SA1649FileNameMustMatchTypeName
    internal interface IFoo1
    {
        bool IsParameterlessCtor { get; }
    }

    internal interface IFoo2
    {
    }

    internal interface IFoo3
    {
    }

    internal class Foo : IFoo1, IFoo2, IFoo3
    {
        public Foo()
        {
            IsParameterlessCtor = true;
        }

        public Foo(string test)
        {
            IsParameterlessCtor = false;
        }

        public bool IsParameterlessCtor { get; }
    }
#pragma warning restore SA1649 // SA1649FileNameMustMatchTypeName
}