using System;
using Microsoft.Extensions.DependencyInjection;

namespace BNet.Extensions.Microsoft.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a singleton service of the type specified in TService1 and TService2 with an implementation
        /// type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddSingleton<TService1, TImplementation>()
            .AddSingleton<TService2, TImplementation>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a singleton service of the type specified in TService1 and TService2 with an implementation
        /// type specified in TImplementation using the factory specified in implementationFactory
        /// to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddSingleton<TService1, TImplementation>(implementationFactory)
            .AddSingleton<TService2, TImplementation>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a singleton service of the type specified in TService1 and TService2 with an instance specified
        ///  in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2
            => services
            .AddSingleton<TService1>(implementationInstance)
            .AddSingleton<TService2>(implementationInstance);

        /// <summary>
        /// Adds a singleton service of the type specified in TService1, TService2 and TService3 with an implementation
        ///  type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddSingleton<TService1, TImplementation>()
            .AddSingleton<TService2, TImplementation>(factory => factory.GetService<TService1>() as TImplementation)
            .AddSingleton<TService3, TImplementation>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a singleton service of the type specified in TService1, TService2 and TService3 with an implementation
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
        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddSingleton<TService1, TImplementation>(implementationFactory)
            .AddSingleton<TService2, TImplementation>(factory => factory.GetService<TService1>() as TImplementation)
            .AddSingleton<TService3, TImplementation>(factory => factory.GetService<TService1>() as TImplementation);

        /// <summary>
        /// Adds a singleton service of the type specified in TService1, TService2 and TService3 with an instance specified
        ///  in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <typeparam name="TService1">The type of the service to add.</typeparam>
        /// <typeparam name="TService2">The type of the service to add.</typeparam>
        /// <typeparam name="TService3">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3
            => services
            .AddSingleton<TService1>(implementationInstance)
            .AddSingleton<TService2>(implementationInstance)
            .AddSingleton<TService3>(implementationInstance);
    }
}
