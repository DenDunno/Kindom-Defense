using System;
using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }
    
    public static void UpdateForEach(this IEnumerable<IUpdatable> collection)
    {
        foreach (IUpdatable element in collection)
        {
            element.Update();
        }
    }
    
    public static bool IsNotEmpty<T>(this Stack<T> stack)
    {
        return stack.Count != 0;
    }
    
    public static bool IsEmpty<T>(this Stack<T> stack)
    {
        return stack.Count == 0;
    }
    
    public static bool IsNotEmpty<T>(this Queue<T> queue)
    {
        return queue.Count != 0;
    }
}