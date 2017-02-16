using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Logic.Creatures
{
    public interface ICreatures
    {
        int Attack { get; set; }

        int Defense { get; set; }

        int HealthPoints { get; set; }

        decimal Damage { get; set; }

        IEnumerable<Specialty> Specialties { get; }

        string ToString();

        void AddSpecialty(Specialty specialtyToAdd);
    }
}
