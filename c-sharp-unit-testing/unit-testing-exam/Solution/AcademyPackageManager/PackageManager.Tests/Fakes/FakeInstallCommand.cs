using PackageManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Fakes
{
    internal class FakeInstallCommand : InstallCommand
    {

        public FakeInstallCommand(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }

        public IInstaller<IPackage> GetInstaller()
        {
            return this.Installer;
        }

        public IPackage GetPackage()
        {
            return this.Package;
        }
    }
}
