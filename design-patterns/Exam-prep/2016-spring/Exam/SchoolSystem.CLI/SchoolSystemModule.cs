using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Factories;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Extensions.Interception;
using System.Diagnostics;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = "CreateStudent";
        private const string CreateTeacherCommandName = "CreateTeacher";
        private const string RemoveStudentCommandName = "RemoveStudent";
        private const string RemoveTeacherCommandName = "RemoveTeacher";
        private const string StudentListMarksCommandName = "StudentListMarks";
        private const string TeacherAddMarkCommandName = "TeacherAddMark";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IIdProvider>().To<PersonIdProvider>().InSingletonScope();
            this.Bind<IDatabase>().To<InMemoryDatabase>().InSingletonScope();
            
            this.Bind<IParser>().To<CommandParserProvider>();
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();

            var modelsFactoryBinding = this.Bind<IModelsFactory>().ToFactory();
            var commandFactoryBinding = this.Bind<ICommandFactory>().ToFactory();

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            this.Bind<ICommand>().ToMethod(c =>
            {
                string commandName = (string)c.Parameters.Single().GetValue(c, null);

                try
                {
                    ICommand command = c.Kernel.Get<ICommand>(commandName);
                    return command;
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Command was not found in the factory");
                }

            }).NamedLikeFactoryMethod((ICommandFactory fac) => fac.GetCommand(null));

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<StopWatchInterceptor>();
                modelsFactoryBinding.Intercept().With<StopWatchInterceptor>();
            }
        }
    }

    public class StopWatchInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name != "CreateTeacher")
            {
                Stopwatch stopwatch = new Stopwatch();

                var parameters = invocation.Request.Method.GetParameters();

                var names = parameters.Select(p => p.Name).ToArray();
                var types = parameters.Select(p => p.ParameterType.Name).ToArray();

                Console.WriteLine($"Method: {invocation.Request.Method.Name} | Type: {invocation.Request.Method.DeclaringType.Name}");
                Console.WriteLine($"Parameters: {string.Join(", ", names)} | Types: {string.Join(", ", types)}");

                stopwatch.Start();
                invocation.Proceed();
                stopwatch.Stop();

                Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds}");
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}