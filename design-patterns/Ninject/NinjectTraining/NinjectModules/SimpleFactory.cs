using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace NinjectModules
{
    public class SimpleFactory : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISimpleFactory>().ToFactory();
        }
    }

    public interface ISimpleFactory
    {
        Person CreatePerson(string name);
        Animal CreateAnimal(string petName);
    }

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public class Animal
    {
        public Animal(string petName)
        {
            this.PetName = petName;
        }

        public string PetName { get; set; }
    }

}
