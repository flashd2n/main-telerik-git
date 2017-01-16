using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    class AncientBehemoth : Creature
    {
        public AncientBehemoth() : base(19, 19, 300, 40M)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }

    }
}
