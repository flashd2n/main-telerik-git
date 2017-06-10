using ElectricalDeviceManager.Interfaces;
using System;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class BulgarianLaptop : Laptop, IElectricalDevice
    {
        public void ConsumeElectricity(double electricity)
        {
            this.ElectricalCapacity = Math.Min(this.ElectricalCapacity + electricity, MaxCapacity);
        }

        public override string ToString()
        {
            return string.Format($"Bulgarian {base.ToString()}");
        }
    }
}
