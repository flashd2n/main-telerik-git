using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using System;
using System.Linq;
using Ninject.Extensions.Factory;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Data;
using Ninject.Extensions.Interception.Infrastructure.Language;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Data.Models;
using ProjectManager.Framework.Data.Models.States;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateProjectCommandName = "createproject";
        private const string CreateUserCommandName = "createuser";
        private const string CreateTaskCommandName = "createtask";
        private const string ListProjectsCommandName = "listprojects";
        private const string ListProjectDetailsCommandName = "listprojectdetails";

        private const string UnValidatedCreateProjectCommandName = "unvalcreateproject";
        private const string UnValidatedCreateUserCommandName = "unvalcreateuser";
        private const string UnValidatedCreateTaskCommandName = "unvalcreatetask";
        private const string UnValidatedListProjectsCommandName = "unvallistprojects";
        private const string UnValidatedListProjectDetailsCommandName = "unvallistprojectdetails";

        private const string CachedListProjectDetailsCommandName = "cachedlistprojectscommand";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(CachingService) && type != typeof(Validator))
                .BindDefaultInterface();
            });

            this.Bind<IModelsFactory>().ToFactory();

            IConfigurationProvider configurationProviderBinding = Kernel.Get<IConfigurationProvider>();

            this.Bind<IDatabase>().To<InMemoryDatabase>().InSingletonScope();

            this.Bind<ICachingService>().To<CachingService>().WithConstructorArgument(configurationProviderBinding.CacheDurationInSeconds);

            var commandProcessorBinding = this.Bind<IProcessor>().To<CommandProcessor>();
            commandProcessorBinding.Intercept().With<LogErrorInterceptor>();

            this.Bind<IValidator>().To<Validator>().InSingletonScope();

            this.Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument(configurationProviderBinding.LogFilePath);
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();

            var createProjectBinding = this.Bind<ICommand>().To<CreateProjectCommand>().Named(UnValidatedCreateProjectCommandName);
            var createUserBinding = this.Bind<ICommand>().To<CreateUserCommand>().Named(UnValidatedCreateUserCommandName);
            var createTaskBinding = this.Bind<ICommand>().To<CreateTaskCommand>().Named(UnValidatedCreateTaskCommandName);
            var ListProjectBinding = this.Bind<ICommand>().To<ListProjectsCommand>().Named(UnValidatedListProjectsCommandName);
            var ListProjectsDetailsBinding = this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(UnValidatedListProjectDetailsCommandName);

            var validatedCreateProjectBinding = this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateProjectCommandName);
            validatedCreateProjectBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(UnValidatedCreateProjectCommandName));

            var validatedCreateUserBinding = this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateUserCommandName);
            validatedCreateUserBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(UnValidatedCreateUserCommandName));

            var validatedCreateTaskBinding = this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateTaskCommandName);
            validatedCreateTaskBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(UnValidatedCreateTaskCommandName));
            
            var cachedListProjectsBinding = this.Bind<ICommand>().To<CacheableCommand>().InSingletonScope().Named(CachedListProjectDetailsCommandName);
            cachedListProjectsBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(UnValidatedListProjectsCommandName));
            
            var validatedListProjectBinding = this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectsCommandName);
            validatedListProjectBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(CachedListProjectDetailsCommandName));
            
            var validatedListProjectDetailsBinding = this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectDetailsCommandName);
            validatedListProjectDetailsBinding.WithConstructorArgument(this.Kernel.Get<ICommand>(UnValidatedListProjectDetailsCommandName));
            
            this.Bind<ICommandsFactory>().ToFactory();
            this.Bind<ICommand>().ToMethod(c =>
            {
                string commandName = (string)c.Parameters.Single().GetValue(c, null);

                try
                {
                    ICommand command = c.Kernel.Get<ICommand>(commandName.ToLower());
                    return command;
                }
                catch (Exception e)
                {
                    throw new UserValidationException("No such command!");
                }

            }).NamedLikeFactoryMethod((ICommandsFactory fac) => fac.GetCommandFromString(null));


            
            this.Bind<Project>().ToMethod(c =>
            {
                string name = (string)c.Parameters.ElementAt(0).GetValue(c, null);
                string startingDate = (string)c.Parameters.ElementAt(1).GetValue(c, null);
                string endingDate = (string)c.Parameters.ElementAt(2).GetValue(c, null);
                string state = (string)c.Parameters.ElementAt(3).GetValue(c, null);

                DateTime startingDateParsed;
                DateTime endingDateParsed;
                ProjectState stateParsed;

                var startingDateSuccessful = DateTime.TryParse(startingDate, out startingDateParsed);
                var endingDateSuccessful = DateTime.TryParse(endingDate, out endingDateParsed);
                var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

                if (!startingDateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed starting date!");
                }

                if (!endingDateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed ending date!");
                }

                if (!stateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed project state!");
                }

                var project = new Project(name, startingDateParsed, endingDateParsed, stateParsed);

                var validator = this.Kernel.Get<IValidator>();
                validator.Validate(project);

                return project;

            }).NamedLikeFactoryMethod((IModelsFactory fac) => fac.GetProject(null, null, null, null));

            this.Bind<Task>().ToMethod(c =>
            {
                User owner = (User)c.Parameters.ElementAt(0).GetValue(c, null);
                string name = (string)c.Parameters.ElementAt(1).GetValue(c, null);
                string state = (string)c.Parameters.ElementAt(2).GetValue(c, null);

                TaskState stateParsed;
                var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

                if (!stateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed Task state!");
                }

                var task = new Task(name, owner, stateParsed);

                var validator = this.Kernel.Get<IValidator>();
                validator.Validate(task);

                return task;

            }).NamedLikeFactoryMethod((IModelsFactory fac) => fac.GetTask(null, null, null));

            this.Bind<User>().ToMethod(c =>
            {
                string username = (string)c.Parameters.ElementAt(0).GetValue(c, null);
                string email = (string)c.Parameters.ElementAt(1).GetValue(c, null);

                var user = new User(username, email);

                var validator = this.Kernel.Get<IValidator>();
                validator.Validate(user);

                return user;

            }).NamedLikeFactoryMethod((IModelsFactory fac) => fac.GetUser(null, null));

        }
    }
}
