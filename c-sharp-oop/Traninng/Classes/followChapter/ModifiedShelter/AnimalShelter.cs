using System;

namespace ModifiedShelter
{
    class AnimalShelter<T>
    {
        private const int DefaultCapacity = 20;
        private T[] animalList;
        private int usedSpaces;

        public AnimalShelter() : this (DefaultCapacity)
        {
        }

        public AnimalShelter(int totalCapacity)
        {
            this.animalList = new T[totalCapacity];
            this.usedSpaces = 0;
        }

        public void Shelter(T newAnimal)
        {
            if (usedSpaces >= animalList.Length)
            {
                throw new InvalidOperationException("Shelter is full.");
            }
            animalList[usedSpaces] = newAnimal;
            ++usedSpaces;
        }

        public T Release(int index)
        {
            if (index < 0 || index > animalList.Length - 1)
            {
                throw new InvalidOperationException("Index must be within the boundaries of the array");
            }
            T releasedAnimal = animalList[index];

            for (int i = index; i < usedSpaces; i++)
            {
                animalList[i] = animalList[i + 1];
            }

            animalList[usedSpaces - 1] = default(T);
            usedSpaces--;
            return releasedAnimal;
        }
    }
}
