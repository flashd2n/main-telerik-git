namespace Facade.Before
{
    public class Engine
    {
        public Engine(IStudentProvider studentProvider, ITeacherProvider teacherProvider, IMarkProvider markProvider, IWriterProvider writerProvider, ILoggerProvider loggerProvider, IReaderProvider readerProvider)
        {

        }

        public void DiiKonio()
        {
            // read stuff

            // do stuff with students, teachers and marks

            // write stuff
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
