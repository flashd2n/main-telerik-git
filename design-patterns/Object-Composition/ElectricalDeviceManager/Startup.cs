using ElectricalDeviceManager.Interfaces;
using ElectricalDeviceManager.NinjectModules;
using Ninject;
using System;
using System.IO;

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


            var serviceFactory = new ServiceFactory();

            using (var serviceConnection = serviceFactory.GetService())
            {
                //...
            }


        }
    }

    public class ServiceFactory
    {
        public ServiceFactory()
        {

        }

        public IServiceConnection GetService()
        {

            return new ServiceConnection(null);
        }
    }

    public interface IServiceConnection : IDisposable
    {
        void ConnectToService();
    }

    public class ServiceConnection : IServiceConnection
    {
        public ServiceConnection(ILogger logger)
        {

        }

        public void ConnectToService()
        {
            //..
        }

        public void Dispose()
        {
            // ..
        }
    }

    public interface IDevicesFactory
    {
        IElectricalDevice GetDevice(DeviceType deviceType);
    }

    public enum DeviceType
    {
        Gsm,
        BulgarianLaptop
    }

    //public class DevicesFactory : IDevicesFactory
    //{
    //    private readonly IKernel kernel;

    //    public DevicesFactory(IKernel kernel)
    //    {
    //        this.kernel = kernel;
    //    }

    //    public IElectricalDevice GetDevice(DeviceType deviceType)
    //    {
    //        IElectricalDevice device = null;

    //        switch (deviceType)
    //        {
    //            case DeviceType.Gsm:
    //                device = this.kernel.Get<IElectricalDevice>(ElectricalDevicesModule.GsmName);
    //                break;
    //            case DeviceType.BulgarianLaptop:
    //                device = this.kernel.Get<IElectricalDevice>(ElectricalDevicesModule.BulgarianLaptop);
    //                break;
    //            default:
    //                break;
    //        }

    //        return device;
    //    }
    //}


}
