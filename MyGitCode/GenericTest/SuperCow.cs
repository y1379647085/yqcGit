using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTest
{
    public class SuperCow:Cow
    {
        public SuperCow(string newName) : base(newName)
        {
        }
        public override void MakeANoise()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            Console.WriteLine("{0} is flying!",name);
        }
    }
}
