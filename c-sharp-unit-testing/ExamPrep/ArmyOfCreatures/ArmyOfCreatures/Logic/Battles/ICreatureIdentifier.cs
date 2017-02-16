using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Logic.Battles
{
    public interface ICreatureIdentifier
    {
        string CreatureType { get; set; }

        int ArmyNumber { get; set; }

        string ToString();
    }
}
