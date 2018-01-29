using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUI
{
    public class VirtualClassFather
    {
        public virtual void CreateNode()
        {
            Console.WriteLine("Father");
        }
    }

    public class VirtualClass : VirtualClassFather
    {
        public override  void CreateNode()
        {
            Console.WriteLine("Child");
        }
    }
}
