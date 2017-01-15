namespace ArmyOfCreatures.Logic
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Extended.Creatures;

    using ArmyOfCreatures.Logic.Creatures;

    public class CreaturesFactory : ICreaturesFactory
    {
        public virtual Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "Angel":
                    return new Angel();
                case "Archangel":
                    return new Archangel();
                case "ArchDevil":
                    return new ArchDevil();
                case "Behemoth":
                    return new Behemoth();
                case "Devil":
                    return new Devil();
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "WolfRaider":
                    return new WolfRaider();
                case "Goblin":
                    return new Goblin();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "Griffin":
                    return new Griffin();
                default:
                    throw new ArgumentException(
                        string.Format(CultureInfo.InvariantCulture, "Invalid creature type \"{0}\"!", name));
            }
        }
    }
}
