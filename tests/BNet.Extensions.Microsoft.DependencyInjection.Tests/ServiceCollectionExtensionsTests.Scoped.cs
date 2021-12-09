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
        public void AddTwoInterfaceScopedUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddScoped<IFoo1, IFoo2, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope1Instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
            };

            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var scope2Instances = new List<object>()
            {
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Scoped);
            scope1Foo.Should().BeNull();
            scope1Instances.Should().AllNotBeSameAs(null);
            scope1Instances.Should().AllBeSame();
            scope1Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());

            scope2Foo.Should().BeNull();
            scope2Instances.Should().AllNotBeSameAs(null);
            scope2Instances.Should().AllBeSame();
            scope2Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());

            scope1Instances.First().Should().NotBeSameAs(scope2Instances.First());
        }

        [Test]
        public void AddTwoInterfaceScopedUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddScoped<IFoo1, IFoo2, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope1Instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
            };

            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var scope2Instances = new List<object>()
            {
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Scoped);
            scope1Foo.Should().BeNull();
            scope1Instances.Should().AllNotBeSameAs(null);
            scope1Instances.Should().AllBeSame();
            scope1Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());

            scope2Foo.Should().BeNull();
            scope2Instances.Should().AllNotBeSameAs(null);
            scope2Instances.Should().AllBeSame();
            scope2Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());

            scope1Instances.First().Should().NotBeSameAs(scope2Instances.First());
        }

        [Test]
        public void AddThreeInterfaceScopedUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddScoped<IFoo1, IFoo2, IFoo3, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope1Instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
            };

            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var scope2Instances = new List<object>()
            {
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Scoped);
            scope1Foo.Should().BeNull();
            scope1Instances.Should().AllNotBeSameAs(null);
            scope1Instances.Should().AllBeSame();
            scope1Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());

            scope2Foo.Should().BeNull();
            scope2Instances.Should().AllNotBeSameAs(null);
            scope2Instances.Should().AllBeSame();
            scope2Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());

            scope1Instances.First().Should().NotBeSameAs(scope2Instances.First());
        }

        [Test]
        public void AddThreeInterfaceScopedUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddScoped<IFoo1, IFoo2, IFoo3, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope1 = provider.CreateScope();
            using var scope2 = provider.CreateScope();

            // act
            var scope1Foo = scope1.ServiceProvider.GetService<Foo>();
            var scope1Instances = new List<object>()
            {
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo1>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo2>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
                scope1.ServiceProvider.GetService<IFoo3>(),
            };

            var scope2Foo = scope2.ServiceProvider.GetService<Foo>();
            var scope2Instances = new List<object>()
            {
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo1>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo2>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
                scope2.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Scoped);
            scope1Foo.Should().BeNull();
            scope1Instances.Should().AllNotBeSameAs(null);
            scope1Instances.Should().AllBeSame();
            scope1Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());

            scope2Foo.Should().BeNull();
            scope2Instances.Should().AllNotBeSameAs(null);
            scope2Instances.Should().AllBeSame();
            scope2Instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());

            scope1Instances.First().Should().NotBeSameAs(scope2Instances.First());
        }
    }
}