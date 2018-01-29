using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTest
{
    public class Farm<T>:IEnumerable<T> where T:Animal,new()
    {
        private List<T> animals = new List<T>();
        public List<T> Animals
        {
            get { return animals; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        public void MakeNoises()
        {
            foreach (T animal in animals)
            {
                animal.MakeANoise();
            }
        }
        public void FeedTheAnimals()
        {
            foreach (T animal in animals)
            {
                animal.Feed();
            }
        }

        public Farm<Cow> GetCows()
        {
            Farm<Cow> cowFarm = new Farm<Cow>();
            foreach (T animal in Animals)
            {
                if (animal is Cow)
                {
                    cowFarm.animals.Add(animal as Cow);
                }
            }
            return cowFarm;
        }
    }
}
