using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    public class Singleton<T>where T:new()
    {
        protected Singleton() { }
        public static readonly T Instance = new T();
    }
}
