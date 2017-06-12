using DecoratorAdapterComposite.Interfaces;
using Launch.NinjectModules;
using Ninject;
using System;

namespace Launch
{
    public class Startup
    {
        static void Main()
        {
            //// no IoC

            //var factory = new DecoratorAdapterCompositeFactory();

            //var surgeProtector = factory.CreateDevice();

            // with IoC

            var kernel = new StandardKernel(new DecoratorAdapterCompositeModule());

            var surgeProtector = kernel.Get<IElectricalDevice>(DecoratorAdapterCompositeModule.SurgeProtector);

            surgeProtector.ConsumeElectricity(20);

            Console.WriteLine(surgeProtector);

            Console.WriteLine("------------");

            surgeProtector.ConsumeElectricity(500);

            Console.WriteLine(surgeProtector);

        }

        //public class DecoratorAdapterCompositeFactory : IDevicesFactory
        //{
        //    public IElectricalDevice CreateDevice()
        //    {
        //        var laptop = new BulgarianLaptop();
        //        var americanLaptop = new AmericanLaptop();

        //        var americanAdapter = new Adapter(americanLaptop);

        //        var powerStrip = new PowerStrip(new List<IElectricalDevice>() { laptop, americanAdapter });

        //        var ups = new Ups(powerStrip);

        //        var surgeProtector = new SurgeProtector(ups);

        //        return surgeProtector;
        //    }
        //}
    }
}
