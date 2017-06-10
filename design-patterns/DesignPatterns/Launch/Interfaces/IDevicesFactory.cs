using DecoratorAdapterComposite.Interfaces;

namespace Launch.Interfaces
{
    public interface IDevicesFactory
    {
        IElectricalDevice CreateDevice();
    }
}
