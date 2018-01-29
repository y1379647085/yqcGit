using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTest
{
    public class Animals:CollectionBase
    {
        public void Add(Animal newAnimal)
        {
            List.Add(newAnimal);
        }

        public void Remove(Animal oldAnimal)
        {
            List.Remove(oldAnimal);
        }
        public Animals()
        {
        }
    }
}
