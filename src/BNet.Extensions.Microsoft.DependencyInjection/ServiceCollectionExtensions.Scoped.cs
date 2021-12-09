using System;
using Microsoft.Extensions.DependencyInjection;

namespace BNet.Extensions.Microsoft.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a scoped service of the type specified in TService and TService2 with a factory specified
        /// in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddScoped<TService1, TImplementation>()
            .AddScoped<TService2>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a scoped service of the type specified in TService and TService2 with a factory specified
        /// in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddScoped<TService1>(implementationFactory)
            .AddScoped<TService2>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a scoped service of the type specified in TService, TService2 and TService3 with a factory specified
        /// in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddScoped<TService1, TImplementation>()
            .AddScoped<TService2>(factory => factory.GetService<TService1>() as TImplementation)
            .AddScoped<TService3>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a scoped service of the type specified in TService, TService2 and TService3 with a factory specified
        /// in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddScoped<TService1>(implementationFactory)
            .AddScoped<TService2>(factory => factory.GetService<TService1>() as TImplementation)
            .AddScoped<TService3>(factory => factory.GetService<TService1>() as TImplementation);
    }
}
