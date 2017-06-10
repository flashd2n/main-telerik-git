using ElectricalDeviceManager.Interfaces;
using ElectricalDeviceManager.NinjectModules;
using Ninject;
using System;

namespace ElectricalDeviceManager
{
    public class Startup
    {
        static void Main()
        {

            var kernel = new StandardKernel(new ElectricalDevicesModule());

            var surgeProtector = kernel.Get<IElectricalDevice>(ElectricalDevicesModule.SurgeProtector);

            surgeProtector.ConsumeElectricity(20);

            Console.WriteLine(surgeProtector);

            Console.WriteLine("------------");

            surgeProtector.ConsumeElectricity(500);

            Console.WriteLine(surgeProtector);

        }
    }
}
