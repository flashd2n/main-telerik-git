using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract
{
    public abstract class Exhaust : IExhaust, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private readonly ExhaustType exhaustType;

        public Exhaust(
           decimal price,
           int weight,
           int acceleration,
           int topSpeed,
           TunningGradeType gradeType,
           ExhaustType exhaustType)
        {
            this.exhaustType = exhaustType;
        }

        public int Acceleration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ExhaustType ExhaustType
        {
            get
            {
                return this.exhaustType;
            }
        }

        public TunningGradeType GradeType
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

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TopSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Weight
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
