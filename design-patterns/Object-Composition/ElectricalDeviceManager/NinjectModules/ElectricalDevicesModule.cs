using ElectricalDeviceManager.ElectricalDevices;
using ElectricalDeviceManager.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject.Extensions.Conventions;
using System.IO;
using Ninject.Extensions.Factory;
using System.Linq;

namespace ElectricalDeviceManager.NinjectModules
{
    class ElectricalDevicesModule : NinjectModule
    {
        public const string GsmName = "Gsm";
        public const string BulgarianLaptop = "Bulgarian Laptop";
        public const string AmericanLaptop = "American Laptop";
        public const string PrimaryAdapter = "Primary Adapter";
        public const string PowerStrip = "Power Strip";
        public const string Ups = "Ups";
        public const string SurgeProtector = "Surge Protector";

        public override void Load()
        {
            this.Kernel.Bind(x => {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            var gsm = this.Bind<IElectricalDevice>().To<Gsm>().Named(GsmName);
            var bulgarianLaptop = this.Bind<IElectricalDevice>().To<BulgarianLaptop>().Named(BulgarianLaptop);
            var americanLaptop = this.Bind<IAmericanElectricalDevice>().To<AmericanLaptop>().Named(AmericanLaptop);
            var adapter = this.Bind<IElectricalDevice>().To<Adapter>().Named(PrimaryAdapter);
            var powerStrip = this.Bind<IElectricalDevice>().To<PowerStrip>().Named(PowerStrip);
            var ups = this.Bind<IElectricalDevice>().To<Ups>().InSingletonScope().Named(Ups);
            var surgeProtector = this.Bind<IElectricalDevice>().To<SurgeProtector>().Named(SurgeProtector);

            adapter.WithConstructorArgument(this.Kernel.Get<IAmericanElectricalDevice>(AmericanLaptop));
            powerStrip.WithConstructorArgument<IEnumerable<IElectricalDevice>>(new List<IElectricalDevice>()
            {
                this.Kernel.Get<IElectricalDevice>(BulgarianLaptop),
                this.Kernel.Get<IElectricalDevice>(PrimaryAdapter)
            });

            ups.WithConstructorArgument(this.Kernel.Get<IElectricalDevice>(PowerStrip));

            surgeProtector
                .WithConstructorArgument(this.Kernel.Get<IElectricalDevice>(Ups))
                .WithConstructorArgument(new TimeSpan(365, 0, 0, 0, 0));

            this.Bind<IDevicesFactory>().ToFactory();

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

            }).NamedLikeFactoryMethod((IDevicesFactory fac) => fac.GetDevice(DeviceType.BulgarianLaptop));

        }
    }
}
