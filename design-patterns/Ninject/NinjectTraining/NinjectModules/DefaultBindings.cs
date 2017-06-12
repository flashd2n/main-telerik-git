using Ninject.Modules;
using System.Reflection;
using Ninject.Extensions.Conventions;
using System.IO;

namespace NinjectModules
{
    public class DefaultBindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });
        }
    }
}
