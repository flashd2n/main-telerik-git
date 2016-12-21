using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class Initiation
    {
        static void Main()
        {
            var myBattery = new Battery("some model", 3.4, 2.3);
            myBattery.BatteryType = BatteryType.LiIon;
            var myDisplay = new Display(5.5, 16000000);
            var myPhone = new GSM("iPhone", "Apple", 1900, "Flash", myBattery, myDisplay);

            myPhone.ShowInfo();

            Console.WriteLine("======");

            GSM.IPhone4S.ShowInfo();
            Console.WriteLine("======");

            Console.WriteLine($"{GSM.IPhone4S.Manufacturer}, {GSM.IPhone4S.Display.Size}, {GSM.IPhone4S.Battery.BatteryType}");
        }
    }
}
