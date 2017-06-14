using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using System;
using System.Diagnostics;
using System.Linq;

namespace NinjectModules
{
    public class Interception : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAwesome>().ToSelf().Intercept().With<StopWatchInterceptor>(); // always intercepted

            var modelsFactoryBinding = this.Bind<IModelsFactory>().ToFactory();

            if (true)
            {
                modelsFactoryBinding.Intercept().With<StopWatchInterceptor>();
            }

        }
    }

    public class StopWatchInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name != "CreateTeacher") // makes basic method filtering
            {
                Stopwatch stopwatch = new Stopwatch();

                var parameters = invocation.Request.Method.GetParameters();

                var names = parameters.Select(p => p.Name).ToArray();
                var types = parameters.Select(p => p.ParameterType.Name).ToArray();

                Console.WriteLine($"Method: {invocation.Request.Method.Name} | Type: {invocation.Request.Method.DeclaringType.Name}");
                Console.WriteLine($"Parameters: {string.Join(", ", names)} | Types: {string.Join(", ", types)}");


                stopwatch.Start();
                invocation.Proceed();
                stopwatch.Stop();

                Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds}");
            }
            else
            {
                invocation.Proceed();
            }
        }
    }

    public interface IAwesome
    {

    }

    public interface IModelsFactory
    {

    }
}
