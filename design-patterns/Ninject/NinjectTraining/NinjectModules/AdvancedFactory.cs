using Ninject.Extensions.Factory;
using Ninject.Modules;
using System.Linq;
using Ninject;
using Interfaces;
using ModelsAndCommands.LogicClasses;

namespace NinjectModules
{
    public class AdvancedFactory : NinjectModule
    {
        public const string GsmName = "Gsm";
        public const string BulgarianLaptop = "Bulgarian Laptop";

        public override void Load()
        {
            var gsm = this.Bind<IElectricalDevice>().To<Gsm>().Named(GsmName);
            var bulgarianLaptop = this.Bind<IElectricalDevice>().To<BulgarianLaptop>().Named(BulgarianLaptop);

            this.Bind<IAdvancedFactory>().ToFactory();
            this.Bind<IElectricalDevice>().ToMethod(c =>
            {
                DeviceType deviceType = (DeviceType)c.Parameters.Single().GetValue(c, null);

                IElectricalDevice device = null;

                switch (deviceType)
                {
                    case DeviceType.Gsm:
                        device = c.Kernel.Get<IElectricalDevice>(GsmName);
                        break;
                    case DeviceType.BulgarianLaptop:
                        device = c.Kernel.Get<IElectricalDevice>(BulgarianLaptop);
                        break;
                    default:
                        break;
                }

                return device;

            }).NamedLikeFactoryMethod((IAdvancedFactory fac) => fac.GetDevice(DeviceType.BulgarianLaptop));
        }
    }


    public interface IAdvancedFactory
    {
        IElectricalDevice GetDevice(DeviceType deviceType);
    }

    public enum DeviceType
    {
        Gsm,
        BulgarianLaptop
    }
}
