namespace ArmyOfCreatures.Logic.Creatures
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using ArmyOfCreatures.Logic.Specialties;

    public abstract class Creature : ICreatures
    {
        private readonly ICollection<Specialty> specialtiesList;

        protected Creature(int attack, int defense, int healthPoints, decimal damage)
        {
            this.Attack = attack;
            this.Defense = defense;
            this.HealthPoints = healthPoints;
            this.Damage = damage;
            this.specialtiesList = new List<Specialty>();
        }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int HealthPoints { get; set; }

        public decimal Damage { get; set; }

        public IEnumerable<Specialty> Specialties
        {
            get
            {
                return this.specialtiesList;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0} (ATT:{1}; DEF:{2}; HP:{3}; DMG:{4})",
                this.GetType().Name,
                this.Attack,
                this.Defense,
                this.HealthPoints,
                this.Damage);

            // Battle effects
            stringBuilder.Append(" [");
            foreach (var speciallity in this.specialtiesList)
            {
                stringBuilder.AppendFormat("{0},", speciallity);
            }

            var result = stringBuilder.ToString().TrimEnd(',');
            result += "]";

            return result;
        }

        public void AddSpecialty(Specialty specialtyToAdd)
        {
            this.specialtiesList.Add(specialtyToAdd);
        }
    }
}
