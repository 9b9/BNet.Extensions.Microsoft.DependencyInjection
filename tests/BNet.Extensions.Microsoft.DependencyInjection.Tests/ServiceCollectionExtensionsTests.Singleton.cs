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
        public void AddTwoInterfaceSingletonUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddSingleton<IFoo1, IFoo2, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllNotBeSameAs(null);
            instances.Should().AllBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());
        }

        [Test]
        public void AddTwoInterfaceSingletonUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddSingleton<IFoo1, IFoo2, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllNotBeSameAs(null);
            instances.Should().AllBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }

        [Test]
        public void AddTwoInterfaceSingletonUsingInstance_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            var expected = new Foo("123");
            services.AddSingleton<IFoo1, IFoo2, Foo>(expected);
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllBeSameAs(expected);
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }

        [Test]
        public void AddThreeInterfaceSingletonUsingDefaultCtor_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddSingleton<IFoo1, IFoo2, IFoo3, Foo>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo3>(),
                provider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllNotBeSameAs(null);
            instances.Should().AllBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeTrue());
        }

        [Test]
        public void AddThreeInterfaceSingletonUsingFactory_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            services.AddSingleton<IFoo1, IFoo2, IFoo3, Foo>(p => new Foo("123"));
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo3>(),
                provider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllNotBeSameAs(null);
            instances.Should().AllBeSame();
            instances
                .Where(f => f is IFoo1)
                .ToList()
                .ForEach(f => (f as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }

        [Test]
        public void AddThreeInterfaceSingletonUsingInstance_GetServiceByInterface_ReturnsSameInstance()
        {
            // arrange
            var services = new ServiceCollection();
            var expected = new Foo("123");
            services.AddSingleton<IFoo1, IFoo2, IFoo3, Foo>(expected);
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            // act
            var foo = provider.GetService<Foo>();
            var instances = new List<object>()
            {
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo1>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo2>(),
                provider.GetService<IFoo3>(),
                provider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo1>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo2>(),
                scope.ServiceProvider.GetService<IFoo3>(),
                scope.ServiceProvider.GetService<IFoo3>(),
            };

            // assert
            services.Should().OnlyContain(sd => sd.Lifetime == ServiceLifetime.Singleton);
            foo.Should().BeNull();
            instances.Should().AllNotBeSameAs(null);
            instances.Should().AllBeSameAs(expected);
            instances
                .Where(f => f is IFoo1)
                    .ToList()
                    .ForEach(a => (a as IFoo1).IsParameterlessCtor.Should().BeFalse());
        }
    }
}