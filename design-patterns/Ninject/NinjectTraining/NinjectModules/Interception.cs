using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using System;
using System.Diagnostics;

namespace NinjectModules
{
    public class Interception : NinjectModule
    {
        public override void Load()
        {
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

                Console.WriteLine($"Method: {invocation.Request.Method.Name} | Type: {invocation.Request.Method.DeclaringType.Name}");

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

    public interface IModelsFactory
    {

    }
}
