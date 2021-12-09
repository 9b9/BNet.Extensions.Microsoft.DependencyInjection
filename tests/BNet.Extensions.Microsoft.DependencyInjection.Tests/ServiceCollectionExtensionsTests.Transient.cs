using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ServiceCollectionPlusTests.Extensions;
using ServiceCollectionPlusTests.Models;

namespace BNet.Extensions.Microsoft.DependencyInjection.Tests
{
    public partial class ServiceCollectionExtensionsTests
    {
        [Test]
        public void AddTwoInterfaceTransientUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IFoo1, IFoo2, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Transient);
            scope1Foo.Should().BeNull();
            scope2Foo.Should().BeNull();
            instances.Should().AllNotBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());
        }

        [Test]
        public void AddTwoInterfaceTransientUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IFoo1, IFoo2, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),

                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Transient);
            scope1Foo.Should().BeNull();
            scope2Foo.Should().BeNull();
            instances.Should().AllNotBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }

        [Test]
        public void AddThreeInterfaceTransientUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IFoo1, IFoo2, IFoo3, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
                scope1.ServiceProvider.GetService<IFoo3>(),

                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Transient);
            scope1Foo.Should().BeNull();
            scope2Foo.Should().BeNull();
            instances.Should().AllNotBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());
        }

        [Test]
        public void AddThreeInterfaceTransientUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IFoo1, IFoo2, IFoo3, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
                scope1.ServiceProvider.GetService<IFoo3>(),

                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Transient);
            scope1Foo.Should().BeNull();
            scope2Foo.Should().BeNull();
            instances.Should().AllNotBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }
    }
}