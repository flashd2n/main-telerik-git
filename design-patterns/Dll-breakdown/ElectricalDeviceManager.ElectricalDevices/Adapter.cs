using ElectricalDeviceManager.Interfaces;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class Adapter : IElectricalDevice
    {
        private readonly IAmericanElectricalDevice miscConsumer;

        public Adapter(IAmericanElectricalDevice miscConsumer)
        {
            this.miscConsumer = miscConsumer;
        }

        public void ConsumeElectricity(double electricity)
        {
            this.miscConsumer.ConsumeAmericanElectricity(electricity);
        }
        public override string ToString()
        {
            return string.Format($"Adapter with:\n{this.miscConsumer}");
        }
    }
}
