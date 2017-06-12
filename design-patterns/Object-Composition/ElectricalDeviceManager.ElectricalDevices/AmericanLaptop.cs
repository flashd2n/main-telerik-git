using ElectricalDeviceManager.Interfaces;
using System;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class AmericanLaptop : Laptop, IAmericanElectricalDevice
    {
        public void ConsumeAmericanElectricity(double electricity)
        {
            this.ElectricalCapacity = Math.Min(this.ElectricalCapacity + electricity, MaxCapacity);
        }

        public override string ToString()
        {
            return string.Format($"American {base.ToString()}");
        }
    }
}
