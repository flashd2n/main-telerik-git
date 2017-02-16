using ArmyOfCreatures.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Tests.ExtendedTests
{
    public class FakeBattleManagerWithThreeArmies : BattleManagerWithThreeArmies
    {

        public FakeBattleManagerWithThreeArmies(ICreaturesFactory creaturesFactory, ILogger logger) : base(creaturesFactory, logger)
        {
        }
    }
}
