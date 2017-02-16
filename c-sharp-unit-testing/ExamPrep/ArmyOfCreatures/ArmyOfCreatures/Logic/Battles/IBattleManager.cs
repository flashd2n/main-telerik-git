namespace ArmyOfCreatures.Logic.Battles
{
    public interface IBattleManager
    {
        void AddCreatures(ICreatureIdentifier creatureIdentifier, int count);

        void Attack(ICreatureIdentifier attackerIdentifier, ICreatureIdentifier defenderIdentifier);

        void Skip(ICreatureIdentifier creatureIdentifier);
    }
}
