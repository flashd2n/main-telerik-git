using MainProject;
using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    public class FakeLogAnalyzerStubChapter : LogAnalyzerStubChapter
    {
        public IFileExtensionManager manager;

        public FakeLogAnalyzerStubChapter() : base()
        {

        }

        protected override IFileExtensionManager GetManager()
        {
            return this.manager;
        }


    }
}
