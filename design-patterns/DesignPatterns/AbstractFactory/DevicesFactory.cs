using DecoratorAdapterComposite.Interfaces;
using Launch.NinjectModules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IDevicesFactory
    {
        IElectricalDevice CreateDevice(DeviceType deviceType);
    }

    public enum DeviceType
    {
        Gsm,
        BulgarianLaptop
    }

    public class DevicesFactory : IDevicesFactory
    {
        private readonly IKernel kernel;

        public DevicesFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IElectricalDevice CreateDevice(DeviceType deviceType)
        {
            IElectricalDevice device = null;

            switch (deviceType)
            {
                case DeviceType.Gsm:
                    device = this.kernel.Get<IElectricalDevice>(DecoratorAdapterCompositeModule.GsmName);
                    break;
                case DeviceType.BulgarianLaptop:
                    device = this.kernel.Get<IElectricalDevice>(DecoratorAdapterCompositeModule.BulgarianLaptop);
                    break;
                default:
                    break;
            }

            return device;
        }
    }
}
