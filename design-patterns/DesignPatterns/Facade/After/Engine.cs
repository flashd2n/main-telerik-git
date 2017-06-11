namespace Facade.After
{
    public class Engine
    {
        private ISchoolSystemService schoolSystemService;
        private IOutputService outputService;

        public Engine(ISchoolSystemService schoolSystemService, IOutputService outputService, IReaderProvider readerProvider)
        {
            this.schoolSystemService = schoolSystemService;
            this.outputService = outputService;
        }

        public void DiiKonio()
        {
            // read stuff

            this.schoolSystemService.DoStuffWithStudentTeacherMarks();

            this.outputService.DoStuffWithWriterAndLogger();
        }
    }

    public interface IOutputService
    {
        void DoStuffWithWriterAndLogger();
    }

    public class OutputService : IOutputService
    {
        public OutputService(IWriterProvider writerProvider, ILoggerProvider loggerProvider)
        {

        }

        public void DoStuffWithWriterAndLogger()
        {
        }
    }

    public interface ISchoolSystemService
    {
        void DoStuffWithStudentTeacherMarks();
    }

    public class SchoolSystemService : ISchoolSystemService
    {
        public SchoolSystemService(IStudentProvider studentProvider, ITeacherProvider teacherProvider, IMarkProvider markProvider)
        {

        }

        public void DoStuffWithStudentTeacherMarks()
        {

        }
    }

    public interface IStudentProvider
    {
    }

    public interface ITeacherProvider
    {
    }

    public interface IMarkProvider
    {
    }

    public interface IWriterProvider
    {
    }

    public interface ILoggerProvider
    {
    }

    public interface IReaderProvider
    {
    }
}
