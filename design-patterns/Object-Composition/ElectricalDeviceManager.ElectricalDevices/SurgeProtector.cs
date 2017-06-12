using Bytes2you.Validation;
using ElectricalDeviceManager.Interfaces;
using System;

namespace ElectricalDeviceManager.ElectricalDevices
{
    public class SurgeProtector : IElectricalDevice
    {
        private const double MaxElectricityAllowed = 100;

        private readonly IElectricalDevice electricalConsumer;

        private readonly DateTime activeDate;

        public SurgeProtector(IElectricalDevice electricalConsumer, TimeSpan duration)
        {
            this.electricalConsumer = electricalConsumer;
            this.activeDate = DateTimeProvider.Instance.UtcNow.Add(duration);
        }

        public void ConsumeElectricity(double electricity)
        {
            if (this.activeDate <= DateTimeProvider.Instance.UtcNow || electricity <= MaxElectricityAllowed)
            {
                this.electricalConsumer.ConsumeElectricity(electricity);
            }
        }

        public override string ToString()
        {
            return string.Format($"Defender with: \n{this.electricalConsumer}");
        }

    }

    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

    public abstract class DateTimeProvider : IDateTimeProvider
    {
        private static IDateTimeProvider instance;

        static DateTimeProvider()
        {
            instance = new DefaultDateTimeProvider();
        }

        public abstract DateTime UtcNow { get; }

        public static IDateTimeProvider Instance
        {
            get
            {
                return instance;
            }

            set
            {
                Guard.WhenArgument(value, "value").IsNull().Throw();

                instance = value;
            }
        }

        public void ResetProvider()
        {
            instance = new DefaultDateTimeProvider();
        }
    }

    public class DefaultDateTimeProvider : DateTimeProvider
    {
        public override DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }

}
