using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly ICachingService cachingService;

        public CacheableCommand(ICommand command, ICachingService cachingService)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(cachingService, "cachingService").IsNull().Throw();

            this.command = command;
            this.cachingService = cachingService;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            var currentClassName = this.command.GetType().Name;
            var currentMethodName = this.GetMethodName();

            if (this.cachingService.IsExpired)
            {
                this.cachingService.ResetCache();

                var result = this.command.Execute(parameters);
                
                this.cachingService.AddCacheValue(currentClassName, currentMethodName, result);

                return result;
            }
            else
            {
                var result = this.cachingService.GetCacheValue(currentClassName, currentMethodName);

                return result.ToString();
            }
        }

        private string GetMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);

            var currentMethodName = sf.GetMethod().Name;

            return currentMethodName;
        }
    }
}
