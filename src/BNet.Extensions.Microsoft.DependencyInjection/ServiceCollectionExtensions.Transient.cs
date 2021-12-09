using System;
using Microsoft.Extensions.DependencyInjection;

namespace BNet.Extensions.Microsoft.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a transient service of the type specified in TService1 and TService2 with an implementation
        ///     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddTransient<TService1, TImplementation>()
            .AddTransient<TService2, TImplementation>();

        /// <summary>
        /// Adds a transient service of the type specified in TService1 and TService2 with an implementation
        /// type specified in TImplementation using the factory specified in implementationFactory
        /// to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(
           this IServiceCollection services,
           Func<IServiceProvider, TImplementation> implementationFactory)
           where TService1 : class
           where TService2 : class
           where TImplementation : class, TService1, TService2
           => services
            .AddTransient<TService1, TImplementation>(implementationFactory)
            .AddTransient<TService2, TImplementation>(implementationFactory);

        /// <summary>
        /// Adds a transient service of the type specified in TService1, TService2 and TService3 with an implementation
        /// type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddTransient<TService1, TImplementation>()
            .AddTransient<TService2, TImplementation>()
            .AddTransient<TService3, TImplementation>();

        /// <summary>
        /// Adds a transient service of the type specified in TService1, TService2 and TService3 with an implementation
        /// type specified in TImplementation using the factory specified in implementationFactory
        /// to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(
           this IServiceCollection services,
           Func<IServiceProvider, TImplementation> implementationFactory)
           where TService1 : class
           where TService2 : class
           where TService3 : class
           where TImplementation : class, TService1, TService2, TService3
           => services
            .AddTransient<TService1, TImplementation>(implementationFactory)
            .AddTransient<TService2, TImplementation>(implementationFactory)
            .AddTransient<TService3, TImplementation>(implementationFactory);
    }
}
