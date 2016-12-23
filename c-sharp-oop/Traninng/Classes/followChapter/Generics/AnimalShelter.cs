using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class AnimalShelter
    {
        private const int DefaultPlacesCount = 20;
        private Dog[] animalList;
        private int usedPlaces;

        public AnimalShelter() : this (DefaultPlacesCount)
        {

        }

        public AnimalShelter(int placesCount)
        {
            this.animalList = new Dog[placesCount];
            this.usedPlaces = 0;
        }

        public void Shelter(Dog newAnimal)
        {
            if (usedPlaces >= this.animalList.Length)
            {
                throw new InvalidOperationException("Shelter is full");
            }
            this.animalList[usedPlaces] = newAnimal;
            ++usedPlaces;
        }

        public Dog Release(int index)
        {
            if (index < 0 || index > animalList.Length - 1)
            {
                throw new InvalidOperationException("Index must be within the boundaries of the array");
            }

            Dog releasedAnimal = this.animalList[index];
            for (int i = index; i < usedPlaces; i++)
            {
                animalList[i] = animalList[i + 1];
            }

            animalList[usedPlaces - 1] = null;
            usedPlaces--;

            return releasedAnimal;

        }


    }
}
