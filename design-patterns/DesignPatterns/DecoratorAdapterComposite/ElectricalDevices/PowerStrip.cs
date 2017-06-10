using DecoratorAdapterComposite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorAdapterComposite.ElectricalDevices
{
    public class PowerStrip : IElectricalDevice
    {
        private readonly IEnumerable<IElectricalDevice> electricalConsumers;

        public PowerStrip(IEnumerable<IElectricalDevice> electricalConsumers)
        {
            this.electricalConsumers = electricalConsumers;
        }

        public void ConsumeElectricity(double electricity)
        {
            foreach (var consumer in electricalConsumers)
            {
                consumer.ConsumeElectricity(electricity);
            }
        }

        public override string ToString()
        {
            return string.Format($"Power strip with devices:\n{string.Join("\n", this.electricalConsumers)}");
        }
    }
}
