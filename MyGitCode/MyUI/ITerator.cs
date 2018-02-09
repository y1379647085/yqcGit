using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUI
{
    //public abstract class ITerator
    //{
    //    public abstract object First();
    //    public abstract object Next();
    //    public abstract bool IsDone();
    //    public abstract object CurrentItem();
    //}
    //public abstract class Aggregate
    //{
    //    public abstract ITerator CreateIterator();
    //}
    //public class ConcreteAggregate : Aggregate
    //{
    //    private readonly ArrayList _items = new ArrayList();

    //    public override ITerator CreateIterator()
    //    {
    //        return new ConcreteIterator(this);
    //    }

    //    public int Count => _items.Count;

    //    public object this[int index]
    //    {
    //        get { return _items[index]; }
    //        set { _items.Insert(index, value); }
    //    }
    //}

    //public class ConcreteIterator : ITerator
    //{
    //    private ConcreteAggregate _aggregate;
    //    private int _current = 0;

    //    public ConcreteIterator(ConcreteAggregate aggregate)
    //    {
    //        this._aggregate = aggregate;
    //    }

    //    public override object First()
    //    {
    //        return _aggregate[0];
    //    }

    //    public override object Next()
    //    {
    //        object ret = null;
    //        if (_current < _aggregate.Count - 1)
    //        {
    //            ret = _aggregate[++_current];
    //        }

    //        return ret;
    //    }

    //    public override object CurrentItem()
    //    {
    //        return _aggregate[_current];
    //    }

    //    public override bool IsDone()
    //    {
    //        return _current >= _aggregate.Count;
    //    }
    //}
}
