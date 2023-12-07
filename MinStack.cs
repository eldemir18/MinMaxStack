using System;
using System.Collections;
using System.Collections.Generic;

public class MinStack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T> where T : IComparable<T>
{
    private readonly Stack<T> _stack;
    private readonly Stack<T> _minStack;
    
    public T Min => _minStack.Peek();
    public int Count => _stack.Count;

    public bool IsSynchronized => ((ICollection)_stack).IsSynchronized;
    public object SyncRoot => ((ICollection)_stack).SyncRoot;
    
    public MinStack()
    {
        _stack = new Stack<T>();
        _minStack = new Stack<T>();
    }

    public void Push(T value)
    {
        T minValue = value;

        if(Count != 0)
        {
            minValue = value.CompareTo(Min) < 0 ? value : Min;
        }

        _minStack.Push(minValue);
        _stack.Push(value);
    }

    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
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

