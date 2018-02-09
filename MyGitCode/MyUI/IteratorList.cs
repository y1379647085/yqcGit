using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUI
{
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    public interface Iterator
    {
        bool MoveNext();
        Object GetCurrent();
         void Next();
         void Reset();
    }

    public class ConcreteList : IListCollection
    {
      
        private int[] collection;

        public ConcreteList()
        {
            collection=new int[] {2,4,6,8};
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }       
    }

    public class ConcreteIterator : Iterator
    {
        private int _index;
            // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;
        public ConcreteIterator(ConcreteList list)
        {
            
        }

        public bool MoveNext()
        {
            if (_index < _list.Length) return true;
            return false;
        }

        public object GetCurrent()
        {
            return null;
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {

        }
    }
}
