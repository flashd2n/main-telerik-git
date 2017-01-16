using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IDriver
    {
        private readonly int id;

        public Driver(string name, GenderType gender)
        {
            this.id = DataGenerator.GenerateId();
        }

        public IMotorVehicle ActiveVehicle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GenderType Gender
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IMotorVehicle> Vehicles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            throw new NotImplementedException();
        }
        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            throw new NotImplementedException();
        }
        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
