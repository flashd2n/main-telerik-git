using Bytes2you.Validation;
using ElectricalDeviceManager.Interfaces;
using System;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class Ups : IElectricalDevice
    {
        private const double MaxReservedCapacity = 50;
        private const double PassedElectricity = 5;

        private IElectricalDevice electricalConsumer;

        public Ups(IElectricalDevice electricalConsumer)
        {
            Guard.WhenArgument(electricalConsumer, "electrical consumer").IsNull().Throw();

            this.electricalConsumer = electricalConsumer;
        }

        public double ReservedCapacity { get; private set; }

        public IElectricalDevice ElectricalConsumer
        {
            get
            {
                if (this.electricalConsumer == null)
                {
                    this.electricalConsumer = new BulgarianLaptop();
                }

                return this.electricalConsumer;
            }

            set
            {
                Guard.WhenArgument(value, "value").IsNull().Throw();

                this.electricalConsumer = value;
            }
        }

        public void ConsumeElectricity(double electricity)
        {
            double electricityToPass = electricity;

            if (electricityToPass > 0)
            {
                this.ReservedCapacity = Math.Min(this.ReservedCapacity + electricityToPass, MaxReservedCapacity);
            }
            else if (this.ReservedCapacity > 0)
            {
                electricityToPass = Math.Min(PassedElectricity, this.ReservedCapacity);
                this.ReservedCapacity -= electricityToPass;
            }

            this.electricalConsumer.ConsumeElectricity(electricityToPass);

        }

        public override string ToString()
        {
            return string.Format($"Ups with reserved capacity {(this.ReservedCapacity / MaxReservedCapacity) * 100}% and device:\n{this.electricalConsumer}");
        }
    }
}
