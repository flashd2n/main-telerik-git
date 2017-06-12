using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFactory
{
    public class Example
    {
        private readonly IServiceFactory serviceFactory;

        public Example(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public void DoWorkWithService()
        {

            using (var service = this.serviceFactory.GetService())
            {

            }

        }

    }

    public class ServiceFactory : IServiceFactory
    {
        public ServiceFactory()
        {

        }

        public IServiceConnection GetService()
        {
            return new ServiceConnection();
        }

    }

    public class ServiceConnection : IServiceConnection
    {
        public void OpenConnection()
        {

        }

        public void Dispose()
        {

        }
    }

    public interface IServiceFactory
    {
        IServiceConnection GetService();
    }

    public interface IServiceConnection : IDisposable
    {
        void OpenConnection();
    }
}
