using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class FileExtensionManager : IFileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            // reads the fileName and accesses the filesystem
            // returns true for valid and false for invalid names
            return false;
        }
    }
}
