using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    public class FakeExtensionManager : IFileExtensionManager
    {
        public bool willBeValid = false;
        public Exception willThrow = null;

        public bool IsValid(string fileName)
        {
            if (willThrow != null)
            {
                throw willThrow;
            }
            return willBeValid;
        }
    }
}
