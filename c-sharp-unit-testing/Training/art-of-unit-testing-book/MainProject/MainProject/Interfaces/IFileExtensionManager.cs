using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Interfaces
{
    public interface IFileExtensionManager
    {
        bool IsValid(string fileName);
    }
}
