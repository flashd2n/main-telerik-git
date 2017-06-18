namespace ProjectManager.Framework.Core.Common.Contracts
{
    public interface IWriter
    {
        void Write(string value);

        void WriteLine(string value);
    }
}
