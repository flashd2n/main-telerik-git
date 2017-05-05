using Bytes2you.Validation;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Commands
{
    public abstract class Command : ICommand
    {
        private IDatabase database;
        private IModelsFactory modelsFactory;

        public Command(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();

            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory").IsNull().Throw();

            this.database = database;
            this.modelsFactory = factory;
        }

        protected IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        protected IModelsFactory ModelsFactory
        {
            get
            {
                return this.modelsFactory;
            }
        }

        public abstract string Execute(IList<string> parameters);
    }
}
