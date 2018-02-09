using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUI
{
    public interface ITarget
    {
        void Request();
    }

    //public class Adaptee
    //{
    //    public void SpecificRequest()
    //    {
    //        Console.WriteLine("Called SpecificRequest");
    //    }
    //}

    //public class Adapter : Adaptee, ITarget
    //{
    //    public void Request()
    //    {
    //        this.SpecificRequest();
    //    }
    //}

    public class Target : ITarget
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request");
        }
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    public class Adapter : Target
    {
        private Adaptee _adaptee=new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }
}
