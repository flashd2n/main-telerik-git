namespace ElectricalDeviceManager.ElectricalDevices
{
    public class Laptop
    {
        protected const double MaxCapacity = 100;

        public double ElectricalCapacity { get; protected set; }

        public override string ToString()
        {
            return string.Format($"Laptop with capacity: {(this.ElectricalCapacity / MaxCapacity) * 100}%");
        }
    }
}
