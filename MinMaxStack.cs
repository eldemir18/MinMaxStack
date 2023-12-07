using System;
using System.Collections;
using System.Collections.Generic;

public class MinMaxStack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T> where T : IComparable<T>
{
    private readonly Stack<T> _stack;
    private readonly Stack<T> _minStack;      
    private readonly Stack<T> _maxStack;
    
    public T Min => _minStack.Peek();
    public T Max => _maxStack.Peek();
    public int Count => _stack.Count;

    public bool IsSynchronized => ((ICollection)_stack).IsSynchronized;
    public object SyncRoot => ((ICollection)_stack).SyncRoot;

    public MinMaxStack()
    {
        _stack = new Stack<T>();
        _minStack = new Stack<T>();
        _maxStack = new Stack<T>();
    }

    public void Push(T value)
    {
        T minValue = value;
        T maxValue = value;

        if(Count != 0)
        {
            minValue = value.CompareTo(Min) < 0 ? value : Min;
            maxValue = value.CompareTo(Max) > 0 ? value : Max;
        }

        _stack.Push(value);
        _minStack.Push(minValue);
        _maxStack.Push(maxValue);
    }

    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
        _maxStack.Pop();
    }

    public T Peek()
    {
        return _stack.Peek();
    }

    public bool Contains(T item)
    {
        return _stack.Contains(item);
    }

    public T[] ToArray()
    {
        return _stack.ToArray();
    }

    public void Clear()
    {
        _stack.Clear();
        _minStack.Clear();
        _maxStack.Clear();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerable<T>)_stack).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_stack).GetEnumerator();
    }

    void ICollection.CopyTo(Array array, int index)
    {
        ((ICollection)_stack).CopyTo(array, index);
    }
}

