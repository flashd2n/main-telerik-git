namespace ArmyOfCreatures.Logic
{
    using ArmyOfCreatures.Logic.Creatures;

    public interface ICreaturesFactory
    {
        ICreatures CreateCreature(string name);
    }
}
