using Interfaces;
using Ninject;
using NinjectModules;
using System;

namespace Launch
{
    public class Startup
    {
        static void Main()
        {
            // use of simple and default bindings 

            var kernelSimpleBindings = new StandardKernel(new SimpleBindings());

            var surgeProtector = kernelSimpleBindings.Get<IElectricalDevice>(SimpleBindings.SurgeProtector);

            surgeProtector.ConsumeElectricity(20);

            Console.WriteLine(surgeProtector);

            Console.WriteLine("------------");

            // use of simple factory

            var kernelSimpleFactory = new StandardKernel(new SimpleFactory());

            var simpleFactory = kernelSimpleFactory.Get<ISimpleFactory>();

            var person = simpleFactory.CreatePerson("gosho");

            var animal = simpleFactory.CreateAnimal("berg");

            Console.WriteLine($"Person Name: {person.Name}");

            Console.WriteLine($"Animal Name: {animal.PetName}");

            Console.WriteLine("------------");

            // use of advanced factory

            var kernelAdvancedFactory = new StandardKernel(new AdvancedFactory());

            var advancedFactory = kernelAdvancedFactory.Get<IAdvancedFactory>();

            var gsm = advancedFactory.GetDevice(DeviceType.Gsm);

            var bgLaptop = advancedFactory.GetDevice(DeviceType.BulgarianLaptop);

            Console.WriteLine($"GSM: {gsm}");

            Console.WriteLine($"BG Laptop: {bgLaptop}");

            Console.WriteLine("------------");

        }
    }
}
