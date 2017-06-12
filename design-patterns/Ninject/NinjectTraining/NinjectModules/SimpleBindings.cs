using Interfaces;
using ModelsAndCommands.LogicClasses;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;

namespace NinjectModules
{
    public class SimpleBindings : NinjectModule
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
            surgeProtector.WithConstructorArgument(this.Kernel.Get<IElectricalDevice>(Ups));
        }
    }
}
