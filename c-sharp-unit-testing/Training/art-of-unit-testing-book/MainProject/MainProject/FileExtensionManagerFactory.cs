using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public static class FileExtensionManagerFactory
    {
        private static IFileExtensionManager manager = null;

        public static IFileExtensionManager Create()
        {

            if (manager == null)
            {
                return new FileExtensionManager();
            }

            return manager;
        }

        public static void SetManager(IFileExtensionManager mng)
        {
            manager = mng;
        }
    }
}
