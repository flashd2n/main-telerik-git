using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class LogAnalyzerStubChapter
    {

        //// Constructor Injection

        //private IFileExtensionManager manager;

        //public LogAnalyzerStubChapter(IFileExtensionManager mngr)
        //{
        //    if (mngr == null)
        //    {
        //        throw new ArgumentException("Manager cannot be null");
        //    }
        //    this.manager = mngr;
        //}

        //public bool IsValidLogFileName(string fileName)
        //{
        //    bool result;
        //    try
        //    {
        //        result = this.manager.IsValid(fileName);
        //    }
        //    catch (Exception)
        //    {

        //        result = false;
        //    }

        //    return result;
        //}


        //// Property Dependency Injetion

        //private IFileExtensionManager manager;

        //public LogAnalyzerStubChapter()
        //{
        //    manager = new FileExtensionManager();
        //}

        //public IFileExtensionManager Manager
        //{
        //    get
        //    {
        //        return this.manager;
        //    }
        //    set
        //    {
        //        this.manager = value;
        //    }
        //}

        //public bool IsValidLogFileName(string fileName)
        //{

        //    return this.Manager.IsValid(fileName);
        //}



        //// Injecting Dependency by Faking the Factory

        //private IFileExtensionManager manager;

        //public LogAnalyzerStubChapter()
        //{
        //    this.manager = FileExtensionManagerFactory.Create();
        //}

        //public bool IsValidFileName(string fileName)
        //{
        //    return this.manager.IsValid(fileName);
        //}



        // Extract And Override

        protected virtual IFileExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }

        public bool IsValidFileName(string fileName)
        {
            var manager = GetManager();
            return manager.IsValid(fileName);

        }
    }
}
