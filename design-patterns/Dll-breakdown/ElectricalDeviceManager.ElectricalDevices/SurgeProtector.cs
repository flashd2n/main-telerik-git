using ElectricalDeviceManager.Interfaces;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class SurgeProtector : IElectricalDevice
    {
        private const double MaxElectricityAllowed = 100;

        private readonly IElectricalDevice electricalConsumer;

        public SurgeProtector(IElectricalDevice electricalConsumer)
        {
            this.electricalConsumer = electricalConsumer;
        }

        public void ConsumeElectricity(double electricity)
        {
            if (electricity <= MaxElectricityAllowed)
            {
                this.electricalConsumer.ConsumeElectricity(electricity);
            }
        }

        public override string ToString()
        {
            return string.Format($"Defender with: \n{this.electricalConsumer}");
        }

    }
}
