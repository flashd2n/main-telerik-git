using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleDamage : Specialty
    {
        private int numberOfRounds;

        public DoubleDamage(int numberOfRounds)
        {

            if (numberOfRounds <= 0)
            {
                throw new ArgumentOutOfRangeException("The number of rounds must be between 0 and 10");
            }

            this.numberOfRounds = numberOfRounds;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.numberOfRounds <= 0)
            {
                return currentDamage;
            }
            else
            {
                this.numberOfRounds--;
                return currentDamage * 2;
            }

        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.GetType().Name, this.numberOfRounds);
        }

    }
}
